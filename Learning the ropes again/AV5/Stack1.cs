// Imenici, iznimke, generički tipovi


namespace First;

class Stack<T>
{
    T[] data;
    int sp;

    public Stack(int size)
    {
        data = new T[size];
        sp = -1;
    }

    public void Push(T value)
    {
        if (IsFull())
            throw new InvalidOperationException("Stack overflow");
        sp++;
        data[sp] = value;
    }
    public T Pop()
    {
        if (IsEmpty())
            throw new StackUnderflowException(404, "Stack underflow");
        T value = data[sp];
        sp--;
        return value;
    }

    public bool IsEmpty() => sp == -1;

    public bool IsFull() => sp == data.Length - 1;

    public void Clear() => sp = -1;
}
