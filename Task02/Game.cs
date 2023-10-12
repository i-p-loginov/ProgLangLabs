using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    public class Game
    {
        public const int QuestionsCount = 15;

        public Game(IEnumerable<Question> questions)
        {
            if (questions == null)
            {
                throw new ArgumentNullException(nameof(questions));
            }

            if (questions.Count() != QuestionsCount)
            {
                throw new ArgumentException($"Число вопросов в коллекции ${nameof(questions)} не соответствует правилам игры.");
            }

            Questions = questions.OrderBy(q => q.DifficultyLevel);
        }

        public IOrderedEnumerable<Question> Questions { get; }
    }
}
