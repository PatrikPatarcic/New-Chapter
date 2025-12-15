namespace First;

class Stack
{
    int[] data;
    int sp;

    public Stack(int size)
    {
        data = new int[size];
        sp = -1;
    }

    public void Push(int value)
    {
        if(IsFull())
            throw new InvalidOperationException("Stack overflow");
        sp++;
        data[sp] = value;
    }
    public int Pop()
    {
        if(IsEmpty())
            throw new StackUnderflowException(404, "Stack underflow");
        int value = data[sp];
        sp--;
        return value;
    }

    public bool IsEmpty() => sp == -1;

    public bool IsFull() => sp == data.Length - 1;

    public void Clear() => sp = -1;
}
