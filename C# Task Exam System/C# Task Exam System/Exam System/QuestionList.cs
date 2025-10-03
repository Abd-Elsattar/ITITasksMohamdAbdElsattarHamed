using System;
using System.Collections;
using System.IO;

namespace ExamSystem
{
    public class QuestionList : List<Question>
    {
        private string logFilePath;
        public QuestionList(string _logFilePath) => logFilePath = _logFilePath;

        public new void Add(Question question)
        {
            base.Add(question);

            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine("Add Question:");
                writer.WriteLine(question.ToString());
                writer.WriteLine();
            }

        }
        
    }
}