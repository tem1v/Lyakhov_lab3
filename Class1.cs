using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lyakhov_lab3
{
    internal class Vector
    {
        
        public double[] massiv;

        public Vector(int size)
        {
            massiv = new double[size];
        }
        public Vector(params double[] massiv)
        {
            this.massiv = massiv;
        }
        public Vector(Vector vector)
        {
            this.massiv = vector.massiv;
        }

        public static Vector Input()
        {
            Console.WriteLine("Введите координаты вектора через пробел:");
            string input = Console.ReadLine();
            double[] massive = input.Split().Select(Double.Parse).ToArray();
            return new Vector(massive);
        }

        public override string ToString()
        {
            return "[" + string.Join(", ", massiv) + "]";
        }

        public double Module()
        {
            return Math.Sqrt(massiv.Sum(x => x * x));
        }

        public double Max_elem()
        {
            return massiv.Max();
        }

        public int Min_elem_index()
        {
            return Array.IndexOf(massiv, massiv.Min());
        }

        public Vector Positive_elems()
        {
            return new Vector(massiv.Where(x => x > 0).ToArray());
        }

        public static Vector Add(Vector a, Vector b)
        {
            if (a.massiv.Length != b.massiv.Length)
            {
                throw new ArgumentException("Векторы должны быть одногоа размерa");
            }
            return new Vector(a.massiv.Zip(b.massiv, (x, y) => x + y).ToArray());
        }

        public static double Scal_prod(Vector a, Vector b)
        {
            if (a.massiv.Length != b.massiv.Length)
            {
                throw new ArgumentException("Векторы должны быть одного размера");
            }
            return a.massiv.Zip(b.massiv, (x, y) => x * y).Sum();
        }

        public static bool Equals(Vector a, Vector b)
        {
            if (a.massiv.Length != b.massiv.Length)
            {
                return false;
            }
            return a.massiv.SequenceEqual(b.massiv);
        }

        public double Get(int index)
        {
            return massiv[index];
        }

        public void Set(int index, double value)
        {
            massiv[index] = value;
        }

        public void Random_elems(double a, double b)
        {
            Random rnd = new Random();
            for (int i = 0; i < massiv.Length; i++)
            {
                massiv[i] = rnd.NextDouble() * (b - a) + a;
            }
        }

        public int LinearSearch(double value)
        {
            for (int i = 0; i < massiv.Length; i++)
            {
                if (massiv[i] == value)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool IsSorted()
        {
            for (int i = 0; i < massiv.Length - 1; i++)
            {
                if (massiv[i] > massiv[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        public int BinarySearch(double value)
        {
            int left = 0;
            int right = massiv.Length - 1;
            while (left <= right)
            {
                int middle = (left + right) / 2;
                if (massiv[middle] == value)
                {
                    return middle;
                }
                else if (massiv[middle] < value)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }
            return -1;
        }

        public void ShiftRight()
        {
            Console.WriteLine("Введите кол-во позиций для сдвига вправо: ");
            int positions = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < positions; i++)
            {
                double tmp = massiv[massiv.Length-1];
                for (int j = massiv.Length-1; j !=0; j--)
                {
                    massiv[j] = massiv[j-1];
                }
                massiv[0] = tmp;
            }
            for (int i = 0; i < positions; i++)
            {
                massiv[i] = 0;
            }
        }

        public bool Zeros(int n)
        {
            int counter = 0;
            for(int i = 0; i < n; i++)
            {
                if (massiv[i] == 0)
                {
                    counter++;
                }
            }
            if(counter >= n)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ShellSort()
        {
            int j;
            int step = massiv.Length / 2;
            while (step > 0)
            {
                for (int i = 0; i < (massiv.Length - step); i++)
                {
                    j = i;
                    while ((j >= 0) && (massiv[j] > massiv[j + step]))
                    {
                        double tmp = massiv[j];
                        massiv[j] = massiv[j + step];
                        massiv[j + step] = tmp;
                        j -= step;
                    }
                }
                step = step / 2;
            }
        }
        


    }
}

