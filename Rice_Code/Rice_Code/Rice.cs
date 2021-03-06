﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rice_Code
{
    class Rice
    {

        public int DecodeRiceCode(string code, int m)
        {
            var index = code.IndexOf('0');
            var unaryCode = code.Substring(0, index + 1);
            code = code.Substring(index + 1);
            bool isPowerOf2Num = isPowerOf2Number(m);
            var quotient = unaryCode.Count(el => el == '1');
            var b = Convert.ToInt32(Math.Ceiling(Math.Log(m, 2.0)));

            if (isPowerOf2Num)
            {
                var prefixCode = code.Substring(0, b);

                return quotient * m + Binary2Int(prefixCode);
            }
            //return null;
            throw new Exception("m не степень двойки");
        }

        public string RiceCode(int n, int m)
        {
            var remainder = n % m;
            var b = Convert.ToInt32(Math.Ceiling(Math.Log(m, 2.0)));
            bool isPowerOf2Num = isPowerOf2Number(m);
            var unaryCode = UnaryCode(n / m);

            if (m == 1)
            {
                return unaryCode;
            }

            var twoPowerOfC = Convert.ToInt32(Math.Pow(2, b));

            var binary = Int2Binary(remainder);
            if (isPowerOf2Num)
            {
                if (binary.Length < b)
                {
                    var length = b - binary.Length;

                    for (int i = 0; i < length; i++)
                    {
                        binary = "0" + binary;
                    }
                }
                return unaryCode + binary;
            }

            //return null;
            throw new Exception("m не степень двойки");

        }

        private string UnaryCode(int number)
        {
            return new string('1', number) + '0';
        }

        private bool isPowerOf2Number(int m)
        {
            var i = 0;
            var number = GetPowerOf2SequenceMember(i);
            while ((i) <= m)
            {
                if (number == m)
                {
                    return true;
                }
                i++;
                number = GetPowerOf2SequenceMember(i);
            }
            return false;
        }

        private int GetPowerOf2SequenceMember(int position)
        {
            int res = 1;
            for (int i = 0; i < position; i++)
            {
                res *= 2;
            }
            return res;
        }

        private string Int2Binary(int number)
        {
            var res = "";
            if (number == 0)
            {
                return "0";
            }
            while (number != 0)
            {
                res = number % 2 + res;
                number /= 2;
            }
            return res;
        }

        private int Binary2Int(string binary)
        {
            var res = 0;
            var multiplier = 1;
            for (int i = binary.Length - 1; i >= 0; i--)
            {
                res += Convert.ToInt32(binary[i].ToString()) * multiplier;
                multiplier *= 2;
            }
            return res;
        }

    }
}
