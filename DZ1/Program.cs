using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 - Числа фибоначчи\n2 - Сумма чисел\n3 - Имя,Фамилия,Возраст");
            int.TryParse(Console.ReadLine(), out int choice);
            switch (choice)
            {
                case 1:
                    {
                        FileInfo file = new FileInfo("fibonachi.txt");
                        int[] mas;
                        if (file.Exists)
                        {
                            mas = ReadFibonachchiArrayFromFile(file);
                            WriteFibonachchiiToFile(file, mas);
                        }
                        else
                        {
                            GenerateFibonachichiAndWriteToFile(file);
                            mas = ReadFibonachchiArrayFromFile(file);
                            WriteFibonachchiiToFile(file, mas);
                        }
                        break;
                    }
                case 2:
                    {
                        FileInfo file = new FileInfo("A+B.txt");

                        if (file.Exists)
                            ReadSumFromFile(file);
                        else
                        {
                            WriteSumToFile(file);
                            ReadSumFromFile(file);
                        }

                        break;
                    }
                case 3:
                {
                    FileInfo file = new FileInfo("nastya.txt");
                    ReadFioAgeFromFile(file);
                    break;
                }
            }

            Console.ReadLine();
        }

        static void ReadFioAgeFromFile(FileInfo file)
        {
            using (StreamWriter sw = new StreamWriter(file.OpenWrite()))
            {
                sw.WriteLine("Ченцова\nАнастасия\n18");
            }

            using (StreamReader sr = new StreamReader(file.OpenRead()))
            {
                Console.WriteLine(sr.ReadToEnd());
            }
        }
        static void ReadSumFromFile(FileInfo file)
        {
            using (StreamReader sr = new StreamReader(file.OpenRead()))
            {
                string[] c = sr.ReadLine().Split(' ');
                int sum = int.Parse(c[0]) + int.Parse(c[1]);
                Console.WriteLine("Sum = " + sum);
            }
        }
        static void WriteSumToFile(FileInfo file)
        {
            using (StreamWriter sw = new StreamWriter(file.OpenWrite()))
            {
                Console.WriteLine("Введите два числа через пробел");
                sw.Write(Console.ReadLine());

            }
        }
        static void GenerateFibonachichiAndWriteToFile(FileInfo file)
        {

            using (StreamWriter sw = new StreamWriter(file.Create()))
            {
                Console.WriteLine("До какого числа считать ряд Фибоначчи?");
                int.TryParse(Console.ReadLine(), out int number);
                int sum = 0, perv = 1, vtor = 1, i = 0;
                sw.Write($"{perv} {vtor} ");
                while (number >= sum)
                {
                    sum = perv + vtor;

                    perv = vtor;
                    vtor = sum;
                    sw.Write(sum + " ");

                }
            }


        }
        static int[] ReadFibonachchiArrayFromFile(FileInfo file)
        {
            int[] mas;
            using (StreamReader fs = new StreamReader(file.OpenRead()))
            {
                string[] c = fs.ReadToEnd().Trim().Split(' ');

                mas = new int[c.Length];
                for (int i = 0; i < c.Length; i++)
                {
                    mas[i] = int.Parse(c[i]);
                }
            }

            return mas;
        }
        static void WriteFibonachchiiToFile(FileInfo file, int[] mas)
        {
            using (StreamWriter sw = file.AppendText())
            {
                int sum, perv = mas[mas.Length - 2], vtor = mas[mas.Length - 1];
                int j = mas.Length;
                while (j < mas.Length * 2)
                {
                    sum = perv + vtor;
                    perv = vtor;
                    vtor = sum;
                    sw.Write(sum + " ");
                    j++;
                }
            }
        }
    }
}
