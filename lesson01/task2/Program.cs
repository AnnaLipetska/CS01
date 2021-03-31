using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    // Создайте коллекцию, в которой бы хранились наименования 12 месяцев, порядковый номер и
    // количество дней в соответствующем месяце.

    public class Months : IEnumerable, IEnumerator
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

        int position = -1;

        public object Current { get { return $"{position + 1}. {months[position]} \t: {days[position]} days"; } }

        // Реализуйте возможность выбора месяцев, как по порядковому номеру,
        // так и количеству дней в месяце, при этом результатом может быть не
        // только один месяц.
        public string this[int monthNumber]
        {
            get { return $"{monthNumber}. {months[monthNumber - 1]} : {days[monthNumber - 1]} days";                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 }
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (position < months.Length - 1)
            {
                position++;
                return true;
            }

            Reset();
            return false;
        }

        public void Reset()
        {
            position = -1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var months = new Months();
            Console.WriteLine(months[11]);

            Console.WriteLine(new string('-', 30));

            const int MAXLENGTH = 31;
            var longestMonths = months.GetMonthsByDays(MAXLENGTH);
            Console.WriteLine("Самые длинные месяцы:");
            foreach (var month in longestMonths)
            {
                Console.WriteLine(month);
            }

            Console.WriteLine(new string('-', 30));

            Console.WriteLine("Все месяцы:");
            foreach (var month in months)
            {
                Console.WriteLine(month);
            }

            Console.ReadKey();
        }
    }
}
