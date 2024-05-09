using System;

class MatrixInt
{
    private int[,] IntArray;
    private int n, m;
    private int codeError;
    private static int num_mat = 0;

    public MatrixInt()
    {
        n = 1;
        m = 1;
        IntArray = new int[n, m];
        num_mat++;
    }

    public MatrixInt(int n, int m)
    {
        this.n = n;
        this.m = m;
        IntArray = new int[n, m];
        num_mat++;
    }

    public MatrixInt(int n, int m, int initValue)
    {
        this.n = n;
        this.m = m;
        IntArray = new int[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                IntArray[i, j] = initValue;
            }
        }
        num_mat++;
    }

    ~MatrixInt()
    {
        Console.WriteLine("Destructor called.");
    }

    public void InputElements()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"Enter element at index ({i}, {j}): ");
                IntArray[i, j] = int.Parse(Console.ReadLine());
            }
        }
    }

    public void DisplayElements()
    {
        Console.WriteLine("Matrix Elements:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.WriteLine($"Element at index ({i}, {j}): {IntArray[i, j]}");
            }
        }
    }

    public void Assign(int value)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                IntArray[i, j] = value;
            }
        }
    }

    public static int GetMatrixCount()
    {
        return num_mat;
    }

    public int Rows
    {
        get { return n; }
    }

    public int Columns
    {
        get { return m; }
    }

    public int CodeError
    {
        get { return codeError; }
        set { codeError = value; }
    }

    public int this[int i, int j]
    {
        get
        {
            if (i >= 0 && i < n && j >= 0 && j < m)
                return IntArray[i, j];
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

    public static MatrixInt operator ++(MatrixInt mat)
    {
        for (int i = 0; i < mat.n; i++)
        {
            for (int j = 0; j < mat.m; j++)
            {
                mat.IntArray[i, j]++;
            }
        }
        return mat;
    }

    public static MatrixInt operator --(MatrixInt mat)
    {
        for (int i = 0; i < mat.n; i++)
        {
            for (int j = 0; j < mat.m; j++)
            {
                mat.IntArray[i, j]--;
            }
        }
        return mat;
    }

    public static bool operator true(MatrixInt mat)
    {
        for (int i = 0; i < mat.n; i++)
        {
            for (int j = 0; j < mat.m; j++)
            {
                if (mat.IntArray[i, j] == 0)
                    return false;
            }
        }
        return true;
    }

    public static bool operator false(MatrixInt mat)
    {
        for (int i = 0; i < mat.n; i++)
        {
            for (int j = 0; j < mat.m; j++)
            {
                if (mat.IntArray[i, j] != 0)
                    return false;
            }
        }
        return true;
    }

    public static bool operator !(MatrixInt mat)
    {
        for (int i = 0; i < mat.n; i++)
        {
            for (int j = 0; j < mat.m; j++)
            {
                if (mat.IntArray[i, j] == 0)
                    return true;
            }
        }
        return false;
    }

    public static MatrixInt operator +(MatrixInt mat1, MatrixInt mat2)
    {
        if (mat1.n != mat2.n || mat1.m != mat2.m)
            return mat1;

        MatrixInt result = new MatrixInt(mat1.n, mat1.m);
        for (int i = 0; i < mat1.n; i++)
        {
            for (int j = 0; j < mat1.m; j++)
            {
                result.IntArray[i, j] = mat1.IntArray[i, j] + mat2.IntArray[i, j];
            }
        }
        return result;
    }

    public static MatrixInt operator -(MatrixInt mat1, MatrixInt mat2)
    {
        if (mat1.n != mat2.n || mat1.m != mat2.m)
            return mat1;

        MatrixInt result = new MatrixInt(mat1.n, mat1.m);
        for (int i = 0; i < mat1.n; i++)
        {
            for (int j = 0; j < mat1.m; j++)
            {
                result.IntArray[i, j] = mat1.IntArray[i, j] - mat2.IntArray[i, j];
            }
        }
        return result;
    }

    public static MatrixInt operator *(MatrixInt mat1, int scalar)
    {
        MatrixInt result = new MatrixInt(mat1.n, mat1.m);
        for (int i = 0; i < mat1.n; i++)
        {
            for (int j = 0; j < mat1.m; j++)
            {
                result.IntArray[i, j] = mat1.IntArray[i, j] * scalar;
            }
        }
        return result;
    }

    public static MatrixInt operator /(MatrixInt mat1, int scalar)
    {
        if (scalar == 0)
            return mat1;

        MatrixInt result = new MatrixInt(mat1.n, mat1.m);
        for (int i = 0; i < mat1.n; i++)
        {
            for (int j = 0; j < mat1.m; j++)
            {
                result.IntArray[i, j] = mat1.IntArray[i, j] / scalar;
            }
        }
        return result;
    }

    public static MatrixInt operator %(MatrixInt mat1, int scalar)
    {
        if (scalar == 0)
            return mat1;

        MatrixInt result = new MatrixInt(mat1.n, mat1.m);
        for (int i = 0; i < mat1.n; i++)
        {
            for (int j = 0; j < mat1.m; j++)
            {
                result.IntArray[i, j] = mat1.IntArray[i, j] % scalar;
            }
        }
        return result;
    }

    public static MatrixInt operator |(MatrixInt mat1, int scalar)
    {
        MatrixInt result = new MatrixInt(mat1.n, mat1.m);
        for (int i = 0; i < mat1.n; i++)
        {
            for (int j = 0; j < mat1.m; j++)
            {
                result.IntArray[i, j] = mat1.IntArray[i, j] | scalar;
            }
        }
        return result;
    }

    public static MatrixInt operator ^(MatrixInt mat1, int scalar)
    {
        MatrixInt result = new MatrixInt(mat1.n, mat1.m);
        for (int i = 0; i < mat1.n; i++)
        {
            for (int j = 0; j < mat1.m; j++)
            {
                result.IntArray[i, j] = mat1.IntArray[i, j] ^ scalar;
            }
        }
        return result;
    }

    public static MatrixInt operator &(MatrixInt mat1, int scalar)
    {
        MatrixInt result = new MatrixInt(mat1.n, mat1.m);
        for (int i = 0; i < mat1.n; i++)
        {
            for (int j = 0; j < mat1.m; j++)
            {
                result.IntArray[i, j] = mat1.IntArray[i, j] & scalar;
            }
        }
        return result;
    }

    public static MatrixInt operator >>(MatrixInt mat1, int shift)
    {
        MatrixInt result = new MatrixInt(mat1.n, mat1.m);
        for (int i = 0; i < mat1.n; i++)
        {
            for (int j = 0; j < mat1.m; j++)
            {
                result.IntArray[i, j] = mat1.IntArray[i, j] >> shift;
            }
        }
        return result;
    }

    public static MatrixInt operator <<(MatrixInt mat1, int shift)
    {
        MatrixInt result = new MatrixInt(mat1.n, mat1.m);
        for (int i = 0; i < mat1.n; i++)
        {
            for (int j = 0; j < mat1.m; j++)
            {
                result.IntArray[i, j] = mat1.IntArray[i, j] << shift;
            }
        }
        return result;
    }

    public static bool operator ==(MatrixInt mat1, MatrixInt mat2)
    {
        if (mat1.n != mat2.n || mat1.m != mat2.m)
            return false;

        for (int i = 0; i < mat1.n; i++)
        {
            for (int j = 0; j < mat1.m; j++)
            {
                if (mat1.IntArray[i, j] != mat2.IntArray[i, j])
                    return false;
            }
        }
        return true;
    }

    public static bool operator !=(MatrixInt mat1, MatrixInt mat2)
    {
        return !(mat1 == mat2);
    }

    public static bool operator >(MatrixInt mat1, MatrixInt mat2)
    {
        if (mat1.n != mat2.n || mat1.m != mat2.m)
            return false;

        for (int i = 0; i < mat1.n; i++)
        {
            for (int j = 0; j < mat1.m; j++)
            {
                if (mat1.IntArray[i, j] <= mat2.IntArray[i, j])
                    return false;
            }
        }
        return true;
    }

    public static bool operator >=(MatrixInt mat1, MatrixInt mat2)
    {
        if (mat1.n != mat2.n || mat1.m != mat2.m)
            return false;

        for (int i = 0; i < mat1.n; i++)
        {
            for (int j = 0; j < mat1.m; j++)
            {
                if (mat1.IntArray[i, j] < mat2.IntArray[i, j])
                    return false;
            }
        }
        return true;
    }

    public static bool operator <(MatrixInt mat1, MatrixInt mat2)
    {
        if (mat1.n != mat2.n || mat1.m != mat2.m)
            return false;

        for (int i = 0; i < mat1.n; i++)
        {
            for (int j = 0; j < mat1.m; j++)
            {
                if (mat1.IntArray[i, j] >= mat2.IntArray[i, j])
                    return false;
            }
        }
        return true;
    }

    public static bool operator <=(MatrixInt mat1, MatrixInt mat2)
    {
        if (mat1.n != mat2.n || mat1.m != mat2.m)
            return false;

        for (int i = 0; i < mat1.n; i++)
        {
            for (int j = 0; j < mat1.m; j++)
            {
                if (mat1.IntArray[i, j] > mat2.IntArray[i, j])
                    return false;
            }
        }
        return true;
    }

    public void DisplayMatrix()
    {
        Console.WriteLine($"Matrix Elements (Size: {n}x{m}):");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"{IntArray[i, j]} ");
            }
            Console.WriteLine();
        }
    }
}

class Program3
{
    static void Main3(string[] args)
    {
        MatrixInt mat1 = new MatrixInt(2, 2);
        MatrixInt mat2 = new MatrixInt(2, 2, 1);

        Console.WriteLine("Matrix 1:");
        mat1.DisplayMatrix();
        Console.WriteLine("\nMatrix 2:");
        mat2.DisplayMatrix();

        Console.WriteLine("\nMatrix 1 + Matrix 2:");
        MatrixInt result = mat1 + mat2;
        result.DisplayMatrix();

        Console.WriteLine("\nIncrement Matrix 1:");
        (++mat1).DisplayMatrix();

        Console.WriteLine("\nDecrement Matrix 1:");
        (--mat1).DisplayMatrix();

        Console.WriteLine("\nMatrix 1 != Matrix 2: " + (mat1 != mat2));
        Console.WriteLine("\nMatrix 1 > Matrix 2: " + (mat1 > mat2));
    }
}
