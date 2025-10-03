using System;

namespace ExamSystem
{
    public class Student
    {
        public string Name { get; set; }
        public Student(string name)
        {
            Name = name;
        }
        public void OnExamStarted(Exam exam)
        {
            Console.WriteLine($"Notification to {Name} The {exam.Subject.Name} exam has started");
        }
    }
}