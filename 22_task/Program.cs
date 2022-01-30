using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22_task
{
    class Program
    {
        static int ArraySum(int[] array)
        {
            return array.Sum();                   
        }

        static int ArrayMaxN(Task task, object array_n)
        {
            int[] max = (int[])array_n;            
            return max.Max();
        }
        static void Main(string[] args)
        {
            Console.Write("Введите размер массива: ");
            int array_n = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[array_n];
            Random random = new Random();

            for (int i = 0; i < array_n; i++)
            {
                array[i] = random.Next(-10, 20);
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
            Console.WriteLine();

            Func<int> funk_s = new Func<int>(() => ArraySum(array));
            Task<int> task_s = new Task<int>(funk_s);
            task_s.Start();
            Console.WriteLine($"Сумма чисел массива: {task_s.Result}");

            Func<Task, object, int> funk_m = new Func<Task, object, int>(ArrayMaxN);
            Task<int> task_m = task_s.ContinueWith<int>(funk_m, array);
            Console.WriteLine($"Максимальное число в массиве : {task_m.Result}");
                       
            Console.ReadKey();
        }
    }
}
