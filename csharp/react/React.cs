using System;
using System.Collections.Generic;
using System.Linq;

public class Reactor
{
    public InputCell CreateInputCell(int value) => new InputCell(value);

    public ComputeCell CreateComputeCell(IEnumerable<Cell> producers, Func<int[], int> compute) =>
        new ComputeCell(producers, compute);
}

public abstract class Cell
{
    public Cell()
    {
        Observers = new List<ComputeCell>();
    }

    public event EventHandler<int> Changed;

    public IList<ComputeCell> Observers { get; set; }
    public bool IsStable { get; private set; } = true;

    protected int _value;
    public virtual int Value
    {
        get => _value;
        set
        {
            if (_value != value)
            {
                foreach (var observer in Observers)
                {
                    observer.IsStable = false;
                }

                if (this is ComputeCell computeCell)
                {
                    IsStable = computeCell.Producers.All(p => p.IsStable);
                }

                if (IsStable)
                {
                    _value = value;
                    OnChanged(value);
                }

                foreach (var observer in Observers)
                {
                    observer.UpdateValue();
                }
            }
        }
    }

    private void OnChanged(int value)
    {
        var handler = Changed;
        if (handler != null)
        {
            handler(this, value);
        }
    }
}

public class InputCell : Cell
{
    public InputCell(int value) : base()
    {
        Value = value;
    }
}

public class ComputeCell : Cell
{
    public ComputeCell(IEnumerable<Cell> producers, Func<int[], int> compute) : base()
    {
        Producers = producers;
        Compute = compute;

        foreach (var producer in producers)
        {
            producer.Observers.Add(this);
        }

        UpdateValue();
    }

    public IEnumerable<Cell> Producers { get; set; }
    public Func<int[], int> Compute { get; set; }

    public void UpdateValue()
    {
        Value = Compute(Producers.Select(x => x.Value).ToArray());
    }
}