using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public int StudentId { get; set; }
    public string Surname { get; set; }
    public string GroupName { get; set; }
}

public class Group
{
    public string GroupName { get; set; }
    public string Faculty { get; set; }
    public int Course { get; set; }
}

public class Club
{
    public string ClubName { get; set; }
    public int StudentId { get; set; }
}

class Program
{
    static void Main()
    {
        var students = new List<Student>
        {
            new Student { StudentId = 1, Surname = "Іваненко", GroupName = "1" },
            new Student { StudentId = 2, Surname = "Петренко", GroupName = "1" },
            new Student { StudentId = 3, Surname = "Сидоренко", GroupName = "1" },
            new Student { StudentId = 4, Surname = "Коваленко", GroupName = "2" },
            new Student { StudentId = 5, Surname = "Бондаренко", GroupName = "2" },
            new Student { StudentId = 6, Surname = "Мельник", GroupName = "2" },
            new Student { StudentId = 7, Surname = "Шевченко", GroupName = "1" },
            new Student { StudentId = 8, Surname = "Ткаченко", GroupName = "1" },
            new Student { StudentId = 9, Surname = "Кравченко", GroupName = "2" },
            new Student { StudentId = 10, Surname = "Олійник", GroupName = "2" },

            new Student { StudentId = 11, Surname = "Мороз", GroupName = "3" },
            new Student { StudentId = 12, Surname = "Романенко", GroupName = "3" },
            new Student { StudentId = 13, Surname = "Лисенко", GroupName = "3" },
            new Student { StudentId = 14, Surname = "Гриценко", GroupName = "3" },
            new Student { StudentId = 15, Surname = "Захаренко", GroupName = "4" },
            new Student { StudentId = 16, Surname = "Даниленко", GroupName = "5" },
            new Student { StudentId = 17, Surname = "Савченко", GroupName = "4" },
            new Student { StudentId = 18, Surname = "Павленко", GroupName = "4" },
            new Student { StudentId = 19, Surname = "Марченко", GroupName = "5" },
            new Student { StudentId = 20, Surname = "Андрієнко", GroupName = "5" }
        };

        var groups = new List<Group>
        {
            new Group { GroupName = "1", Faculty = "ФМЦТ", Course = 1 },
            new Group { GroupName = "2", Faculty = "ФМЦТ", Course = 1 },

            new Group { GroupName = "1", Faculty = "ФМЦТ", Course = 2 },
            new Group { GroupName = "2", Faculty = "ФМЦТ", Course = 2 },

            new Group { GroupName = "1", Faculty = "ФМЦТ", Course = 1 },
            new Group { GroupName = "5", Faculty = "ФМЦТ", Course = 1 },

            new Group { GroupName = "3", Faculty = "ФМЦТ", Course = 2 },
            new Group { GroupName = "4", Faculty = "ФМЦТ", Course = 2 },

            new Group { GroupName = "5", Faculty = "ФМЦТ", Course = 3 }
        };

        var clubs = new List<Club>
        {
            new Club { ClubName = "Футбол", StudentId = 1 },
            new Club { ClubName = "Футбол", StudentId = 2 },
            new Club { ClubName = "Футбол", StudentId = 3 },

            new Club { ClubName = "Баскетбол", StudentId = 4 },
            new Club { ClubName = "Баскетбол", StudentId = 5 },

            new Club { ClubName = "Шахи", StudentId = 6 },

            new Club { ClubName = "Програмування", StudentId = 7 },
            new Club { ClubName = "Програмування", StudentId = 8 },
            new Club { ClubName = "Програмування", StudentId = 9 },
            new Club { ClubName = "Програмування", StudentId = 10 },

            new Club { ClubName = "Танці", StudentId = 11 },
            new Club { ClubName = "Танці", StudentId = 12 },

            new Club { ClubName = "Волейбол", StudentId = 13 },
            new Club { ClubName = "Волейбол", StudentId = 14 },
            new Club { ClubName = "Волейбол", StudentId = 15 },

            new Club { ClubName = "Театр", StudentId = 16 },

            new Club { ClubName = "Музика", StudentId = 17 },
            new Club { ClubName = "Музика", StudentId = 18 },

            new Club { ClubName = "Робототехніка", StudentId = 19 },
            new Club { ClubName = "Робототехніка", StudentId = 20 }
        };


        Console.WriteLine("Завдання A");
        Console.WriteLine("a) Вивести усі гуртки крім гуртків з найменшою кількістю учасників-другокурсників");        
        TaskA(students, groups, clubs);
        Console.WriteLine("Завдання B");
         Console.WriteLine(" b) Вивести сумарну кількість студентів 1-го курсу, які займаються у гуртках із заданими назвами");
        TaskB(students, groups, clubs);
        Console.WriteLine("Завдання C");
         Console.WriteLine("c) Вивести назви груп, для яких кількість різних гуртків найбільша");
        TaskC(students, clubs);
    }

    // a) Вивести усі гуртки крім гуртків з найменшою кількістю учасників-другокурсників
    static void TaskA(List<Student> students, List<Group> groups, List<Club> clubs)
    {
        var secondCourseClubs = clubs
            .Join(students,
                c => c.StudentId,
                s => s.StudentId,
                (c, s) => new { c.ClubName, s.GroupName })

            .Join(groups,
                cs => cs.GroupName,
                g => g.GroupName,
                (cs, g) => new { cs.ClubName, g.Course })

            .Where(x => x.Course == 2)

            .GroupBy(x => x.ClubName)

            .Select(g => new
            {
                Club = g.Key,
                Count = g.Count()
            })

            .ToList();

        int minCount = secondCourseClubs.Min(x => x.Count);

        var result = secondCourseClubs
            .Where(x => x.Count > minCount)
            .Select(x => x.Club);

        foreach (var club in result)
        {
            Console.WriteLine(club);
        }
    }

    // b) Вивести сумарну кількість студентів 1-го курсу, які займаються у гуртках із заданими назвами
    static void TaskB(List<Student> students, List<Group> groups, List<Club> clubs)
    {
        var targetClubs = new List<string>
        {
            "Футбол",
            "Програмування",
            "Робототехніка"
        };

        var result = clubs
            .Where(c => targetClubs.Contains(c.ClubName))

            .Join(students,
                c => c.StudentId,
                s => s.StudentId,
                (c, s) => new { c.ClubName, s.StudentId, s.GroupName })

            .Join(groups,
                cs => cs.GroupName,
                g => g.GroupName,
                (cs, g) => new
                {
                    cs.StudentId,
                    g.Course,
                    g.Faculty
                })

            .Where(x => x.Course == 1)

            .Select(x => x.StudentId)

            .Distinct()

            .Count();

        Console.WriteLine($"Кількість студентів: {result}");
    }

    // c) Вивести назви груп, для яких кількість різних гуртків найбільша
    static void TaskC(List<Student> students, List<Club> clubs)
    {
        var groupClubs = students
            .Join(clubs,
                s => s.StudentId,
                c => c.StudentId,
                (s, c) => new
                {
                    s.GroupName,
                    c.ClubName
                })

            .GroupBy(x => x.GroupName)

            .Select(g => new
            {
                Group = g.Key,
                ClubCount = g.Select(x => x.ClubName)
                             .Distinct()
                             .Count()
            })

            .ToList();

        int maxCount = groupClubs.Max(x => x.ClubCount);

        var result = groupClubs
            .Where(x => x.ClubCount == maxCount);

        foreach (var item in result)
        {
            Console.WriteLine($"Для {item.Group} групи  - {item.ClubCount}  різні гуртки");
        }
    }
}
