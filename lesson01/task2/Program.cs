using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    // Создайте коллекцию, в которой бы хранились наименования 12 месяцев, порядковый номер и
    // количество дней в соответствующем месяце.

    public class Months
    {
        int[] days = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        string[] months =
        {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "Octover",
            "November",
            "December"
        };

        // Реализуйте возможность выбора месяцев, как по порядковому номеру,
        // так и количеству дней в месяце, при этом результатом может быть не
        // только один месяц.
        public string this[int monthNumber]
        {
            get { return $"{monthNumber}. {months[monthNumber - 1]} : {days[monthNumber - 1].ToString()} days";                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 }
        }

        public IEnumerable<string> GetMonthsByDays(int daysNumber)
        {
            for (int i = 0; i < days.Length; i++)
            {
                if (days[i] == daysNumber)
                {
                    yield return months[i];
                }

            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var months = new Months();
            Console.WriteLine(months[11]);

            Console.WriteLine(new string('-', 30));

            const int maxMonthLengh = 31;
            var longestMonths = months.GetMonthsByDays(maxMonthLengh);
            Console.WriteLine("Самые длинные месяцы:");
            foreach (var month in longestMonths)
            {
                Console.WriteLine(month);
            }

            Console.WriteLine(new string('-', 30));

            Console.ReadKey();
        }
    }
}
