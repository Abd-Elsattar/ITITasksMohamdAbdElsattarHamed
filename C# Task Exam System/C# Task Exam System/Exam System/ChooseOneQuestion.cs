using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem
{
    public class ChooseOneQuestion : Question
    {
        public ChooseOneQuestion(string header, string body, int marks)
            : base(header, body, marks) { }
        
        public override void Show()
        {
            Console.WriteLine(ToString());
            Console.WriteLine("Choose One:");
            Console.WriteLine(Answers.ToString());
        }
    }
}
