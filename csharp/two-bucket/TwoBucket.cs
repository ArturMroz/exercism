using System;
using System.Collections.Generic;
using System.Linq;

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
    private readonly int _bucketOneSize;
    private readonly int _bucketTwoSize;
    private readonly Bucket _startBucket;

    public TwoBucket(int bucketOne, int bucketTwo, Bucket startBucket)
    {
        _bucketOneSize = bucketOne;
        _bucketTwoSize = bucketTwo;
        _startBucket = startBucket;
    }

    public TwoBucketResult Measure(int goal)
    {
        var result = new TwoBucketResult { Moves = int.MaxValue };
        var startBuckets = Fill(_startBucket, (0, 0));
        var methods = new MethodDelegate[] { Fill, Empty, PourTo };

        Backtrack(startBuckets, new List<(int, int)> { startBuckets });

        return result;

        void Backtrack((int, int) buckets, IEnumerable<(int, int)> history)
        {
            if (history.Count() > result.Moves) return;

            if (buckets.Item1 == goal || buckets.Item2 == goal)
            {
                result.Moves = history.Count();
                if (buckets.Item1 == goal)
                {
                    result.OtherBucket = buckets.Item2;
                    result.GoalBucket = Bucket.One;
                }
                else
                {
                    result.OtherBucket = buckets.Item1;
                    result.GoalBucket = Bucket.Two;
                }

                return;
            }

            foreach (var method in methods)
            {
                foreach (Bucket bucketNumber in Enum.GetValues(typeof(Bucket)))
                {
                    var newBuckets = method.Invoke(bucketNumber, buckets);

                    if (history.Contains(newBuckets)) continue;

                    if (_startBucket == Bucket.One && newBuckets == (0, _bucketTwoSize))
                        continue;

                    if (_startBucket == Bucket.Two && newBuckets == (_bucketOneSize, 0))
                        continue;

                    var newHistory = history.ToList();
                    newHistory.Add(newBuckets);
                    Backtrack(newBuckets, newHistory);
                }
            }
        }
    }

    public delegate (int, int) MethodDelegate(Bucket bucket, (int, int) buckets);

    private (int, int) PourTo(Bucket goalBucket, (int, int) buckets)

    {
        var (b1, b2) = buckets;

        if (goalBucket == Bucket.One)
        {
            var howMuchWillFit = Math.Min(_bucketOneSize - b1, b2);
            b1 += howMuchWillFit;
            b2 -= howMuchWillFit;
        }
        else
        {
            var howMuchWillFit = Math.Min(_bucketTwoSize - b2, b1);
            b2 += howMuchWillFit;
            b1 -= howMuchWillFit;
        }

        return (b1, b2);
    }

    private (int, int) Empty(Bucket bucket, (int, int) buckets)
    {
        if (bucket == Bucket.One) return (0, buckets.Item2);
        else return (buckets.Item1, 0);
    }

    private (int, int) Fill(Bucket bucket, (int, int) buckets)
    {
        if (bucket == Bucket.One) return (_bucketOneSize, buckets.Item2);
        else return (buckets.Item1, _bucketTwoSize);
    }
}
