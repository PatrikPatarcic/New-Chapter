namespace First;

class Dummy : IComparable<Dummy> // when dummy implements IComparable<Dummy> it can be used in findMin and calculateMatchPercentage
{
    int value;

    public Dummy(int value = 0)
    {
        this.value = value;
    }
    // base CompareTo returns -1 if this < other, 0 if equal, 1 if this > other
    // remember [-1, 0, 1] 
    public int CompareTo(Dummy? other)
    {   if (other == null) return 1;
        return this.value.CompareTo(other.value);
    }

    public int FindMin(Dummy other)
    {
        if (other == null) return 1;
        return this.value.CompareTo(other.value);
    }
}

