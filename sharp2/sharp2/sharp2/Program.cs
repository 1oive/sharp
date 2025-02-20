using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace GradesPrototype
{
    struct Grade
    {
        public string Subject { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }
    }

    // Определяем делегат для уведомления о добавлении новой оценки
    delegate void GradeAddedDelegate(Grade grade);

    class Program
    {
        // Объявляем поле для хранения делегата
        static GradeAddedDelegate gradeAddedHandler;

        static void Main(string[] args)
        {
            List<Grade> grades = new List<Grade>();

            // Подписываемся на событие добавления оценки
            gradeAddedHandler += OnGradeAdded;

            // Добавляем оценки
            AddGrade(grades, "Math", 85, new DateTime(2025, 1, 1));
            AddGrade(grades, "Physics", 92, new DateTime(2025, 1, 2));
            AddGrade(grades, "Chemistry", 78, new DateTime(2025, 1, 3));

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

            // Сериализация и сохранение оценок в файл
            SaveGradesToJsonFile(grades, "grades.json");
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

            // Вызываем делегат, если он назначен
            gradeAddedHandler?.Invoke(grade);
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

        // Метод для сериализации и сохранения оценок в файл
        static void SaveGradesToJsonFile(List<Grade> grades, string filePath)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(grades, new JsonSerializerOptions
                {
                    WriteIndented = true // Для удобочитаемого формата JSON
                });
                File.WriteAllText(filePath, jsonString);
                Console.WriteLine($"\nОценки успешно сохранены в файл {filePath}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении оценок в файл: {ex.Message}");
            }
        }

        // Метод, который будет вызываться при добавлении новой оценки
        static void OnGradeAdded(Grade grade)
        {
            Console.WriteLine($"\nДобавлена новая оценка: Предмет - {grade.Subject}, Оценка - {grade.Score}, Дата - {grade.Date.ToShortDateString()}");
        }
    }
}

