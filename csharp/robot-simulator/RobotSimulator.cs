using System;

public enum Direction
{
    North,
    East,
    South,
    West
}

public struct Coordinate
{
    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; }
    public int Y { get; }
}

public class RobotSimulator
{
    private const int MinDirectionValue = 0;
    private const int MaxDirectionValue = 3;


    public RobotSimulator(Direction direction, Coordinate coordinate)
    {
        Direction = direction;
        Coordinate = coordinate;
    }

    public Direction Direction { get; set; }

    public Coordinate Coordinate { get; set; }


    public void TurnRight()
    {
        Direction += 1;
        if ((int)Direction > MaxDirectionValue) Direction = (Direction)MinDirectionValue;
    }

    public void TurnLeft()
    {
        Direction -= 1;
        if ((int)Direction < MinDirectionValue) Direction = (Direction)MaxDirectionValue;
    }

    public void Advance()
    {
        switch (Direction)
        {
            case Direction.North:
                Coordinate = new Coordinate(Coordinate.X, Coordinate.Y + 1);
                break;
            case Direction.East:
                Coordinate = new Coordinate(Coordinate.X + 1, Coordinate.Y);
                break;
            case Direction.South:
                Coordinate = new Coordinate(Coordinate.X, Coordinate.Y - 1);
                break;
            case Direction.West:
                Coordinate = new Coordinate(Coordinate.X - 1, Coordinate.Y);
                break;
            default:
                break;
        }
    }

    public void Simulate(string instructions)
    {
        foreach (var instruction in instructions)
        {
            switch (instruction)
            {
                case 'R':
                    TurnRight();
                    break;
                case 'L':
                    TurnLeft();
                    break;
                case 'A':
                    Advance();
                    break;
                default:
                    Console.WriteLine("Uknknown instruction");
                    break;
            }
        }
    }
}