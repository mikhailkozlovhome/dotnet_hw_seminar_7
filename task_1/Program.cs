// Задача 1. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
// m = 3, n = 4.
// 0,5 7 -2 -0,2
// 1 -3,3 8 -9,9
// 8 7,8 -7,1 9

int inputInt(string msg)
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

double[,] GenerateArray (int row, int col, int minValue, int maxValue)
{
    double[,] result = new double[row, col];
    Random rnd = new Random();

    for (int i = 0; i < result.GetLength(0); i++)
    {
        for (int j = 0; j < result.GetLength(1); j++)
        {
            result[i, j] = rnd.Next(minValue, maxValue + 1) + rnd.NextDouble();
        }
    }

    return result;
}

void printArray(double[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            System.Console.Write($"{array[i, j]:f2}\t");   
        }
        System.Console.WriteLine();
    }
    System.Console.WriteLine();
}

int m = inputInt("Введите количество строк");
int n = inputInt("Введите количество столбцов");
int min = inputInt("Введите минимальный порог случайных чисел");
int max = inputInt("Введите максимальный порог случайных чисел");

double[,] matrix = GenerateArray(m, n, min, max);
printArray(matrix);