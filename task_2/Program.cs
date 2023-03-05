// Задача 2. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.
// Например, задан массив:

// 1 4 7 2
// 5 9 2 3
// 8 4 2 4

// 1, 7 -> такого числа в массиве нет
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

void PrintArray(double[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            System.Console.Write($"{array[i, j]:f2} ");   
        }
        System.Console.WriteLine();
    }
    System.Console.WriteLine();
}

bool ValidateRowNumColNum(int RowNum, int ColNum, double[,] array)
{
    if ((RowNum > 0 && RowNum <= array.GetLength(0))
        && (ColNum > 0 && ColNum <= array.GetLength(1)))
    {
        return true;
    }
    System.Console.WriteLine($"Элемента с позицией ({RowNum}, {ColNum}) в массиве нет");
    return false;
}

double GetElement(int rowNum, int colNum, double[,] array)
{
    return array[rowNum-1, colNum-1];
}

int m = InputInt("Введите количество строк");
int n = InputInt("Введите количество столбцов");
int min = InputInt("Введите минимальный порог случайных чисел");
int max = InputInt("Введите максимальный порог случайных чисел");

double[,] matrix = GenerateArray(m, n, min, max);
PrintArray(matrix);

int rowNumber = InputInt("Введите номер строки элемента для поиска значения");
int colNumber = InputInt("Введите номер столбца элемента для поиска значения");
if (ValidateRowNumColNum(rowNumber, colNumber, matrix))
{
    System.Console.WriteLine($"Искомый элемент равен {GetElement(rowNumber, colNumber, matrix):f2}");
};