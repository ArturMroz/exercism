module BankAccount

type Account = { mutable balance : decimal ; isOpen : bool }

let mkBankAccount() = { balance = 0.0m; isOpen = false }

let openAccount account = { account with isOpen = true }

let closeAccount account = { account with isOpen = false }

let getBalance account = 
    match account.isOpen with
    | true -> Some account.balance
    | false -> None

let accountLock = new System.Object()

let updateBalance (change: decimal) account =
    lock accountLock (fun _ -> account.balance <- account.balance + change)
    account