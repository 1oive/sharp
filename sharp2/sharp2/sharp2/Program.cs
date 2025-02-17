using System;
using System.Collections.Generic;

namespace GradesPrototype
{
    struct Grade
    {
        public string Subject;
        public int Score;
        public DateTime Date;
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Grade> grades = new List<Grade>();

            while (true)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Добавить оценку");
                Console.WriteLine("2. Удалить оценку по предмету");
                Console.WriteLine("3. Найти оценки по предмету");
                Console.WriteLine("4. Вывести все оценки");
                Console.WriteLine("5. Выход");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введите предмет: ");
                        string subject = Console.ReadLine();
                        Console.Write("Введите оценку: ");
                        int score = int.Parse(Console.ReadLine());
                        Console.Write("Введите дату (гггг-мм-дд): ");
                        DateTime date = DateTime.Parse(Console.ReadLine());

                        Grade grade = new Grade
                        {
                            Subject = subject,
                            Score = score,
                            Date = date
                        };
                        grades.Add(grade);
                        break;

                    case "2":
                        Console.Write("Введите предмет для удаления оценки: ");
                        string subjectToRemove = Console.ReadLine();
                        for (int i = 0; i < grades.Count; i++)
                        {
                            if (grades[i].Subject == subjectToRemove)
                            {
                                grades.RemoveAt(i);
                                break;
                            }
                        }
                        break;

                    case "3":
                        Console.Write("Введите предмет для поиска оценок: ");
                        string subjectToFind = Console.ReadLine();
                        List<Grade> foundGrades = new List<Grade>();
                        foreach (var g in grades)
                        {
                            if (g.Subject == subjectToFind)
                            {
                                foundGrades.Add(g);
                            }
                        }

                        Console.WriteLine("Найденные оценки:");
                        foreach (var g in foundGrades)
                        {
                            Console.WriteLine($"Предмет: {g.Subject}, Оценка: {g.Score}, Дата: {g.Date.ToShortDateString()}");
                        }
                        break;

                    case "4":
                        Console.WriteLine("Все оценки:");
                        foreach (var g in grades)
                        {
                            Console.WriteLine($"Предмет: {g.Subject}, Оценка: {g.Score}, Дата: {g.Date.ToShortDateString()}");
                        }
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }
    }
}