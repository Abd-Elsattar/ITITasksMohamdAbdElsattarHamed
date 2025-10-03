using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem
{
    public class ChooseAllQuestion : Question
    {
        public ChooseAllQuestion(string header, string body, int marks)
            : base(header, body, marks) { }
        

        public override void Show()
        {
            Console.WriteLine(ToString());
            Console.WriteLine("Choose All that apply:");
            Console.WriteLine(Answers.ToString());
        }
    }
}
