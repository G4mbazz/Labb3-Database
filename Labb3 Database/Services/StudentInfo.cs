using Labb3_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb3_Database.Services
{
    public class StudentInfo
    {

        public static void FirstNameAsc()
        {
            Labb2DbContext context = new Labb2DbContext();
            var students = context.TblStudents.OrderBy(p => p.FName + p.LName);
            foreach (var student in students)
            {
                Console.WriteLine($"Full Name: {student.FName} {student.LName}, ID{student.Id}");
            }
        }
        public static void LastNameAsc()
        {
            Labb2DbContext context = new Labb2DbContext();
            var students = context.TblStudents.OrderBy(p => p.LName + p.FName);
            foreach (var student in students)
            {
                Console.WriteLine($"Full Name: {student.FName} {student.LName}, ID{student.Id}");
            }

        }
        public static void FirstNameDesc()
        {
            Labb2DbContext context = new Labb2DbContext();
            var students = context.TblStudents.OrderBy(p => p.FName + p.LName).Reverse();
            foreach (var student in students)
            {
                Console.WriteLine($"Full Name: {student.FName} {student.LName}, ID{student.Id}");
            }
        }
        public static void LastNameDesc()
        {
            Labb2DbContext context = new Labb2DbContext();
            var students = context.TblStudents.OrderBy(p => p.LName + p.FName).Reverse();
            foreach (var student in students)
            {
                Console.WriteLine($"Full Name: {student.FName} {student.LName}, ID{student.Id}");
            }
        }
        public static void ClassRoster(int choice)
        {
            Labb2DbContext context = new Labb2DbContext();
            var classRoster = context.TblGrades.Where(p => p.CourseId == choice).Select(p => p.Student);
            foreach (var student in classRoster)
            {
                Console.WriteLine($"Full Name: {student.FName} {student.LName}, ID{student.Id}");
            }
        }
    }
}
