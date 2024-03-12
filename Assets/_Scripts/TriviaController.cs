using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TriviaController : MonoBehaviour
{
    public Text questionText; // Text object to display trivia question
    public Text[] answerTexts; // Array of Text objects to display answer choices
    public Text timerText; // Text object to display remaining time
    public Text resultText; // Text object to display the result of each question
    public GameObject TriviaPanel; // Reference to the trivia panel
    public GameObject MyRockPaperScissors; // Reference to the rock-paper-scissors panel
    public float questionTimeLimit = 15f; // Time limit for answering each question

    private List<TriviaQuestion> triviaQuestions; // List of trivia questions
    private TriviaQuestion currentQuestion; // Current trivia question
    private float remainingTime; // Remaining time for answering the current question

    private void Start()
    {
        // Initialize trivia questions
        InitializeTriviaQuestions();

        // Start the round when the script initializes
        StartTriviaRound();
    }

    private void InitializeTriviaQuestions()
    {
        // Initialize the list of trivia questions
        triviaQuestions = new List<TriviaQuestion>();

        // Populate the list with trivia questions and answers
        triviaQuestions.Add(new TriviaQuestion(
            "What year was Photoshop created?",
            new string[] { "2001", "1985", "1997", "1987" },
            "1987"
        ));
        triviaQuestions.Add(new TriviaQuestion(
            "Which Tool allows crop or clip an image?",
            new string[] { "Hand Tool", "Selection Tool", "Crop Tool", "Paint Bucket Tool" },
            "Crop Tool"
        ));
        triviaQuestions.Add(new TriviaQuestion(
            "Which Tools lighten or darken areas of the image?",
            new string[] { "Patch & Clone Stamp Tool", "Blur & Sharpen Tool", "Dodge & Burn Tool", "Eraser & Brush Tool" },
            "Dodge & Burn Tool"
        ));
        triviaQuestions.Add(new TriviaQuestion(
            "Which Tool spreads and mixes content of image areas?",
            new string[] { "Smudge Tool", "Brush Tool", "Patch Tool", "Blur Tool" },
            "Smudge Tool"
        ));
        triviaQuestions.Add(new TriviaQuestion(
            "Which Tool Helps you to Lift or Sample Color?",
            new string[] { "Eye Dropper Tool", "Brush Tool", "Marquee Tool", "Lasso Tool" },
            "Eye Dropper Tool"
        ));
    }

    private void StartTriviaRound()
    {
        // Start the timer for the entire round
        remainingTime = questionTimeLimit;
        UpdateTimerText(); // Update timer text to start from questionTimeLimit
        StartCoroutine(UpdateTimer());

        // Start displaying questions
        ShowNextQuestion();
    }

    private void ShowNextQuestion()
    {
        // Get the next trivia question
        currentQuestion = GetRandomQuestion();

        // Display the question text
        questionText.text = currentQuestion.question;

        // Shuffle the answer choices for this question
        ShuffleAnswers(currentQuestion.answers);

        // Display the shuffled answer choices
        for (int i = 0; i < currentQuestion.answers.Length && i < answerTexts.Length; i++)
        {
            answerTexts[i].text = currentQuestion.answers[i];
        }
    }

    private TriviaQuestion GetRandomQuestion()
    {
        // Retrieve a random trivia question from the pool of questions
        int randomIndex = Random.Range(0, triviaQuestions.Count);
        return triviaQuestions[randomIndex];
    }

    private void ShuffleAnswers(string[] answers)
    {
        // Fisher-Yates shuffle algorithm for shuffling answer choices
        for (int i = answers.Length - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            string temp = answers[i];
            answers[i] = answers[randomIndex];
            answers[randomIndex] = temp;
        }
    }

    private IEnumerator UpdateTimer()
    {
        // Update the timer every second until time runs out
        while (remainingTime > 0)
        {
            UpdateTimerText(); // Update timer text
            yield return new WaitForSeconds(1f);
            remainingTime -= 1f;
        }

        // Time's up! End the round
        EndTriviaRound();
    }

    private void UpdateTimerText()
    {
        // Update timer text to display remaining time
        timerText.text = Mathf.FloorToInt(remainingTime).ToString();
    }

    private void EndTriviaRound()
    {
        // Hide the trivia panel
        TriviaPanel.SetActive(false);

        // Show the rock-paper-scissors panel
        MyRockPaperScissors.SetActive(true);
    }

    // Method to check the selected answer
    public void CheckAnswer(int answerIndex)
    {
        string selectedAnswer = currentQuestion.answers[answerIndex];
        string correctAnswer = currentQuestion.correctAnswer;

        // Compare the selected answer with the correct answer
        if (selectedAnswer == correctAnswer)
        {
            resultText.text = "Correct!";
            // Handle correct answer logic here
        }
        else
        {
            resultText.text = "Incorrect!";
            // Handle incorrect answer logic here
        }

        // End the trivia round after answering the question
        EndTriviaRound();
    }

    // Your TriviaQuestion class definition goes here

    [System.Serializable]
    public class TriviaQuestion
    {
        public string question; // The trivia question
        public string[] answers; // Array of possible answers
        public string correctAnswer; // The correct answer

        public TriviaQuestion(string question, string[] answers, string correctAnswer)
        {
            this.question = question;
            this.answers = answers;
            this.correctAnswer = correctAnswer;
        }
    }
}
