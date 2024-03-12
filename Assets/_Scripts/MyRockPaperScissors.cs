using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MyRockPaperScissors : MonoBehaviour
{
    public Text resultText;
    public Text roundText; // Text object to display round number
    public GameObject rockPaperScissorsPanel; // Reference to the Rock, Paper, Scissors panel
    public GameObject triviaPanel; // Reference to the trivia panel
    public Button player1RockButton;
    public Button player1PaperButton;
    public Button player1ScissorsButton;
    public Button player2RockButton;
    public Button player2PaperButton;
    public Button player2ScissorsButton;

    private string player1Choice;
    private string player2Choice;
    private int currentRound = 1; // Current round number
    public float resultDisplayTime = 3f; // Adjust the duration as needed
    public float transitionDelay = 3f; // Delay before transitioning to trivia panel

    void Start()
    {
        // Assigning click event listeners to player 1 buttons
        player1RockButton.onClick.AddListener(() => Player1Chooses("rock"));
        player1PaperButton.onClick.AddListener(() => Player1Chooses("paper"));
        player1ScissorsButton.onClick.AddListener(() => Player1Chooses("scissors"));

        // Assigning click event listeners to player 2 buttons
        player2RockButton.onClick.AddListener(() => Player2Chooses("rock"));
        player2PaperButton.onClick.AddListener(() => Player2Chooses("paper"));
        player2ScissorsButton.onClick.AddListener(() => Player2Chooses("scissors"));

        UpdateRoundText(); // Update round text when the game starts

        // Hide the trivia panel initially
        triviaPanel.SetActive(false);
    }

    void Player1Chooses(string choice)
    {
        player1Choice = choice;
    }

    void Player2Chooses(string choice)
    {
        player2Choice = choice;
    }

    public void PlayGame()
    {
        if (player1Choice != null && player2Choice != null)
        {
            string result = DetermineWinner(player1Choice, player2Choice);
            resultText.text = result; // Display only the result of the match

            // Check if it's round 3 to show the result before transitioning to trivia panel
            if (currentRound == 3)
            {
                StartCoroutine(ShowResultAndTransition());
            }
            else
            {
                StartCoroutine(HideResultAndContinue());

            }
        }
        else
        {
            resultText.text = "Both players need to make a choice!";
        }
    }

    IEnumerator ShowResultAndTransition()
    {
        // Show the result for a few seconds
        yield return new WaitForSeconds(resultDisplayTime);

        // Hide the result text
        resultText.text = "";

        // Hide the Rock, Paper, Scissors panel
        rockPaperScissorsPanel.SetActive(false);

        // Show the trivia panel
        triviaPanel.SetActive(true);
    }

    IEnumerator HideResultAndContinue()
    {
        // Hide the result text after a delay
        yield return new WaitForSeconds(resultDisplayTime);

        // Clear the result text
        resultText.text = "";

        // Increment round number
        currentRound++;

        // Reset choices for the next round
        ResetRound();

        // Update round text for the next round
        UpdateRoundText();
    }

    string DetermineWinner(string choice1, string choice2)
    {
        if (choice1 == choice2)
        {
            return "It's a tie!";
        }
        else if ((choice1 == "rock" && choice2 == "scissors") ||
                 (choice1 == "paper" && choice2 == "rock") ||
                 (choice1 == "scissors" && choice2 == "paper"))
        {
            return "Player 1 wins!";
        }
        else
        {
            return "Player 2 wins!";
        }
    }

    void ResetRound()
    {
        // Reset player choices for the next round
        player1Choice = null;
        player2Choice = null;
    }

    void UpdateRoundText()
    {
        // Update round text to display current round number
        roundText.text = currentRound.ToString();
    }
}
