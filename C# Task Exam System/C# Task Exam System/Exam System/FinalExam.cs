using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem
{
    public class FinalExam : Exam
    {
        public FinalExam(TimeSpan duration, Subject subject)
            : base(duration, subject) { }


        public override void ShowExam()
        {
            Console.WriteLine("Final Exam");
            Console.WriteLine($"Subject: {Subject.Name}");
            Console.WriteLine($"Duration: {Duration.TotalMinutes} minutes");
            Console.WriteLine($"Number of Questions: {NumberOfQuestion}\n");

            int questionNumber = 1;
            int score = 0;
            int totalMarks = 0;

            foreach (var entry in Questions)
            {
                Question question = entry.Key;
                AnswerList answers = entry.Value;

                Console.WriteLine($"Q{questionNumber}: {question.Body} (Marks: {question.Marks})");

                int i = 1;
                foreach (var answer in answers)
                {
                    Console.WriteLine($"\t{i}. {answer.Text}");
                    i++;
                }

                Console.Write("Enter your answer (number): ");
                string userInput = Console.ReadLine();
                int userChoice;

                if (int.TryParse(userInput, out userChoice) &&
                    userChoice > 0 && userChoice <= answers.Count)
                {
                    if (answers[userChoice - 1].IsCorrect)
                    {
                        score += question.Marks;
                    }
                }

                totalMarks += question.Marks;
                Console.WriteLine();
                questionNumber++;
            }

            Console.WriteLine($"Your Score: {score}/{totalMarks}");
        }

    }
}
