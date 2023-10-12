namespace Task02
{
    public class Question
    {
        private const int CountOfAnswers = 4;

        public Question(string title, int difficultiLevel, IEnumerable<Answer> answers, bool isFireproofAmountQuestion, int cost)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException(nameof(title));
            }

            if (answers == null)
            {
                throw new ArgumentNullException(nameof(answers));
            }

            if (answers.Count() != CountOfAnswers)
            {
                throw new ArgumentException($"Количество ответов не соответствует правилам игры ({CountOfAnswers} шт.).");
            }

            if (cost <= 0)
            {
                throw new ArgumentOutOfRangeException("Очки за вопросы могут быть только положительными.");
            }

            Title = title;
            DifficultyLevel = difficultiLevel;
            Answers = answers;
            FireproofAmountQuestion = isFireproofAmountQuestion;
            Cost = cost;
        }

        public string Title { get; }

        public int DifficultyLevel { get; }

        public IEnumerable<Answer> Answers { get; }

        public bool FireproofAmountQuestion { get; }

        public int Cost { get; }

        public override string ToString()
        {
            return Title;
        }
    }
}