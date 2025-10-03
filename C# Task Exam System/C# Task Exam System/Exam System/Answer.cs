using System;
namespace ExamSystem
{
    public class Answer
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }

        public Answer(string text,bool isCorrect = false)
        {
            Text = text;
            IsCorrect = isCorrect;
        }

        public override string ToString()
        {
            return $"{Text} {(IsCorrect ? "(Correct)" : "")}";
        }
    }
}