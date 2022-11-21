// Задача 2. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 17 -> такого числа в массиве нет

(int rowNum, int colNum) PromptCoordinatesOfArray(string message) // Ввод координат через пробел
{
    System.Console.Write(message);
    string temp = System.Console.ReadLine();
    var dimensionValue = temp.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    int row = Convert.ToInt32(dimensionValue[0]);
    int col = Convert.ToInt32(dimensionValue[1]);
    return (row, col);
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

bool IsElementInArray(double[,] array, int row, int col) // Проверка по адресу наличия элемента в двумерном массиве (нумерация строк и столбцов начинается с 0)
{
    if (row >= 0 && col >= 0 && row < array.GetLength(0) && col < array.GetLength(1)) return true;
    else return false;
}

void PrintElementOfArray(double[,] array, int row, int col) // Вывод элемента двумерного массива по адресу (нумерация строк и столбцов начинается с 0)
{
    if (IsElementInArray(array, row, col))
    {
        System.Console.WriteLine($"Значение элемент массива с адресом [{row + 1}, {col + 1}] равно {array[row, col]}");
    }
    else
    {
        System.Console.WriteLine($"В массиве нет элемента с адресом [{row + 1}, {col + 1}]");
    }
}

void Execute() // Основное тело программы
{
    System.Console.Clear();
    System.Console.WriteLine("Данная программа получает на вход координаты элемента массива и возвращает значение этого элемента.");

    // === Блок с константами для удобного управления параметрами массива ===
    const int rowsInArray = 5;
    const int colsInArray = 8;
    const int minOfRandom = -10;
    const int maxOfRandom = 10;
    const int accuracyOfRound = 2;
    // === Конец блока констант ===

    double[,] arrayOfDouble = CreateRandomArrayOfDouble(rowsInArray, colsInArray, minOfRandom, maxOfRandom, accuracyOfRound);
    PrintArrayOfDouble(arrayOfDouble);

    var dimensionsOfArray = PromptCoordinatesOfArray("Введите адрес интересующего вас элемента через пробел (нумерация начинается с 1). Например:5 2 -> ");
    PrintElementOfArray(arrayOfDouble, dimensionsOfArray.rowNum - 1, dimensionsOfArray.colNum - 1);
}

Execute();