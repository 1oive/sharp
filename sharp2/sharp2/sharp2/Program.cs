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
            // Добавляем оценки
            AddGrade(grades, "Math", 85, new DateTime(2023, 10, 1));
            AddGrade(grades, "Physics", 92, new DateTime(2023, 10, 2));
            AddGrade(grades, "Chemistry", 78, new DateTime(2023, 10, 3));

            // Выводим все оценки
            Console.WriteLine("Все оценки:");
            PrintGrades(grades);
            // Удаляем оценку по математике
            RemoveGradeBySubject(grades, "Math");
            Console.WriteLine("\nОценки после удаления оценки по математике:");
            PrintGrades(grades);
            // Ищем оценки по физике
            List<Grade> physicsGrades = FindGradesBySubject(grades, "Physics");
            Console.WriteLine("\nОценки по физике:");
            PrintGrades(physicsGrades);
        }
        // Метод для добавления оценки
        static void AddGrade(List<Grade> grades, string subject, int score, DateTime date)
        {
            Grade grade = new Grade
            {
                Subject = subject,
                Score = score,
                Date = date
            };
            grades.Add(grade);
        }
        // Метод для удаления оценки по предмету
        static void RemoveGradeBySubject(List<Grade> grades, string subject)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                if (grades[i].Subject == subject)
                {
                    grades.RemoveAt(i);
                }
            }
        }
        // Метод для поиска оценок по предмету
        static List<Grade> FindGradesBySubject(List<Grade> grades, string subject)
        {
            List<Grade> result = new List<Grade>();
            foreach (var grade in grades)
            {
                if (grade.Subject == subject)
                {
                    result.Add(grade);
                }
            }
            return result;
        }
        // Метод для вывода оценок
        static void PrintGrades(List<Grade> grades)
        {
            foreach (var grade in grades)
            {
                Console.WriteLine($"Предмет: {grade.Subject}, Оценка: {grade.Score}, Дата: {grade.Date.ToShortDateString()}");
            }
        }
    }

}