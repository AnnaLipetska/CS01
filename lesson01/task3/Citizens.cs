using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    // Создайте непараметризированную коллекцию со следующим функционалом:

    class Citizens
    {
        Citizen[] citizens = new Citizen[0];

        //   1. Добавление элемента в коллекцию.
        //    1) Можно добавлять только Гражданина.
        //    2) При добавлении, элемент добавляется в конец коллекции.Если Пенсионер, – то в
        //    начало с учетом ранее стоящих Пенсионеров. Возвращается номер в очереди.
        //    3) При добавлении одного и того же человека(проверка на равенство по номеру
        //    паспорта, необходимо переопределить метод Equals и/или операторы равенства для
        //    сравнения объектов по номеру паспорта) элемент не добавляется, выдается
        //    сообщение.
        public int Add(Citizen citizen)
        {
            int position = -1;
            if (Contains(citizen, out position))
            {
                Console.WriteLine($"Гражданин с паспортом {citizen.Passport} уже зарегистрирован.");
            }

            else
            {
                var tempCitizens = citizens;
                citizens = new Citizen[tempCitizens.Length + 1];

                if (citizen is Pensioner)
                {
                    position = tempCitizens.Where(r => r is Pensioner).Count();

                    for (int i = 0; i < position; i++)
                    {
                        citizens[i] = tempCitizens[i];
                    }

                    for (int i = position; i < tempCitizens.Length; i++)
                    {
                        citizens[i + 1] = tempCitizens[i];
                    }
                }
                else
                {
                    tempCitizens.CopyTo(citizens, 0);
                    position = citizens.Length - 1;
                }
                citizens[position] = citizen;
            }

            return position;
        }

        //   2. Удаление
        //    1) Удаление – с начала коллекции.

        public void Remove()
        {
            if (citizens.Any())
            {
                var tempCitizens = citizens;
                citizens = new Citizen[tempCitizens.Length - 1];
                for (int i = 0; i < citizens.Length; i++)
                {
                    citizens[i] = tempCitizens[i + 1];
                }
            }
        }
        //    2) Возможно удаление с передачей экземпляра Гражданина.

        public void Remove(Citizen citizen)
        {
            int position = Array.IndexOf(citizens, citizen);
            if (position >= 0)
            {
                var tempCitizens = citizens;
                citizens = new Citizen[tempCitizens.Length - 1];
                Array.ConstrainedCopy(tempCitizens, 0, citizens, 0, position);
                Array.ConstrainedCopy(tempCitizens, position, citizens, position + 1, citizens.Length - position);
            }
        }

        //   3. Метод Contains возвращает true/false при налчичии/отсутствии элемента в коллекции и
        //    номер в очереди.
        public bool Contains(Citizen citizen, out int index)
        {
            index = Array.IndexOf(citizens, citizen);
            return index >= 0;
        }

        //   4. Метод ReturnLast возвращsает последнего чеолвека в очереди и его номер в очереди.

        public Citizen ReturnLast(out int position)
        {
            position = citizens.Length - 1;
            return citizens[position];
        }

        //   5. Метод Clear очищает коллекцию.

        public void Clear()
        {
            citizens = new Citizen[0];
        }

        //   6. С коллекцией можно работать опертаором foreach.

        public IEnumerator GetEnumerator()
        {
            return citizens.GetEnumerator();
        }
    }
}
