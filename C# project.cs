using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

#region Enums
public enum ExamMode
{
    Queued,
    Starting,
    Finished
}
#endregion

#region Answer
public class Answer
{
    public string Text { get; set; }
    public bool IsCorrect { get; set; }

    public Answer(string text, bool isCorrect = false)
    {
        Text = text;
        IsCorrect = isCorrect;
    }

    public override string ToString() => Text;
}

public class AnswerList : List<Answer> { }
#endregion

#region Question
public abstract class Question
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

    public abstract void ShowQuestion();
    public abstract List<int> GetStudentAnswer();
}

public class TrueFalseQuestion : Question
{
    public TrueFalseQuestion(string header, string body, int marks) : base(header, body, marks)
    {
        Answers.Add(new Answer("True"));
        Answers.Add(new Answer("False"));
    }

    public override void ShowQuestion()
    {
        Console.WriteLine($"{Header}: {Body} ({Marks} Marks)");
        for (int i = 0; i < Answers.Count; i++)
            Console.WriteLine($"{i + 1}. {Answers[i].Text}");
    }

    public override List<int> GetStudentAnswer()
    {
        while (true)
        {
            Console.Write("Choose 1 or 2: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && (choice == 1 || choice == 2))
                return new List<int> { choice - 1 };
            Console.WriteLine("Invalid input. Try again.");
        }
    }
}

public class ChooseOneQuestion : Question
{
    public ChooseOneQuestion(string header, string body, int marks) : base(header, body, marks) { }

    public override void ShowQuestion()
    {
        Console.WriteLine($"{Header}: {Body} ({Marks} Marks)");
        for (int i = 0; i < Answers.Count; i++)
            Console.WriteLine($"{i + 1}. {Answers[i].Text}");
    }

    public override List<int> GetStudentAnswer()
    {
        while (true)
        {
            Console.Write($"Choose 1-{Answers.Count}: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= Answers.Count)
                return new List<int> { choice - 1 };
            Console.WriteLine("Invalid input. Try again.");
        }
    }
}

public class ChooseAllQuestion : Question
{
    public ChooseAllQuestion(string header, string body, int marks) : base(header, body, marks) { }

    public override void ShowQuestion()
    {
        Console.WriteLine($"{Header}: {Body} ({Marks} Marks)");
        for (int i = 0; i < Answers.Count; i++)
            Console.WriteLine($"{i + 1}. {Answers[i].Text}");
    }

    public override List<int> GetStudentAnswer()
    {
        while (true)
        {
            Console.Write($"Choose all correct options (comma separated 1-{Answers.Count}): ");
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) continue;

            var parts = input.Split(',');
            List<int> choices = new List<int>();
            bool valid = true;

            foreach (var p in parts)
            {
                if (int.TryParse(p.Trim(), out int idx) && idx >= 1 && idx <= Answers.Count)
                    choices.Add(idx - 1);
                else { valid = false; break; }
            }

            if (valid) return choices;
            Console.WriteLine("Invalid input. Try again.");
        }
    }
}
#endregion

#region QuestionList
public class QuestionList : List<Question>
{
    private readonly string FilePath;
    public QuestionList(string filePath) => FilePath = filePath;

    public new void Add(Question q)
    {
        base.Add(q);
        using (StreamWriter sw = new StreamWriter(FilePath, true))
            sw.WriteLine($"{q.Header}: {q.Body} ({q.Marks} Marks)");
    }
}
#endregion

#region Subject & Student
public class Subject
{
    public string Name { get; set; }
    public QuestionList Questions { get; set; }
    public List<Student> Students { get; set; }

    public Subject(string name, string filePath)
    {
        Name = name;
        Questions = new QuestionList(filePath);
        Students = new List<Student>();
    }
}

public class Student
{
    public string Name { get; }
    public Student(string name) => Name = name ?? throw new ArgumentNullException(nameof(name));
}
#endregion

#region Exam
public abstract class Exam
{
    public int Time { get; set; }
    public ExamMode Mode { get; set; }
    public Subject Subject { get; set; }

    protected Exam(int time, Subject subject)
    {
        Time = time;
        Subject = subject;
        Mode = ExamMode.Queued;
    }

    public abstract void StartExam();
}

public class PracticeExam : Exam
{
    public PracticeExam(int time, Subject subject) : base(time, subject) { }

    public override void StartExam()
    {
        Mode = ExamMode.Starting;
        Console.WriteLine("Exam Started!\n");

        int totalMarks = 0;
        int studentScore = 0;

        foreach (var q in Subject.Questions)
        {
            q.ShowQuestion();
            var studentAns = q.GetStudentAnswer();

            totalMarks += q.Marks;

            bool correct = false;
            if (q is ChooseAllQuestion)
            {
                correct = studentAns.Count == q.Answers.Count(a => a.IsCorrect)
                          && studentAns.All(idx => q.Answers[idx].IsCorrect);
            }
            else
            {
                correct = studentAns.All(idx => q.Answers[idx].IsCorrect);
            }

            if (correct) studentScore += q.Marks;
            Console.WriteLine();
        }

        Mode = ExamMode.Finished;

        Console.WriteLine($"Your Total Score: {studentScore} / {totalMarks}");
        Console.WriteLine("\nExam Finished ! ");
    }
}
#endregion

#region Main
class Program
{
    static void Main()
    {
        Subject subject = new Subject("C# Basics", "CSharpQuestions.txt");

        var q1 = new TrueFalseQuestion("Q1", "C# is an object-oriented language?", 5);
        q1.Answers[0].IsCorrect = true;
        subject.Questions.Add(q1);

        var q2 = new ChooseOneQuestion("Q2", "Which type is used for decimal numbers in C#?", 5);
        q2.Answers.Add(new Answer("int"));
        q2.Answers.Add(new Answer("double", true));
        q2.Answers.Add(new Answer("string"));
        subject.Questions.Add(q2);

        var q3 = new ChooseAllQuestion("Q3", "Select C# keywords:", 10);
        q3.Answers.Add(new Answer("class", true));
        q3.Answers.Add(new Answer("namespace", true));
        q3.Answers.Add(new Answer("function"));
        q3.Answers.Add(new Answer("static", true));
        subject.Questions.Add(q3);

        Console.Write("Enter Student Name: ");
        string? name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name)) { Console.WriteLine("Invalid name!"); return; }

        subject.Students.Add(new Student(name));

        PracticeExam exam = new PracticeExam(60, subject);
        exam.StartExam();
    }
}
#endregion