namespace Task02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(GetQuestions());

            var round = new GameRound(game, new DateTime(2023, 10, 10));
            
        }

        static IEnumerable<Question> GetQuestions()
        {
            throw new NotImplementedException();
        }
    }
}