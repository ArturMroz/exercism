using System;

public enum Bucket
{
    One,
    Two
}

public class TwoBucketResult
{
    public int Moves { get; set; }
    public Bucket GoalBucket { get; set; }
    public int OtherBucket { get; set; }
}

public class TwoBucket
{
    private readonly int _startCapacity;
    private readonly int _otherCapacity;
    private readonly Bucket _start;
    private readonly Bucket _other;

    public TwoBucket(int bucketOne, int bucketTwo, Bucket startBucket) =>
        (_startCapacity, _otherCapacity, _start, _other) =
            startBucket == Bucket.One ? (bucketOne, bucketTwo, Bucket.One, Bucket.Two) :
                                        (bucketTwo, bucketOne, Bucket.Two, Bucket.One);

    public TwoBucketResult Measure(int goal)
    {
        if (_startCapacity == goal)
            return new TwoBucketResult { Moves = 1, GoalBucket = _start, OtherBucket = 0 };
        if (_otherCapacity == goal)
            return new TwoBucketResult { Moves = 2, GoalBucket = _other, OtherBucket = _startCapacity };

        var moves = 0;
        var startState = 0;
        var otherState = 0;

        while (true)
        {
            if (startState == 0)
                (startState, moves) = (_startCapacity, moves + 1);

            var amount = Math.Min(startState, _otherCapacity - otherState);
            (startState, otherState, moves) = (startState - amount, otherState + amount, moves + 1);

            if (startState == goal)
                return new TwoBucketResult { Moves = moves, GoalBucket = _start, OtherBucket = otherState };

            if (otherState == _otherCapacity)
                (otherState, moves) = (0, moves + 1);
        }
    }
}