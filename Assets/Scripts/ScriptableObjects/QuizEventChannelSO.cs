using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/QuizEventChannel")]
public class QuizEventChannelSO : ScriptableObject
{
    public struct Quiz
    {
        public string Question;
        public string FirstAnswer;
        public string SecondAnswer;
        public string ThirdAnswer;
        public string CorrectAnswer;
    }

    public Action<Quiz> OnEventRaised;

    public void RaiseEvent(Quiz quiz)
    {
        OnEventRaised?.Invoke(quiz);
    }
}
