// Задача 3. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.
int InputInt(string msg)
{
    int value;
    System.Console.Write($"{msg} -> ");
    if (int.TryParse(Console.ReadLine(), out value))
    {
        return value;
    }
    System.Console.WriteLine("Введенно неверное значение!");
    Environment.Exit(999);
    return 0;
}

int[,] GenerateArray (int row, int col, int minValue, int maxValue)
{
    int[,] result = new int[row, col];
    Random rnd = new Random();

    for (int i = 0; i < result.GetLength(0); i++)
    {
        for (int j = 0; j < result.GetLength(1); j++)
        {
            result[i, j] = rnd.Next(minValue, maxValue + 1);
        }
    }

    return result;
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            System.Console.Write($"{array[i, j]}\t");   
        }
        System.Console.WriteLine();
    }
    System.Console.WriteLine();
}

double GetAverageCol(int col, int[,] array)
{
    double sum = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        sum = sum + array[i, col];
    }
    return sum/array.GetLength(0);
}

int m = InputInt("Введите количество строк");
int n = InputInt("Введите количество столбцов");
int min = InputInt("Введите минимальный порог случайных чисел");
int max = InputInt("Введите максимальный порог случайных чисел");

int[,] matrix = GenerateArray(m, n, min, max);
PrintArray(matrix);

System.Console.Write("Среднее арифметическое каждого столбца: ");
for (int i = 0; i < matrix.GetLength(1); i++)
{
    System.Console.Write($"{GetAverageCol(i, matrix):f2}; ");
}