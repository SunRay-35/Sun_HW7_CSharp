// Задача 1. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.

// m = 3, n = 4.
// 0,5 7 -2 -0,2
// 1 -3,3 8 -9,9
// 8 7,8 -7,1 9

(int rowCount, int colCount) PromptDimensionsOfArray(string message) // Ввод координат через пробел
{
    System.Console.Write(message);
    string temp = System.Console.ReadLine();
    var dimensionValue = temp.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    int rows = Convert.ToInt32(dimensionValue[0]);
    int cols = Convert.ToInt32(dimensionValue[1]);
    return (rows, cols);
}

double GenerateRandomDouble(int min, int max, int accuracy) // Генерирует случайное вещественное число в заданных целых границах.
{
    double temp = new Random().Next(min, max + 1);
    if (temp > 0) temp -= new Random().NextDouble();
    else temp += new Random().NextDouble();
    return Math.Round(temp, accuracy);
}

double[,] CreateRandomArrayOfDouble(int rows, int cols, int min, int max, int accuracy) // Создаем двумерный массив с заданой размерностью и границами генерации случайных вещественных чисел
{
    double[,] temp = new double[rows, cols];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            temp[i, j] = GenerateRandomDouble(min, max, accuracy);
        }
    }
    return temp;
}

void PrintArrayOfDouble(double[,] array) // Печать двумерного массива вещественных чисел
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        System.Console.Write($"{array[i, 0]}\t");
        for (int j = 1; j < array.GetLength(1); j++)
        {
            System.Console.Write($"{array[i, j]}\t");
        }
        System.Console.WriteLine();
    }
}

void Execute() // Основное тело программы
{
    System.Console.Clear();
    System.Console.WriteLine("Данная программа получает на вход размеры двумерного массива M и N и заполняет его случайными вещественными числами.");
    var dimensionsOfArray = PromptDimensionsOfArray("Введите количество строк M и столбцов N через пробел. Например:5 2 -> ");
    double[,] arrayOfDouble = CreateRandomArrayOfDouble(dimensionsOfArray.rowCount, dimensionsOfArray.colCount, -10, 10, 2);
    PrintArrayOfDouble(arrayOfDouble);
}

Execute();