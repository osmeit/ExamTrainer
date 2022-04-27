using System.ComponentModel.DataAnnotations.Schema;

namespace ExamTrainer.Models;

public class Anwser
{
    public int id { get; set; }

    [ForeignKey("Question")]
    public int QuestionId { get; set; }

    public string Text { get; set; }

    public bool isCorrect { get; set; }

    public Anwser() {    }

    public Anwser(string text)
    {
        this.Text = text;
    }

    public Anwser(string text, bool isCorrect)
    {
        this.Text = text;
        this.isCorrect = isCorrect;
    }



}
