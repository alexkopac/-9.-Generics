using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ConsoleApp10
{
    public class PriorQueue<T>
    {
        private SortedList<int,
            Queue<T>> queue = new SortedList<int,
                Queue<T>>();

        public int Count
        {
            get { return queue.Sum(pair => pair.Value.Count); }
        }

        public void Enqueue(T item, int priority)
        {
            if (!queue.ContainsKey(priority))
            {
                queue.Add(priority,
                    new Queue<T>());
            }
            queue[priority].Enqueue(item);
        }

        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Черга порожня.");
            }

            int highestPriority = queue.Keys.First();
            T item = queue[highestPriority].Dequeue();
            if (queue[highestPriority].Count == 0)
            {
                queue.RemoveAt(0); 
            }
            return item;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Черга порожня.");
            }

            int highestPriority = queue.Keys.First();
            return queue[highestPriority].Peek();
        }

        public bool IsEmpty
        {
            get { return Count == 0; }
        }

        public void Clear()
        {
            queue.Clear();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            PriorQueue<string> taskQueue = new PriorQueue<string>();

            taskQueue.Enqueue("Завдання низького пріоритету", 3);
            taskQueue.Enqueue("Критичне завдання", 1);
            taskQueue.Enqueue("Звичайне завдання", 2);
            taskQueue.Enqueue("Ще одне завдання низького пріоритету", 3);

            Console.WriteLine("Елементи в черзі за пріоритетом:");

            while (!taskQueue.IsEmpty)
            {
                Console.WriteLine(taskQueue.Dequeue());
            }

            Console.WriteLine($"Кількість елементів у черзі після видалення: {taskQueue.Count}");

            
            taskQueue.Enqueue("Термінове завдання", 1);
            taskQueue.Enqueue("Другорядне завдання", 4);

            Console.WriteLine($"Перший елемент у черзі (без видалення): {taskQueue.Peek()}");
            Console.WriteLine($"Кількість елементів у черзі: {taskQueue.Count}");

            taskQueue.Clear();
            Console.WriteLine($"Чи порожня черга після очищення? {taskQueue.IsEmpty}");

            
            try
            {
                taskQueue.Dequeue();
            }

            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }

            try
            {
                taskQueue.Peek();
            }

            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
    }

    /*
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = 10;
            int num2 = 20;
            Console.WriteLine($"До обміну: num1 = {num1}, num2 = {num2}");
            (num2, num1) = SwapValues(num1, num2);
            Console.WriteLine($"Після обміну: num1 = {num2}, num2 = {num1}");

            string str1 = "Hello";
            string str2 = "World";
            Console.WriteLine($"До обміну: str1 = {str1}, str2 = {str2}");
            (str2, str1) = SwapValues(str1, str2);
            Console.WriteLine($"Після обміну: str1 = {str2}, str2 = {str1}");

        }

        
        public static (T b, T a) SwapValues<T>(T a, T b)
        {
            return (b, a);
        }
        

    }*/

}




