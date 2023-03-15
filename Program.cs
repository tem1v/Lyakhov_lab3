using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyakhov_lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Vector a = new Vector(3);
            a.Random_elems(-1, 1);
            Console.WriteLine("Вектор a = " + a.ToString());

            Vector b = new Vector(3);
            b.Random_elems(-1, 1);
            Console.WriteLine("Вектор b = " + b.ToString());

            // Cуммa a и b
            Vector c = Vector.Add(a, b);
            Console.WriteLine("Сумма векторов a и b = " + c.ToString());

            //Cкалярное произведение a и b 
            double product = Vector.Scal_prod(a, b);
            Console.WriteLine("Скалярное произведение векторов a и b = " + product);

            // Проверим, равны ли a и b
            bool equal = Vector.Equals(a, b);
            Console.Write("Равны ли a и b? ");
            if (equal)
            {
                Console.WriteLine("Да");
            }
            else
            {
                Console.WriteLine("Нет");
            }
            //Модуль a
            double module = a.Module();
            Console.WriteLine("Значение |a| = " + module);

            //Наибольший элемент a
            double largest = a.Max_elem();
            Console.WriteLine("Наибольший элемент a = " + largest);

            //индекс наименьшего элемента из a
            int smallestIndex = a.Min_elem_index();
            Console.WriteLine("Индекс наименьшего элемента из a = " + smallestIndex);

            //вектор из положительных элементов a
            Vector d = a.Positive_elems();
            Console.WriteLine("Вектор d(состоящий только из положительных элементов a) = " + d.ToString());

            // Получаем элемент с индексом 1 из a
            double element = a.Get(1);
            Console.WriteLine("Выводим элемент с индексом 1 из a = " + element);

            // Изменяем элемент с индексом 1 в a на 0,4
            a.Set(1, 0.4);

            // Выводим измененный вектор в консоль
            Console.WriteLine("Измененный вектор a(элемент с индексом 1 заменили на 0,4) = " + a.ToString());

            // Линейный поиск значения 0,4 в a
            int searchIndex = a.LinearSearch(0.4);
            Console.WriteLine("(Линейный поиск)Индекс 0,4 в a = " + searchIndex);
            
            // Отсортирован ли a в порядке возрастания
            bool sorted = a.IsSorted();
            Console.Write("Отсортирован ли a в порядке возрастания? ");
            if (sorted)
            {
                Console.WriteLine("Да");
            }
            else
            {
                Console.WriteLine("Нет");
            }

            // Бинарный поиск значения 0,4 в a
            int search = a.BinarySearch(0.4);
            Console.WriteLine("(Бинарный поиск)Индекс 0,4 в a = " + search);

            // Проверяем, есть ли в массиве хотя бы 1 0 
            bool isZero = a.Zeros(1);
            Console.WriteLine("Есть ли хотя бы один 0? " + isZero);
            
            // Сортировка Шелла
            Vector e = new Vector(5);
            e.Random_elems(1.0, 5);
            Console.WriteLine("Заданный вектор: " + e);
            e.ShellSort();
            Console.WriteLine("Сортировка Шелла: " + e);
            
            // Сдвиг элементов вектора на заданное число позиций вправо, освободившиеся элементы заполняются нулями
            Vector f = new Vector(5);
            f.Random_elems(1.0, 5);
            Console.WriteLine("Заданный вектор:"+f.ToString());
            f.ShiftRight();
            Console.WriteLine("Сдвинутый вектор: "+f.ToString());
            Console.ReadLine();
        }
    }
}
