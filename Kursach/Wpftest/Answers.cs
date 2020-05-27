namespace Wpftest
{
    public class Answers
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public int PreviousId { get; set; }

        public Answers(int id, string answer)
        {
            Id = id;
            Answer = answer;
        }
    }
}
