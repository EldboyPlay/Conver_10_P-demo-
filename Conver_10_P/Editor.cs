using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Конвертор
{
    class Editor
    {
        private string number = "";
        private const string delim = ".";
        private const string zero = "0";
        private int radix;

        public Editor(int radix)
        {
            if (radix < 2 || radix > 16)
                throw new ArgumentOutOfRangeException("radix", "Основание системы счисления должно быть в диапазоне от 2 до 16.");

            this.radix = radix;
        }

        public string Number
        {
            get { return number; }
        }

        public string AddDigit(int n)
        {
            if (n < 0 || n >= radix)
                throw new ArgumentOutOfRangeException("n", $"Цифра должна быть в диапазоне от 0 до {radix - 1}.");

            number += Convert.ToString(n, radix).ToUpper();
            return number;
        }

        public string AddZero()
        {
            number += zero;
            return number;
        }

        public string AddDelim()
        {
            if (!number.Contains(delim))
            {
                number += delim;
            }
            return number;
        }

        public string Bs()
        {
            if (number.Length > 0)
            {
                number = number.Remove(number.Length - 1);
            }
            return number;
        }

        public string Clear()
        {
            number = "";
            return number;
        }

        public string DoEdit(int commandNumber)
        {
            switch (commandNumber)
            {
                case 0:
                    return AddZero();
                case 1:
                    return AddDelim();
                // Добавление цифр от 1 до 16, если они соответствуют основанию системы счисления.
                case int n when (n >= 2 && n <= 17):
                    if (n - 2 < radix)
                    {
                        return AddDigit(n - 2);
                    }
                    else
                    {
                        throw new ArgumentException($"Цифра {n - 2} не поддерживается в системе счисления с основанием {radix}.");
                    }
                case 18:
                    return Bs();
                case 19:
                    return Clear();
                default:
                    throw new ArgumentException("Неизвестный номер команды.");
            }
        }

    }
}

