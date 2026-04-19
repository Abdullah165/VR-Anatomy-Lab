using UnityEngine;

[CreateAssetMenu(menuName = "Organs/OrganQuiz")]
public class OrganQuizSO : ScriptableObject
{
    public string Question;
    public string FirstAnswer;
    public string SecondAnswer;
    public string ThirdAnswer;
    public string CorrectAnswer;
    public QuizEventChannelSO.Quiz GetQuizData()
    {
        return new QuizEventChannelSO.Quiz
        {
            Question = this.Question,
            FirstAnswer = this.FirstAnswer,
            SecondAnswer = this.SecondAnswer,
            ThirdAnswer = this.ThirdAnswer,
            CorrectAnswer = this.CorrectAnswer,
        };
    }
}