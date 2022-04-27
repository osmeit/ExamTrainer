using System.ComponentModel.DataAnnotations.Schema;

namespace ExamTrainer.Models;

public class Question
{
    public int id { get; set; }

    [ForeignKey("Exam")]
    public int ExamId { get; set; }

    public string Text { get; set; }

    public List<Anwser>? Anwsers { get; set; }

    public Question()
    {
        this.Anwsers = new List<Anwser>();
    }

    public Question(string text)
    {
        this.Text = text;
        this.Anwsers = new List<Anwser>();
    }



}
