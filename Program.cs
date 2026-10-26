using System;

namespace Rozumatic_OOP_Practice8
{
    // ==========================================================================
    // ЗАГАЛЬНЕ ЗАВДАННЯ: КЛАС RECTANGLE (Пошук об'єкта за критерієм площі)
    // ==========================================================================
    public class Rectangle
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        // Метод обчислення площі прямокутника
        public double GetArea()
        {
            return Width * Height;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Прямокутник [{Width} x {Height}], Площа = {GetArea()}");
        }
    }

    // ==========================================================================
    // ДОМАШНЄ ЗАВДАННЯ: КЛАС STUDENT (Сортування масиву об'єктів за спаданням)
    // ==========================================================================
    public class Student
    {
        public string Name { get; set; }
        public double AverageScore { get; set; }

        public Student(string name, double averageScore)
        {
            Name = name;
            AverageScore = averageScore;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Студент: {Name,-15} | Середній бал: {AverageScore:F2}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==========================================================================");
            Console.WriteLine("  РОЗУМАТИК // ПРАКТИЧНЕ ЗАНЯТТЯ №8: МАСИВИ ОБ'ЄКТІВ КОРИСТУВАЧА");
            Console.WriteLine("==========================================================================");

            // ----------------------------------------------------------------------
            // 1. ТЕСТУВАННЯ ЗАГАЛЬНОГО ЗАВДАННЯ (Масив із 5 прямокутників)
            // ----------------------------------------------------------------------
            Console.WriteLine("\n--- 1. Робота з масивом об'єктів Rectangle ---");
            
            // Виділення пам'яті під масив посилань (елементи поки що null)
            Rectangle[] rectangles = new Rectangle[5];

            // Ініціалізація кожного елемента через оператор new у циклі (імітація введення параметрів)
            double[,] mockInputData = { { 3.0, 4.0 }, { 5.5, 2.0 }, { 8.0, 7.5 }, { 4.2, 6.1 }, { 2.0, 9.0 } };
            for (int i = 0; i < rectangles.Length; i++)
            {
                rectangles[i] = new Rectangle(mockInputData[i, 0], mockInputData[i, 1]);
                Console.Write($"Створено елемент масиву {i}: ");
                rectangles[i].PrintInfo();
            }

            // Пошук прямокутника з найбільшою площею
            Rectangle maxAreaRectangle = rectangles[0];
            for (int i = 1; i < rectangles.Length; i++)
            {
                if (rectangles[i].GetArea() > maxAreaRectangle.GetArea())
                {
                    maxAreaRectangle = rectangles[i];
                }
            }

            Console.WriteLine("\n🎯 Прямокутник з найбільшою площею:");
            maxAreaRectangle.PrintInfo();


            // ----------------------------------------------------------------------
            // 2. ТЕСТУВАННЯ ДОМАШНЬОГО ЗАВДАННЯ (Сортування масиву студентів)
            // ----------------------------------------------------------------------
            Console.WriteLine("\n--- 2. Сортування масиву об'єктів Student за спаданням балу ---");

            Student[] students = new Student[]
            {
                new Student("Іванов А.", 74.5),
                new Student("Петрова О.", 95.2),
                new Student("Сидоров М.", 62.1),
                new Student("Ковальчук В.", 88.7),
                new Student("Марченко Т.", 91.0)
            };

            Console.WriteLine("\nСписок студентів ДО сортування:");
            foreach (Student std in students)
            {
                std.PrintInfo();
            }

            // Просте сортування бульбашкою (Bubble Sort) за спаданням AverageScore
            for (int i = 0; i < students.Length - 1; i++)
            {
                for (int j = 0; j < students.Length - i - 1; j++)
                {
                    if (students[j].AverageScore < students[j + 1].AverageScore)
                    {
                        // Обмін посиланнями на об'єкти в масиві
                        Student temp = students[j];
                        students[j] = students[j + 1];
                        students[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine("\nСписок студентів ПІСЛЯ сортування (за спаданням):");
            // Використання циклу foreach як найзручнішого для перебору без зміни посилань
            foreach (Student std in students)
            {
                std.PrintInfo();
            }

            Console.WriteLine("\n✅ Практичне заняття №8 успішно виконано!");
        }
    }
}
