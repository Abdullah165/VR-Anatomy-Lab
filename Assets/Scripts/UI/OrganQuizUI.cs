using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrganQuizUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI question;
    [SerializeField] private TextMeshProUGUI firstAnswer;
    [SerializeField] private TextMeshProUGUI secondAnswer;
    [SerializeField] private TextMeshProUGUI thirdAnswer;

    [SerializeField] private QuizEventChannelSO heartQuizEventChannelSO;
    [SerializeField] private QuizEventChannelSO brainQuizEventChannelSO;
    [SerializeField] private QuizEventChannelSO lungQuizEventChannelSO;
    [SerializeField] private QuizEventChannelSO stomachQuizEventChannelSO;

    [SerializeField] private Button firstAnswerButton;
    [SerializeField] private Button secondAnswerButton;
    [SerializeField] private Button thirdAnswerButton;

    [Header("Sounds")]
    [SerializeField] private SoundEventChannelSO cheerSoundEventChannelSO;
    [SerializeField] private AudioClipSO cheerClipSO;
    [SerializeField] private SoundEventChannelSO disappointmentSoundEventChannelSO;
    [SerializeField] private AudioClipSO disappointmentClipSO;

    private string correctAnswer;
    private ColorBlock defaultColors;

    private void Start()
    {  
        if (firstAnswerButton != null)
        {
            defaultColors = firstAnswerButton.colors;
        }
    }

    private void OnEnable()
    {
        heartQuizEventChannelSO.OnEventRaised += UpdateUI;
        brainQuizEventChannelSO.OnEventRaised += UpdateUI;
        lungQuizEventChannelSO.OnEventRaised += UpdateUI;
        stomachQuizEventChannelSO.OnEventRaised += UpdateUI;
    }

    private void OnDisable()
    {
        heartQuizEventChannelSO.OnEventRaised -= UpdateUI;
        brainQuizEventChannelSO.OnEventRaised -= UpdateUI;
        lungQuizEventChannelSO.OnEventRaised -= UpdateUI;
        stomachQuizEventChannelSO.OnEventRaised -= UpdateUI;
    }

    private void UpdateUI(QuizEventChannelSO.Quiz quiz)
    {
        question.text = quiz.Question;
        firstAnswer.text = quiz.FirstAnswer;
        secondAnswer.text = quiz.SecondAnswer;
        thirdAnswer.text = quiz.ThirdAnswer;
        correctAnswer = quiz.CorrectAnswer;

        ResetButton(firstAnswerButton);
        ResetButton(secondAnswerButton);
        ResetButton(thirdAnswerButton);
    }

    private void ResetButton(Button button)
    {
        if (button != null)
        {
            button.colors = defaultColors;
            button.interactable = true;
        }
    }

    public void CheckAnswer(Button button)
    {
        if (button.GetComponentInChildren<TextMeshProUGUI>().text == correctAnswer)
        {
            ColorBlock cb = button.colors;

            cb.normalColor = Color.green;
            cb.highlightedColor = Color.green;
            cb.pressedColor = Color.green;
            cb.selectedColor = Color.green;
            cb.disabledColor = Color.green;

            button.colors = cb;
            button.interactable = false;

            cheerSoundEventChannelSO.RaiseEvent(cheerClipSO.clip);
        }
        else
        {
            ColorBlock cb = button.colors;

            cb.normalColor = Color.red;
            cb.highlightedColor = Color.red;
            cb.pressedColor = Color.red;
            cb.selectedColor = Color.red;
            cb.disabledColor = Color.red;

            button.colors = cb;
            button.interactable = false;

            cheerSoundEventChannelSO.RaiseEvent(disappointmentClipSO.clip);
        }
    }
}