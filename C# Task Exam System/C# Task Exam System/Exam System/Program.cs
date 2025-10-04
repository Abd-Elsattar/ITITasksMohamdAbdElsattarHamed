namespace ExamSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject mathSubject = new Subject(1, "Math");

            PracticeExam practiceExam = new PracticeExam(TimeSpan.FromMinutes(30), mathSubject);
            FinalExam finalExam = new FinalExam(TimeSpan.FromMinutes(30), mathSubject);

            Student st01 = new Student("Abdelsattar");
            Student st02 = new Student("Hamed");

            practiceExam.ExamStarted += st01.OnExamStarted;
            practiceExam.ExamStarted += st02.OnExamStarted;

            finalExam.ExamStarted += st01.OnExamStarted;
            finalExam.ExamStarted += st02.OnExamStarted;

            TrueFalseQuestion q01 = new TrueFalseQuestion("Basic Math", "2 + 2 = 4?", 5);
            AnswerList q01Answers = new AnswerList
    {
        new Answer("true", true),
        new Answer("false", false)
    };

            ChooseOneQuestion q02 = new ChooseOneQuestion("Multiplication", "What is 3 * 3 ?", 5);
            var q02Answers = new AnswerList
    {
        new Answer("6", false),
        new Answer("9", true),
        new Answer("12", false)
    };

            ChooseAllQuestion q03 = new ChooseAllQuestion("Even Numbers", "Which of these are even?", 5);
            var q03Answers = new AnswerList
    {
        new Answer("2", true),
        new Answer("3", false),
        new Answer("4", true),
        new Answer("5", false)
    };

            practiceExam.Questions.Add(q01, q01Answers);
            practiceExam.Questions.Add(q02, q02Answers);
            practiceExam.Questions.Add(q03, q03Answers);

            finalExam.Questions.Add(q01, q01Answers);
            finalExam.Questions.Add(q02, q02Answers);
            finalExam.Questions.Add(q03, q03Answers);

            Console.WriteLine("Select Exam Type:");
            Console.WriteLine("1. Practice Exam");
            Console.WriteLine("2. Final Exam");
            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            Exam selectedExam = null;

            if (choice == "1")
            {
                selectedExam = practiceExam;
            }
            else if (choice == "2")
            {
                selectedExam = finalExam;
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }

            if (selectedExam != null)
            {
                selectedExam.StartExam();
                selectedExam.ShowExam();   
                selectedExam.FinishExam();
            }

            Console.WriteLine("\nExam finished. Press any key to exit.");
            Console.ReadKey();
        }

    }
}
