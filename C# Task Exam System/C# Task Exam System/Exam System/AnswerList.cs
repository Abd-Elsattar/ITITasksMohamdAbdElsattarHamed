using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem
{
    public class AnswerList : List<Answer>
    {
        public AnswerList() : base() { }
        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < this.Count; i++)
            {
                result += $"{i + 1}. {this[i]}\n";
            }
            return result;
        }
    }
}
