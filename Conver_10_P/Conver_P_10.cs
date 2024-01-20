using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Конвертор
{
    public static class Conver_P_10
    {
        // Преобразовать цифру в число.
        public static double char_To_num(char ch)
        {
            if (char.IsDigit(ch))
                return ch - '0';
            else if (char.IsLetter(ch) && char.ToUpper(ch) <= 'F')
                return 10 + char.ToUpper(ch) - 'A';
            else
                throw new ArgumentException("Недопустимый символ в числе.");
        }

        // Преобразовать строку в число
        public static double convert(string P_num, int P, double weight)
        {
            double result = 0;
            foreach (char ch in P_num)
            {
                result = result * P + char_To_num(ch);
            }
            return result / weight;
        }

        // Преобразовать из системы счисления с основанием P в десятичную систему.
        public static double dval(string P_num, int P)
        {
            int pointIndex = P_num.IndexOf('.');
            if (pointIndex == -1)
            {
                return convert(P_num, P, 1);
            }
            else
            {
                var integerPart = P_num.Substring(0, pointIndex);
                var fractionalPart = P_num.Substring(pointIndex + 1);
                return convert(integerPart, P, 1) + convert(fractionalPart, P, Math.Pow(P, fractionalPart.Length));
            }
        }
    }
}

