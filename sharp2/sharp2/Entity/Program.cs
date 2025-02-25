using entity;
using entity.Entities;
using Microsoft.EntityFrameworkCore;

using (ApplicationContext db = new ApplicationContext())
{
    Grade p1 = new Grade { Subject = "Math", Score = 5, Date = new DateOnly(2024, 12, 24) };
    Grade p2 = new Grade { Subject = "Phisics", Score = 4, Date = new DateOnly(2024, 12, 25) };

    
    try
    {
        db.SaveChanges();
    }
    catch (DbUpdateException ex){ 
        Console.WriteLine(ex.Message);
    }
    

    //var grades = db.grades.ToList();
    //Console.WriteLine("Список объектов:");
    //foreach (var u in grades)
    //{
    //    Console.WriteLine($"{u.Date}:{u.Subject} - {u.Score}");
    //}
}