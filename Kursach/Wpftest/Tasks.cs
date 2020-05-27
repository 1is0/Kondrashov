namespace Wpftest
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public string TaskId { get; set; }
        public int Current { get; set; }
        public int CorrectAnswer { get; set; }
        public int UserAnswer { get; set; }

        public Tasks(int id, string value, int current, int correct)
        {
            Id = id;
            Task = value;
            TaskId = current.ToString() + "." + " " + Task;
            UserAnswer = -1;
            CorrectAnswer = correct;
        }
    }
}
