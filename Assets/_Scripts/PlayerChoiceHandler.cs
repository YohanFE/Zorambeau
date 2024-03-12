using UnityEngine;

public class PlayerChoiceHandler : MonoBehaviour
{
    private int currentPlayer = 1; // Track which player is currently making a choice

    public void PlayerChoose(string choice)
    {
        // Determine which player is making the choice
        if (currentPlayer == 1)
        {
            Debug.Log("Player 1 chose: " + choice);
            // Process Player 1's choice
        }
        else if (currentPlayer == 2)
        {
            Debug.Log("Player 2 chose: " + choice);
            // Process Player 2's choice
        }

        // Toggle to the next player
        TogglePlayer();
    }

    private void TogglePlayer()
    {
        // Switch to the other player
        currentPlayer = (currentPlayer == 1) ? 2 : 1;
    }
}
