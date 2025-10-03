using ExamSystem;
using System;

namespace ExamSystem
{
    public abstract class Question : ICloneable, IComparable<Question>
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Marks { get; set; }
        public AnswerList Answers { get; set; }
        protected Question(string header, string body, int marks)
        {
            Header = header;
            Body = body;
            Marks = marks;
            Answers = new AnswerList();
        }

        public abstract void Show();

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public int CompareTo(Question? other)
        {
            return this.Marks.CompareTo(other.Marks);
        }

        public override string ToString()
        {
            return $"{Header}\n{Body}\nMarks: {Marks}\n";
        }

        public override bool Equals(object? obj)
        {
            if (obj is Question question)
            {
                return this.Header == question.Header && this.Body == question.Body;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Header,Body);
        }
    }
}