using System;

public class BankAccount
{
    private bool isOpen = false;
    private float balance;
    private readonly object bankAccountLock = new Object();

    public void Open()
    {
        isOpen = true;
    }

    public void Close()
    {
        isOpen = false;
    }

    public float Balance
    {
        get
        {
            if (!isOpen) throw new InvalidOperationException();

            return balance;
        }
        private set
        {
            if (!isOpen) throw new InvalidOperationException();

            balance = value;
        }
    }

    public void UpdateBalance(float change)
    {
        lock (bankAccountLock)
        {
            Balance += change;
        }
    }
}
