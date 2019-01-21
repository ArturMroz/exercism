module RestApi

open FSharp.Json

type User =
    { name: string
      mutable owes: Map<string, decimal>
      [<JsonField("owed_by")>]
      mutable owedBy: Map<string, decimal>
      mutable balance: decimal }

type IouPayload =
    { lender: string
      borrower: string
      amount: decimal }

type UserPayload = { user: string }

type UsersPayload = { users: string list }

type Database = { mutable users: User list }

let toJson obj =
    let config = JsonConfig.create (unformatted = true)
    Json.serializeEx config obj

type RestApi(database: string) =
    let mutable db = Json.deserialize<Database> database

    member this.Get(url: string) =
        match url with
        | "/users" -> toJson db
        | _ -> "404"

    member this.Get(url: string, payload: string) =
        match url with
        | "/users" ->
            let pl = Json.deserialize<UsersPayload> payload
            let usersFiltered = db.users |> List.filter (fun x -> List.contains x.name pl.users)
            toJson { users = usersFiltered }
        | _ -> "404"

    member this.Post(url: string, payload: string) =
        match url with
        | "/add" ->
            let pl = Json.deserialize<UserPayload> payload
            let newUser = { name = pl.user; owes = Map.empty; owedBy = Map.empty; balance = 0.0m }
            db.users <- newUser :: db.users
            toJson newUser

        | "/iou" ->
            let processTransaction target friend amount =
                let balanceAgainst list = list |> Map.tryFind friend |> Option.defaultValue 0.0m
                let state = balanceAgainst target.owedBy - balanceAgainst target.owes + amount

                target.owedBy <- target.owedBy |> Map.remove friend
                target.owes <- target.owes |> Map.remove friend
                if state > 0.0m then
                    target.owedBy <- target.owedBy |> Map.add friend state
                elif state < 0.0m then
                    target.owes <- target.owes |> Map.add friend -state

                target.balance <- target.balance + amount

            let pl = Json.deserialize<IouPayload> payload
            let findUser name = db.users |> List.find (fun x -> x.name = name)
            let lender, borrower = findUser pl.lender, findUser pl.borrower

            processTransaction lender pl.borrower pl.amount
            processTransaction borrower pl.lender -pl.amount

            toJson { users = [ lender; borrower ] |> List.sortBy (fun x -> x.name) }

          | _ -> "404"
