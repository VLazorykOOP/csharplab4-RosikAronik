using System;

class VectorInt
{
    private int[] IntArray;
    private uint size;
    private int codeError;
    private static uint num_vec = 0;

    public VectorInt()
    {
        size = 1;
        IntArray = new int[size];
        num_vec++;
    }

    public VectorInt(uint size)
    {
        this.size = size;
        IntArray = new int[size];
        num_vec++;
    }

    public VectorInt(uint size, int initValue)
    {
        this.size = size;
        IntArray = new int[size];
        for (uint i = 0; i < size; i++)
        {
            IntArray[i] = initValue;
        }
        num_vec++;
    }

    ~VectorInt()
    {
        Console.WriteLine("Destructor called.");
    }

    public void InputElements()
    {
        for (uint i = 0; i < size; i++)
        {
            Console.Write($"Enter element at index {i}: ");
            IntArray[i] = int.Parse(Console.ReadLine());
        }
    }

    public void DisplayElements()
    {
        Console.WriteLine("Vector Elements:");
        for (uint i = 0; i < size; i++)
        {
            Console.WriteLine($"Element at index {i}: {IntArray[i]}");
        }
    }

    public void Assign(int value)
    {
        for (uint i = 0; i < size; i++)
        {
            IntArray[i] = value;
        }
    }

    public static uint GetVectorCount()
    {
        return num_vec;
    }

    public uint Size
    {
        get { return size; }
    }

    public int CodeError
    {
        get { return codeError; }
        set { codeError = value; }
    }

    public int this[uint index]
    {
        get
        {
            if (index < size)
                return IntArray[index];
            else
            {
                codeError = -1;
                return 0;
            }
        }
        set
        {
            codeError = -1;
        }
    }

    public static VectorInt operator ++(VectorInt v)
    {
        for (uint i = 0; i < v.size; i++)
        {
            v.IntArray[i]++;
        }
        return v;
    }

    public static VectorInt operator --(VectorInt v)
    {
        for (uint i = 0; i < v.size; i++)
        {
            v.IntArray[i]--;
        }
        return v;
    }

    public static bool operator true(VectorInt v)
    {
        for (uint i = 0; i < v.size; i++)
        {
            if (v.IntArray[i] == 0)
                return false;
        }
        return true;
    }

    public static bool operator false(VectorInt v)
    {
        for (uint i = 0; i < v.size; i++)
        {
            if (v.IntArray[i] != 0)
                return false;
        }
        return true;
    }

    public static bool operator !(VectorInt v)
    {
        for (uint i = 0; i < v.size; i++)
        {
            if (v.IntArray[i] == 0)
                return true;
        }
        return false;
    }

    public static VectorInt operator +(VectorInt v, int scalar)
    {
        for (uint i = 0; i < v.size; i++)
        {
            v.IntArray[i] += scalar;
        }
        return v;
    }

    public static VectorInt operator -(VectorInt v, int scalar)
    {
        for (uint i = 0; i < v.size; i++)
        {
            v.IntArray[i] -= scalar;
        }
        return v;
    }

    public static VectorInt operator *(VectorInt v, int scalar)
    {
        for (uint i = 0; i < v.size; i++)
        {
            v.IntArray[i] *= scalar;
        }
        return v;
    }

    public static VectorInt operator /(VectorInt v, int scalar)
    {
        for (uint i = 0; i < v.size; i++)
        {
            if (scalar != 0)
                v.IntArray[i] /= scalar;
            else
                v.codeError = -1;
        }
        return v;
    }

    public static VectorInt operator %(VectorInt v, int scalar)
    {
        for (uint i = 0; i < v.size; i++)
        {
            if (scalar != 0)
                v.IntArray[i] %= scalar;
            else
                v.codeError = -1;
        }
        return v;
    }

    public static VectorInt operator |(VectorInt v, int scalar)
    {
        for (uint i = 0; i < v.size; i++)
        {
            v.IntArray[i] |= scalar;
        }
        return v;
    }

