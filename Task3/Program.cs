// Задача 3. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.

int[,] CreateRandomArrayOfInt(int rows, int cols, int min, int max) // Создает двумерный массив с заданой размерностью и границами генерации целых чисел
{
    int[,] temp = new int[rows, cols];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            temp[i, j] = new Random().Next(min, max + 1);
        }
    }
    return temp;
}

void PrintArrayOfInt(int[,] array) // Печать двумерного массива целых чисел
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

double CalculateAverageOfArray(int[] array) // Находит среднеарифметическое по одномерному массиву
{
    double temp = array[0] * 1.0;
    for (int i = 1; i < array.Length; i++)
    {
        temp += array[i] * 1.0;
    }
    temp /= array.Length;
    temp = Math.Round(temp, 2);
    return temp;
}

int[] TakeColumnFromArray(int[,] array, int col) // Выделяет конкретный столбец в отдельный одномерный массив
{
    int[] temp = new int[array.GetLength(0)];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        temp[i] = array[i, col];
    }
    return temp;
}

double[] CalculateAverageForAllColumns(int[,] array) // Вычислить среднеарифметическое для каждого столбца двумерного массива
{
    double[] temp = new double[array.GetLength(1)];
    for (int j = 0; j < array.GetLength(1); j++)
    {
        temp[j] = CalculateAverageOfArray(TakeColumnFromArray(array, j));
    }
    return temp;
}

void PrintAverageForAllColumns(double[] array) // Вывести на экран думерный массив вещественных чисел с выводом ограничителя сверху
{
    System.Console.WriteLine("------------------------------");
    System.Console.Write($"{array[0]}\t");
    for (int i = 1; i < array.Length; i++)
    {
        System.Console.Write($"{array[i]}\t");
    }
}

void Execute() // Основное тело программы
{
    System.Console.Clear();
    System.Console.WriteLine("Данная программа генерирует массив из целых чисел и выводит среднеарифметическое элементов каждого столбца.");

    // === Блок с константами для удобного управления параметрами массива ===
    const int rowsInArray = 4;
    const int colsInArray = 3;
    const int minOfRandom = -5;
    const int maxOfRandom = 5;
    // === Конец блока констант ===

    int[,] arrayOfInt = CreateRandomArrayOfInt(rowsInArray, colsInArray, minOfRandom, maxOfRandom);
    PrintArrayOfInt(arrayOfInt);
    PrintAverageForAllColumns(CalculateAverageForAllColumns(arrayOfInt));
}

Execute();