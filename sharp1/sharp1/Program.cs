

internal class Program
{
    private static void Main(string[] args)
    {
        
            Console.Write("Введите свое имя: ");
            var name = Console.ReadLine();       // вводим имя
            Console.WriteLine($"Привет {name}");    // выводим имя на консоль

            string courseName = "";
            List<string> courses = new List<string>();
            Dictionary<string, List<string>> courseStudents = new Dictionary<string, List<string>>();
            Dictionary<string, int> courseCapacity = new Dictionary<string, int>();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Class Enrolment");
                Console.WriteLine("1. Добавить курс");
                Console.WriteLine("2. Посмотреть курс");
                Console.WriteLine("3. Удалить курс");
                Console.WriteLine("4. Записать студента на курс");
                Console.WriteLine("5. Показать список студентов на курсе");
                Console.WriteLine("6. Удалить студента из курса");
                Console.WriteLine("7. Выход");

                Console.Write("Выберите действие: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введите название курса: ");
                        courseName = Console.ReadLine();

                        if (!courses.Contains(courseName))
                        {
                            Console.Write("Введите вместимость курса: ");
                            int capacity;
                            while (!int.TryParse(Console.ReadLine(), out capacity) || capacity <= 0)
                            {
                                Console.Write("Введите корректную вместимость курса: ");
                            }

                            courses.Add(courseName);
                            courseStudents[courseName] = new List<string>();
                            courseCapacity[courseName] = capacity;
                            Console.WriteLine($"Курс '{courseName}' успешно добавлен.");
                        }
                        else
                        {
                            Console.WriteLine($"Курс '{courseName}' уже существует.");
                        }
                        break;

                    case "2":
                        Console.Write("Введите название курса: ");
                        courseName = Console.ReadLine();

                        if (courses.Contains(courseName))
                        {
                            Console.WriteLine($"Курс: {courseName}");
                            Console.WriteLine($"Вместимость: {courseCapacity[courseName]}");
                            
                        }
                        else
                        {
                            Console.WriteLine($"Курс '{courseName}' не найден.");
                        }
                        break;

                    case "3":
                        Console.Write("Введите название курса: ");
                        courseName = Console.ReadLine();

                        if (courses.Contains(courseName))
                        {
                            courses.Remove(courseName);
                            courseStudents.Remove(courseName);
                            courseCapacity.Remove(courseName);
                            Console.WriteLine($"Курс '{courseName}' успешно удален.");
                        }
                        else
                        {
                            Console.WriteLine($"Курс '{courseName}' не найден.");
                        }
                        break;

                    case "4":
                        Console.Write("Введите название курса: ");
                        courseName = Console.ReadLine();

                        if (courses.Contains(courseName))
                        {
                            if (courseStudents[courseName].Count < courseCapacity[courseName])
                            {
                                Console.Write("Введите имя студента: ");
                                string studentName = Console.ReadLine();

                                if (!courseStudents[courseName].Contains(studentName))
                                {
                                    courseStudents[courseName].Add(studentName);
                                    Console.WriteLine($"Студент '{studentName}' успешно записан на курс '{courseName}'.");
                                }
                                else
                                {
                                    Console.WriteLine($"Студент '{studentName}' уже записан на курс '{courseName}'.");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"На курс '{courseName}' нет свободных мест.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Курс '{courseName}' не найден.");
                        }
                        break;

                    case "5":
                        Console.Write("Введите название курса: ");
                        courseName = Console.ReadLine();

                        if (courseStudents.ContainsKey(courseName))
                        {
                            Console.WriteLine($"Список студентов на курсе '{courseName}':");
                            foreach (string student in courseStudents[courseName])
                            {
                                Console.WriteLine(student);
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Курс '{courseName}' не найден.");
                        }
                        break;

                    case "6":
                        Console.Write("Введите название курса: ");
                        courseName = Console.ReadLine();

                        if (courses.Contains(courseName))
                        {
                            Console.Write("Введите имя студента: ");
                            string studentName = Console.ReadLine();

                            if (courseStudents[courseName].Contains(studentName))
                            {
                                courseStudents[courseName].Remove(studentName);
                                Console.WriteLine($"Студент '{studentName}' успешно удален из курса '{courseName}'.");
                            }
                            else
                            {
                                Console.WriteLine($"Студент '{studentName}' не записан на курс '{courseName}'.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Курс '{courseName}' не найден.");
                        }
                        break;

                    case "7":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }

                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }
    }
