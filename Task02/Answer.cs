namespace Task02
{
    public class Answer
    {
        public Answer(string text, bool isCorrect = false)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            Text = text;
            IsCorrect = isCorrect;
        }

        public string Text { get; }

        public bool IsCorrect { get; }

        public override string ToString()
        {
            return Text;
        }
    }
}