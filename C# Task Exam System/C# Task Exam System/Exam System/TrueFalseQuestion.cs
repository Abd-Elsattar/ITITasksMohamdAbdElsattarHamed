using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem
{
    public class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string header, string body, int marks)
            : base(header, body, marks) { }


        public override void Show()
        {
            Console.WriteLine(ToString());
            Console.WriteLine("1. True");
            Console.WriteLine("1. False");
        }
    }
}
