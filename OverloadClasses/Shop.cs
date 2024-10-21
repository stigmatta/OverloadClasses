using JournalClass;
using System;
using System.Text.RegularExpressions;

namespace ShopClass
{
    internal class Shop
    {
        private string name;
        private string description;
        private string address;
        private string phoneNumber;
        private string email;
        private double square;

        public double Square
        {
            get { return square; }
            set
            {
                try
                {
                    if (value > 0)
                    {
                        square = value;
                    }
                    else
                        throw new ArgumentException("Площадь не может быть меньше либо равной нулю");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

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
                catch (ArgumentException ex)
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

        public string Address
        {

            get { return address; }
            set
            {
                try
                {
                    if (!string.IsNullOrEmpty(value))
                       address = value;
                    else
                        throw new ArgumentException("Адрес не может быть пустым");
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
        public Shop(string name, string description,string address, string phoneNumber, string email)
        {
            Name = name;
            Description = description;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public void Print()
        {
            Console.WriteLine("Name - {0}\nDescription - {1}\nAddress - {2}\nPhone number - {3}\nEmail - {4}\n\n", Name, Description, Address, PhoneNumber, Email);
        }

        public static Shop operator +(Shop obj, int num)
        {
            obj.Square = num;
            return obj;
        }
        public static Shop operator +(int num,Shop obj)
        {
            obj.Square = num;
            return obj;
        }

        public static Shop operator -(Shop obj, int num)
        {
            try
            {
                if (obj.Square - num >= 0)
                {
                    obj.Square -= num;
                }
                else
                {
                    obj.Square = 0;
                    throw new Exception("Количество сотрудников не может быть отрицательным.");
                }

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return obj;

        }

        public static bool operator ==(Shop obj1, Shop obj2)
        {
            return obj1.Square == obj2.Square;
        }

        public static bool operator !=(Shop obj1, Shop obj2)
        {
            return obj1.Square != obj2.Square;
        }

        public static bool operator >(Shop obj1, Shop obj2)
        {
            return obj1.Square > obj2.Square;
        }

        public static bool operator <(Shop obj1, Shop obj2)
        {
            return obj1.Square < obj2.Square;
        }
    }
}
