using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    // Создайте абстрактный класс Гражданин. Создайте классы Студент, Пенсионер, Рабочий
    // унаследованные от Гражданина.
    public abstract class Citizen
    {
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Passport { get; protected set; }


        public Citizen(string firstName, string lastName, string passport)
        {
            if (string.IsNullOrEmpty(passport))
            {
                Console.WriteLine("Гражданин без паспорта - не гражданин!!!");
                return;
            }
            FirstName = firstName;
            LastName = lastName;
            Passport = passport;
        }

        public override int GetHashCode()
        {
            return Passport.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var otherCitizen = obj as Citizen;

            return otherCitizen?.Passport == Passport;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} with passport: {Passport}";
        }
    }

    class Student : Citizen
    {
        public Student(string firstName, string lastName, string passport)
            : base(firstName, lastName, passport) { }
    }
    class Worker : Citizen
    {
        public Worker(string firstName, string lastName, string passport)
            : base(firstName, lastName, passport) { }
    }
    class Pensioner : Citizen
    {
        public Pensioner(string firstName, string lastName, string passport)
            : base(firstName, lastName, passport) { }
    }
}
