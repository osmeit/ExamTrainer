namespace ExamTrainer.Models
{
    public class Anwser
    {
        public int id { get; set; }

        public string Text { get; set; }

        public bool isCorrect { get; set; }

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
}
