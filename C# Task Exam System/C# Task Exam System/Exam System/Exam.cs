using ExamSystem;
using System;
using System.Collections.Generic;

namespace ExamSystem
{
    public delegate void ExamStarted(Exam sender);
    public abstract class Exam : ICloneable, IComparable<Exam>
    {
        public event ExamStarted ExamStarted;
        public TimeSpan Duration { get; set; }
        public int NumberOfQuestion => Questions.Count;
        public Subject Subject { get; set; }
        public ExamMode Mode { get; set; }

        public Dictionary<Question, AnswerList> Questions { get; set; }

        protected Exam(TimeSpan duration, Subject subject)
        {
            Duration = duration;
            Subject = subject;
            Mode = ExamMode.Queued;
            Questions = new Dictionary<Question, AnswerList>();
        }

        public void AddQuestion(Question question,AnswerList answers)
        {
            Questions[question] = answers;
        }
        public void StartExam()
        {
            Mode = ExamMode.Starting;
            Console.WriteLine($"{Subject.Name} Exam is Starting");

            ExamStarted?.Invoke(this);
        }
        public void FinishExam()
        {
            Mode = ExamMode.Finished;
            Console.WriteLine("Exam finished.");
        }
        public abstract void ShowExam();

        public object Clone()
        {
            Exam copy = (Exam)this.MemberwiseClone();
            copy.Questions = new Dictionary<Question, AnswerList>(this.Questions);
            return copy;
        }

        public int CompareTo(Exam? other)
        {
            if (other == null) return 1;
            return this.Duration.CompareTo(other.Duration);
        }
        public override string ToString()
        {
            return $"Exam for {Subject.Name}, Duration: {Duration}, Questions: {NumberOfQuestion}, Mode {Mode}";
        }
        public override bool Equals(object? obj)
        {
            if (obj is Exam exam)
            {
                return this.Subject.Equals(exam.Subject) && this.Duration == exam.Duration;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Duration,Subject);
        }
    }
}