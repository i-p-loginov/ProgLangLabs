using System.ComponentModel.DataAnnotations;

namespace Task01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Часть 1:");
            Console.Write("Введите размер массива: ");

            int size = int.Parse(Console.ReadLine());

            var firstPart = new FirstPart(size);
            
            Console.WriteLine("Исходный массив: ");
            PrintVector(firstPart.Vector);

            Console.WriteLine("Сумма отрицательных: " + firstPart.GetSumOfNegativeElements());
            Console.WriteLine("Произведение между Min & Max: " + firstPart.GetMultiplicationBetweenMinMax());

            firstPart.SortByAscending();
            Console.WriteLine("После сортировки по возрастанию:");
            PrintVector(firstPart.Vector);

            Console.WriteLine("Часть 2:");
            
            var secondPart = new SecondPart(4, 5);
            PrintMatrix(secondPart.Matrix);

            var maxRepeating = secondPart.GetMaxRepeatingNumber();
            Console.WriteLine("Наибольшее повторяющееся число: " + maxRepeating ?? "нет повторяющихся");

            Console.WriteLine("Строк без нулей: " + secondPart.GetRowsWithoutZerosCount());
        }

        static void PrintVector(IEnumerable<int> vector)
        {
            Console.WriteLine(string.Join(" ", vector));
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(" ", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}