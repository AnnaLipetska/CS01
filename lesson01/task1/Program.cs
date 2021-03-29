using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    // Создайте метод, который в качестве аргумента принимает массив целых чисел
    // и возвращает коллекцию квадратов всех нечетных чисел массива.
    // Для формирования коллекции используйте оператор yield.
    class Program
    {
        static void Main(string[] args)
        {
            int[] initialArray = { 1, 5, 8, 9, 4 };

            foreach (var item in GetSquaredOddNumbers(initialArray))
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        private static IEnumerable<double> GetSquaredOddNumbers(int[] initialArray)
        {
            foreach (var item in initialArray)
            {
                if (item % 2 == 1)
                {
                    yield return Math.Pow(item, 2);
                }
            }

            // У нас на работе в основном все пользуются LINQ, так что было бы что-то типа:
            // return initialArray.Where(r => r % 2 == 1).Select(r => Math.Pow(r, 2));
        }
    }
}
