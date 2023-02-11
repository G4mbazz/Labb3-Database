using Labb3_Database.Models;

namespace Labb3_Database.Services
{
    internal class MenuClass
    {
        public static void Menu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("1. All Students Sorted \n2. Class Roster\n3. Add Employee\n4. All students Info" +
                    "\n5. All Courses \n6. Employees per department\n7. Exit");
                int.TryParse(Console.ReadLine(), out int choice);
                switch (choice)
                {
                    case 1:
                        MenuChoiceOne();
                        break;
                        case 2:
                        MenuChoiceTwo();
                        break;
                    case 3:
                        MenuChoiceThree();
                        break;
                    case 4:
                        StudentInfo.AllStudentsInfo();
                        break;
                    case 5:
                        ListCourses();
                        ReturnToMenu();
                        break;
                    case 6:
                        TeacherPerCourse();
                        break;
                    case 7:
                        isRunning = false;
                        break;
                    default:
                        break;
                }

            }
        }
        public static void TeacherPerCourse()
        {
            Labb2DbContext context = new Labb2DbContext();
            var roles = context.TblRoles;
            var departments = context.TblEmployees.GroupBy(x => x.RoleId)
                .Select(p => new { Name = p.First().Role.Role, count = p.Count() });
            foreach (var department in departments)
            {
                Console.WriteLine($"Number of employees in {department.Name}:{department.count}");
            }

            ReturnToMenu();
        }
        public static void ListCourses()
        {
            Labb2DbContext context = new Labb2DbContext();
            var courses = context.TblCourses;
            foreach (var course in courses)
            {
                Console.WriteLine($"Class ID: {course.Id}, Course: {course.CourseName}");
            }
        }
        public static void MenuChoiceOne()
        {
            Console.Write("Sort by first or last name?: ");
            string name = Console.ReadLine().ToLower();
            Console.Write("Sort by Ascending or Descending?: ");
            string ascOrDesc = Console.ReadLine().ToLower();
            if (name == "first" || name == "firstname" || name == "first name")
            {
                if (ascOrDesc == "ascending" || ascOrDesc == "asc")
                {
                    StudentInfo.FirstNameAsc();
                }
                else if (ascOrDesc == "descending" || ascOrDesc == "desc")
                {
                    StudentInfo.FirstNameDesc();
                }
            }
            else if (name == "last" || name == "lastname" || name == "last name")
            {
                if (ascOrDesc == "ascending" || ascOrDesc == "asc")
                {
                    StudentInfo.LastNameAsc();
                }
                else if (ascOrDesc == "descending" || ascOrDesc == "desc")
                {
                    StudentInfo.LastNameDesc();
                }
            }
            else
            { 
                Console.WriteLine("Invalid input"); 
            }
            ReturnToMenu();
        }
        public static void MenuChoiceTwo()
        {
            ListCourses();
            Console.Write("Please select a Course\nID: ");
            int.TryParse(Console.ReadLine(), out int courseFinder);
            StudentInfo.ClassRoster(courseFinder);
            ReturnToMenu();
        }
        public static void MenuChoiceThree()
        {
            Labb2DbContext context = new Labb2DbContext();
            var roles = context.TblRoles;
            foreach (var role in roles)
            {
                Console.WriteLine($"Role ID: {role.Id} Occupation: {role.Role}");
            }
            Console.Write("Please select a Role ID for the new employee\nID: ");
            int.TryParse(Console.ReadLine(), out int roleID);
            Console.Write("Please enter the full name of the employee\nName: ");
            string name = Console.ReadLine();
            Console.Write("Please enter the employees social security number in a 10 digit format\nYYMMDDXXXX: ");
            string ssn = Console.ReadLine();
            if (roleID >= 1 && roleID <= 3 && name != "" && ssn.Length == 10)
            {
                TblEmployee newEmployee = new TblEmployee()
                {
                    Ssn = ssn,
                    Name = name,
                    RoleId = roleID
                };
                context.TblEmployees.Add(newEmployee);
                context.SaveChanges();
                var newEmployeeRole = context.TblRoles.Where(p => p.Id == roleID);
                Console.Write($"Employee was succefully added \nID:{newEmployee.Id} \nName: {newEmployee.Name}" +
                    $"\nRole: ");
                foreach (var role in roles.Where(p=> p.Id == roleID))
                {
                    Console.Write(role.Role + "\n");
                }

            }

            ReturnToMenu();
        }
        public static void ReturnToMenu()
        {
            Console.Write("Press any key to return to menu: ");
            Console.ReadKey();
        }
    }
}
 