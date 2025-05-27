using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using LinQ.Models;
using static System.Formats.Asn1.AsnWriter;

var departments = new List<Department>
{
    new Department { Id = 1, Name = "Computer Science" },
    new Department { Id = 2, Name = "Mathematics" },

};

var students = new List<Student>
{
    new Student { Id = 1, Name = "Ahmed", DepartmentId = 1 },
    new Student { Id = 2, Name = "Sara", DepartmentId = 2 },
    new Student { Id = 3, Name = "Omar", DepartmentId = 1 },
    new Student { Id = 4, Name = "Ali", DepartmentId = 1 },
    new Student { Id = 5, Name = "Hassn", DepartmentId = 2 },
    new Student { Id = 6, Name = "Islam", DepartmentId = 1 },
    new Student { Id = 7, Name = "Doaa", DepartmentId = 1 },
    new Student { Id = 8, Name = "Heba", DepartmentId = 2 },
    new Student { Id = 9, Name = "Mohamed", DepartmentId = 1 },
    new Student { Id = 10, Name = "Hady", DepartmentId = 1 },
    new Student { Id = 11, Name = "Yassin", DepartmentId = 1 },
    new Student { Id = 12, Name = "Seif", DepartmentId = 2 },
    new Student { Id = 13, Name = "Nour", DepartmentId = 1 },
};
var students2 = new List<Student>
{
    new Student { Id = 1, Name = "osama", DepartmentId = 1 },
    new Student { Id = 2, Name = "Sara", DepartmentId = 2 },
    new Student { Id = 3, Name = "Omar", DepartmentId = 1 },
    
};

var grades = new List<Grade>
{
    new Grade { StudentId = 1, Subject = "Math", Score = 85 },
    new Grade { StudentId = 1, Subject = "Programming", Score = 92 },
    new Grade { StudentId = 2, Subject = "Math", Score = 88 },
    new Grade { StudentId = 2, Subject = "Programming", Score = 81 },
    new Grade { StudentId = 3, Subject = "Programming", Score = 70 },
    new Grade { StudentId = 3, Subject = "Math", Score = 60 },
    new Grade { StudentId = 4, Subject = "Math", Score = 80 },
    new Grade { StudentId = 4, Subject = "Programming", Score = 92 },
    new Grade { StudentId = 5, Subject = "Math", Score = 78 },
    new Grade { StudentId = 5, Subject = "Programming", Score = 71 },
    new Grade { StudentId = 6, Subject = "Programming", Score = 70 },
    new Grade { StudentId = 6, Subject = "Math", Score = 60 },
    new Grade { StudentId = 7, Subject = "Math", Score = 66 },
    new Grade { StudentId = 7, Subject = "Programming", Score = 82 },
    new Grade { StudentId = 8, Subject = "Math", Score = 60 },
    new Grade { StudentId = 8, Subject = "Programming", Score = 50 },
    new Grade { StudentId = 9, Subject = "Programming", Score = 51},
    new Grade { StudentId = 9, Subject = "Math", Score = 54 },
    new Grade { StudentId = 10, Subject = "Math", Score = 95 },
    new Grade { StudentId = 10, Subject = "Programming", Score = 92 },
    new Grade { StudentId = 11, Subject = "Math", Score = 96},
    new Grade { StudentId = 11, Subject = "Programming", Score = 94 },
    new Grade { StudentId = 12, Subject = "Math", Score = 40 },
    new Grade { StudentId = 12, Subject = "Programming", Score = 41 },
    new Grade { StudentId = 13, Subject = "Programming", Score = 30 },
    new Grade { StudentId = 13, Subject = "Math", Score = 60 }
  

};
var topProgrammers = grades
    .Where(g => g.Subject == "Programming" && g.Score > 80)
    .Join(students, g => g.StudentId, s => s.Id, (g, s) => s.Name)
    .OrderBy(s => s)
    .ToList();
Console.WriteLine("Students Have Score above 80:");
foreach (var name in topProgrammers)
{
    Console.WriteLine(name);
}
Console.WriteLine($"Count Of Students Have Score above 80 Is:{topProgrammers.Count()}");
Console.WriteLine($"The least student among the students who have a score above 80 Is:{topProgrammers.Min()}");
Console.WriteLine($"Any student among the students  have a score above  90 :{grades.Any(g => g.Score > 90)}");
var scoreGrades = grades.Select(g => g.Score).ToList();
Console.WriteLine($" GradeScore Contain Score 90? :{scoreGrades.Contains(90)}");
Console.WriteLine($"Sum Of GradeScore  :{scoreGrades.Sum()}");
Console.WriteLine($"Average Of GradeScore  :{scoreGrades.Average()}");
Console.WriteLine($"Min Of GradeScore  :{scoreGrades.Min()}");
Console.WriteLine($"Max Of GradeScore  :{scoreGrades.Max()}");
Console.WriteLine($"Product of GradeScore Using Aggregate  :{scoreGrades.Aggregate((acc,n) => acc * n)}");
var takeGrades = scoreGrades.TakeWhile(g => g > 80);
Console.WriteLine("Take grade more than 80");
foreach (var grade in takeGrades)
{
    Console.WriteLine(grade);
}
var skipGrades = scoreGrades.SkipWhile(g => g > 80);
Console.WriteLine("Take grade less than 80");
foreach (var grade in skipGrades)
{
    Console.WriteLine(grade);
}
var dictionaryStudents =  students.ToDictionary(s => s.Id, s=> s.Name);
Console.WriteLine("Students Dictionary:");
foreach (var student in dictionaryStudents)
{
    Console.WriteLine($"Id: {student.Key}, Name: {student.Value}");
}
var lastStudent = students.LastOrDefault();
var sindleStudent = students.SingleOrDefault(s=> s.Id == 7);
Console.WriteLine($"Last Student :{lastStudent.Name}");
Console.WriteLine($"Single student :{sindleStudent.Name}");
var firstStudent = students.FirstOrDefault();

var repeatStudents = Enumerable.Repeat(firstStudent, 2);
Console.WriteLine("Students Repeates:");

foreach (var student in repeatStudents)
{
    Console.WriteLine(student.Name);
}
var studentIds = Enumerable.Range(1, 3);

var selectedStudents = students.Where(s => studentIds.Contains(s.Id));
Console.WriteLine("Students Based On Range:");

foreach (var student in selectedStudents)
{
    Console.WriteLine(student.Name);
}
var selectStudents = students
    .Select(s => s.Name)
    .Reverse();
Console.WriteLine(" students name :");
foreach (var student in selectStudents)
{
    Console.WriteLine(student);
}
var studentGroup = students.GroupBy(s => s.DepartmentId);
foreach (var group in studentGroup)
{
    Console.WriteLine($"Department: {group.Key}");

    foreach (var student in group)
    {
        Console.WriteLine($" - {student.Name}");
    }
}
var concatStudents = students.Concat(students2);

Console.WriteLine("Concat Result:");
foreach (var student in concatStudents)
{
    Console.WriteLine($"{student.Id} - {student.Name}");
}

