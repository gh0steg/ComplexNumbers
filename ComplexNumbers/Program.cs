using System;

namespace ComplexNumbers
{
    class Program
    {
        public static int NumNum; //количество комплексных чисел
        public static int Victim1, Victim2; // выбранные аргументы
        public static int NumDestiny; //выбранное действие
        public static ComplexNum[] ArrayComplexNum;
        public static ComplexNum CNum;
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Hello! There is complex numbers calculator!");
            Console.WriteLine("How many numbers (>1) you want to enter? [2]");
            ReadLine(1);
            InputComplex();
            StartCalc();
        }
        static void ReadLine(int param)//1 - ввод количества чисел, 2 - выбор действия
        {
            if(param==1)
            {
                SetnumNum(Console.ReadLine()); 
            }
            else
            {
                ChooseYourDestiny(Console.ReadLine());
            }
        }
        private static void SetnumNum(string numStr)
        {
            if (numStr.Length > 0)
            {
                if (int.TryParse(numStr, out NumNum)==false|| NumNum==1)
                {
                    Console.WriteLine("Введите число > 1, либо оставьте строку пустой!");
                    ReadLine(1);
                }
            }
            else
            {
                NumNum = 2; //если введенная строка пуста, задаем по умолчанию 2 числа
            }
            ArrayComplexNum = new ComplexNum[NumNum];
        }
        public static void InputComplex()
        {
            int index = 0;
            int realPart, imgPart;
            while (index < NumNum)
            {
                Console.WriteLine($"Введите действительную часть {index + 1} числа:");
                while (int.TryParse(Console.ReadLine(), out realPart) != true)
                {
                    Console.WriteLine("Ошибка ввода! Введите целое число");
                }

                Console.WriteLine($"Введите мнимую часть {index + 1} числа:");
                while (int.TryParse(Console.ReadLine(), out imgPart) != true)
                {
                    Console.WriteLine("Ошибка ввода! Введите целое число");
                }
                ArrayComplexNum[index] = new ComplexNum(realPart, imgPart);
                index++;
            }
        }
        public static void StartCalc()
        {
            Console.Clear();
            Console.WriteLine("Введены следующие числа:");
            int index=0;
            while (index < NumNum)
            {
                Console.Write($"{index + 1}: ");
                ArrayComplexNum[index].Print(1);
                index++;
            }
            Console.WriteLine();
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1: сложение");
            Console.WriteLine("2: вычитание");
            Console.WriteLine("3: умножение");
            ChooseYourDestiny(Console.ReadLine());
        }
        public static void ChooseYourDestiny(string destiny)
        {
            if (destiny.Length > 0)
            {
                if (int.TryParse(destiny, out NumDestiny) == false)//todo вставить проверку !!!
                {
                    StartCalc();
                }
                else
                {
                    ChooseYourVictims();
                }
            }
            else
            {
                StartCalc();
            }
        }

        static void ChooseYourVictims()
        {
            Console.WriteLine("Выберите первый аргумент из списка выше");
            Victim1 = TryReadLine();
            ArrayComplexNum[Victim1-1].Print(1);
            Console.WriteLine("Выберите второй аргумент из списка выше");
            Victim2 = TryReadLine();
            ArrayComplexNum[Victim2 - 1].Print(1);
            Console.WriteLine("");
            StartComputing();
        }

        static int TryReadLine()
        {
            int outParse;
            while ((int.TryParse(Console.ReadLine(), out outParse) != true) || (outParse < 0) || (outParse > ArrayComplexNum.Length))
            {
                Console.WriteLine("Выберите аргумент из списка выше!");
            }
            return outParse;
        }

        static void StartComputing()
        {
            CNum = new ComplexNum();
            switch (NumDestiny)
            {
                case 1: CNum = ArrayComplexNum[Victim1 - 1].Add(ArrayComplexNum[Victim2 - 1]);
                    break;
                case 2: CNum = ArrayComplexNum[Victim1 - 1].Sub(ArrayComplexNum[Victim2 - 1]);
                    break;
                case 3: CNum = ArrayComplexNum[Victim1 - 1].Mult(ArrayComplexNum[Victim2 - 1]);
                    break;
            }
            ShowResult();
        }

        static void ShowResult()
        {
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Результат: ");
            CNum.Print(0);
            Console.ReadLine();
        }
    }



}
