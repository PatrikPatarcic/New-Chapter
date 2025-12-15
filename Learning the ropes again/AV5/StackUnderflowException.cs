namespace First;

// deprecate

class StackUnderflowException : Exception
{
    public int MyProperty { get; private set; } = -1;

    public StackUnderflowException(int myprop) : base()
    {
        this.MyProperty = myprop;
    }

    public StackUnderflowException(int myprop, string? message) : base(message)
    {
        this.MyProperty = myprop;
    }
}