    public static VectorInt operator ^(VectorInt v, int scalar)
    {
        for (uint i = 0; i < v.size; i++)
        {
            v.IntArray[i] ^= scalar;
        }
        return v;
    }

    public static VectorInt operator &(VectorInt v, int scalar)
    {
        for (uint i = 0; i < v.size; i++)
        {
            v.IntArray[i] &= scalar;
        }
        return v;
    }

    public static VectorInt operator >>(VectorInt v, int shift)
    {
        for (uint i = 0; i < v.size; i++)
        {
            v.IntArray[i] >>= shift;
        }
        return v;
    }

    public static VectorInt operator <<(VectorInt v, int shift)
    {
        for (uint i = 0; i < v.size; i++)
        {
            v.IntArray[i] <<= shift;
        }
        return v;
    }

    public static bool operator ==(VectorInt v1, VectorInt v2)
    {
        if (v1.size != v2.size)
            return false;

        for (uint i = 0; i < v1.size; i++)
        {
            if (v1.IntArray[i] != v2.IntArray[i])
                return false;
        }
        return true;
    }

    public static bool operator !=(VectorInt v1, VectorInt v2)
    {
        return !(v1 == v2);
    }

    public static bool operator >(VectorInt v1, VectorInt v2)
    {
        if (v1.size != v2.size)
            return false;

        for (uint i = 0; i < v1.size; i++)
        {
            if (v1.IntArray[i] <= v2.IntArray[i])
                return false;
        }
        return true;
    }

    public static bool operator >=(VectorInt v1, VectorInt v2)
    {
        if (v1.size != v2.size)
            return false;

        for (uint i = 0; i < v1.size; i++)
        {
            if (v1.IntArray[i] < v2.IntArray[i])
                return false;
        }
        return true;
    }

    public static bool operator <(VectorInt v1, VectorInt v2)
    {
        if (v1.size != v2.size)
            return false;

        for (uint i = 0; i < v1.size; i++)
        {
            if (v1.IntArray[i] >= v2.IntArray[i])
                return false;
        }
        return true;
    }

    public static bool operator <=(VectorInt v1, VectorInt v2)
    {
        if (v1.size != v2.size)
            return false;

        for (uint i = 0; i < v1.size; i++)
        {
            if (v1.IntArray[i] > v2.IntArray[i])
                return false;
        }
        return true;
    }
}

class Program2
{
    static void Task2(string[] args)
    {
        VectorInt v1 = new VectorInt(3, 1);
        VectorInt v2 = new VectorInt(3, 2);
        VectorInt v3 = new VectorInt(3, 1);

        v1.DisplayElements();
        v2.DisplayElements();

        VectorInt sum = v1 + 2;
        VectorInt difference = v1 - 2;
        VectorInt product = v1 * 2;
        VectorInt division = v1 / 2;
        VectorInt modulus = v1 % 2;
        VectorInt bitwiseOr = v1 | 2;
        VectorInt bitwiseXor = v1 ^ 2;
        VectorInt bitwiseAnd = v1 & 2;
        VectorInt rightShift = v1 >> 1;
        VectorInt leftShift = v1 << 1;

        sum.DisplayElements();
        difference.DisplayElements();
        product.DisplayElements();
        division.DisplayElements();
        modulus.DisplayElements();
        bitwiseOr.DisplayElements();
        bitwiseXor.DisplayElements();
        bitwiseAnd.DisplayElements();
        rightShift.DisplayElements();
        leftShift.DisplayElements();

        Console.WriteLine("v1 == v3: " + (v1 == v3));
        Console.WriteLine("v1 != v2: " + (v1 != v2));
        Console.WriteLine("v1 > v2: " + (v1 > v2));
        Console.WriteLine("v1 >= v2: " + (v1 >= v2));
        Console.WriteLine("v1 < v2: " + (v1 < v2));
        Console.WriteLine("v1 <= v2: " + (v1 <= v2));
    }
}
