using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    public class GameRound
    {
        private int questionIndex = 0;

        private readonly Dictionary<Prompts, bool> prompts;

        public GameRound(Game game, DateTime gametime)
        {
            if (game == null)
            {
                throw new ArgumentNullException(nameof(game));
            }

            GameInfo = game;
            GameTime = gametime;
            CurrentQuestion = null;

            prompts = new Dictionary<Prompts, bool> {
                { Prompts.HallHelp, false },
                { Prompts.FityFity, false },
                { Prompts.CallAFriend, false }
            };
        }

        public Game GameInfo { get; }

        public DateTime GameTime { get; }

        public int Score { get; private set; }

        public Question? CurrentQuestion { get; private set; }

        public void NextQuestion()
        {
            questionIndex++;

            if (questionIndex < GameInfo.Questions.Count() - 1)
            {
                CurrentQuestion = GameInfo.Questions.ElementAt(questionIndex);
            }
            else
            {
                CurrentQuestion = null;
            }
        }

        public bool GiveAnswer(int number)
        {
            if (number < 1 || number > 4)
            {
                throw new ArgumentOutOfRangeException("Номер ответа должен быть в диапазоне [1; 4].");
            }

            if (questionIndex == 0)
            {
                throw new Exception("Игра не началась.");
            }

            if (questionIndex == GameInfo.Questions.Count() - 1)
            {
                throw new Exception("Игра завершилась");
            }

            var answer = CurrentQuestion.Answers.ElementAt(questionIndex);

            if (answer.IsCorrect)
            {
                Score += CurrentQuestion.Cost;
            }
            else
            {
                Score = 0;

                for (int i = questionIndex; i >= 1; i--)
                {
                    var question = GameInfo.Questions.ElementAt(i);
                    if (question.FireproofAmountQuestion)
                    {
                        Score = question.Cost;
                        break;
                    }
                }
            }

            return answer.IsCorrect;
        }

        public void UsePrompt(Prompts prompt)
        {
            prompts[prompt] = true;
        }

        public IEnumerable<Prompts> GetAvailablePrompts()
        {
            return prompts.Where(kvp => !kvp.Value).Select(kvp => kvp.Key).ToArray();
        }
    }
}
