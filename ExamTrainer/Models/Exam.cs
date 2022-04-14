namespace ExamTrainer.Models
{
    public class Exam
    {
        public int id { get; set; }

        public string Name { get; set; }

        public List<Question>? Questions { get; set; }


        public Exam()
        {
            this.Questions = new List<Question>();
        }

        public Exam(string name) { 
            this.Name = name; 
            this.Questions = new List<Question>();
        }
    }

    
}
