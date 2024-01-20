using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Конвертор
{
   public class Conver_10_P
    {
public static char int_to_Char(int n)
{
    if (n < 0 || n > 15) // Проверяем диапазон от 0 до 15 включительно
    {
        throw new ArgumentOutOfRangeException(nameof(n), "Value must be between 0 and 15.");
    }

    if (n >= 0 && n <= 9)
        return (char)('0' + n);
    else
        return (char)('A' + n - 10);
}

        public static string int_to_P(int n, int p)
        {
            if (n == 0) return "0";

            StringBuilder result = new StringBuilder();
            bool isNegative = n < 0;
            n = Math.Abs(n);

            while (n > 0)
            {
                result.Insert(0, int_to_Char(n % p));
                n /= p;
            }

            if (isNegative) result.Insert(0, '-');
            return result.ToString();
        }

        public static string flt_to_P(double n, int p, int c)
        {
            StringBuilder result = new StringBuilder();
            double fractionalPart = n - Math.Floor(n); // Получаем только дробную часть

            while (result.Length < c)
            {
                fractionalPart *= p;
                int digit = (int)fractionalPart;
                result.Append(int_to_Char(digit));
                fractionalPart -= digit;
                if (fractionalPart == 0) // Если дробная часть стала нулём, добавляем оставшиеся нули
                {
                    while (result.Length < c)
                    {
                        result.Append('0');
                    }
                }
            }

            return result.ToString();
        }


        public static string Do(double n, int p, int c)
        {
            if (p < 2 || p > 16)
                throw new ArgumentOutOfRangeException("Base must be between 2 and 16");

            int integralPart = (int)n;
            double fractionalPart = Math.Abs(n - integralPart);

            string integralResult = int_to_P(integralPart, p);
            string fractionalResult = flt_to_P(fractionalPart, p, c);

            // Добавление точки только если есть дробная часть
            return integralResult + (fractionalResult != "" ? "." + fractionalResult.TrimEnd('0') : "");
        }

    }
}

