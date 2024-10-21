using System;
using System.Text.RegularExpressions;

namespace JournalClass
{
    internal class Journal
    {
        private string name;
        private string description;
        private int year;
        private string phoneNumber;
        private string email;
        private int employersCount;

        public string Name
        {
            get { return name; }
            set
            {
                try
                {
                    if (!(string.IsNullOrEmpty(value)))
                    {
                        name = value;
                    }
                    else
                        throw new ArgumentException("Имя не может быть пустым");
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        public string Description
        {

            get { return description; }
            set
            {
                try
                {
                    if (!string.IsNullOrEmpty(value))
                        description = value;
                    else
                        throw new ArgumentException("Описание не может быть пустым");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        public int Year
        {
            get { return year; }
            set
            {
                try
                {
                    if (value > 1900)
                        year = value;
                    else
                        throw new ArgumentException("Год должен быть выше 1900");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                try
                {
                    if (Regex.IsMatch(value, @"^\d{12}$"))

                        phoneNumber = value;
                    else
                        throw new ArgumentException("Формат номера неверен");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                try
                {
                    if (Regex.IsMatch(value, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                        email = value;
                    else
                        throw new ArgumentException("Email в неверном формате");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public int EmployersCount
        {
            get { return employersCount; }
            set
            {
                try
                {
                    if (value >= 0)
                    {
                        employersCount = value;
                    }
                    else
                    {
                        throw new ArgumentException("Количество сотрудников не может быть отрицательным");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public Journal(string name, string description, int year, string phoneNumber, string email)
        {
            Name = name;
            Description = description;
            Year = year;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public void Print()
        {
            Console.WriteLine("Name - {0}\nDescription - {1}\nYear - {2}\nPhone number - {3}\nEmail - {4}\n\n", Name, Description, Year, PhoneNumber, Email);
        }

        public static Journal operator +(Journal obj, int num)
        {
            obj.EmployersCount += num;
            return obj;
        }
        public static Journal operator +(int num, Journal obj)
        {
            obj.EmployersCount += num;
            return obj;
        }

        public static Journal operator -(Journal obj, int num)
        {
            try
            {
                if (obj.EmployersCount - num >= 0)
                {
                    obj.EmployersCount -= num;
                }
                else
                {
                    obj.EmployersCount = 0;
                    throw new Exception("Количество сотрудников не может быть отрицательным.");
                }

            }catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return obj;

        }

        public static bool operator == (Journal obj1, Journal obj2)
        {
            return obj1.EmployersCount == obj2.EmployersCount;
        }

        public static bool operator !=(Journal obj1, Journal obj2)
        {
            return obj1.EmployersCount != obj2.EmployersCount;
        }

        public static bool operator >(Journal obj1, Journal obj2)
        {
            return obj1.EmployersCount> obj2.EmployersCount;
        }

        public static bool operator <(Journal obj1, Journal obj2)
        {
            return obj1.EmployersCount < obj2.EmployersCount;
        }

    }
}
