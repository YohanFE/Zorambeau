using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public Text Result;
    public Image AIChoice;

    public string[] Choices;
    public Sprite Rock, Paper, Scissors;

    public void Play(string myChoice)
    {
        string randomChoice = Choices[Random.Range(0, Choices.Length)];

        switch (randomChoice)
        {
            case "Rock":
                switch (myChoice)
                {

                    case "Rock":
                        Result.text = "Tie!";
                        break;

                    case "Paper":
                        Result.text = "The Paper covers the Rock you win!";
                        break;

                    case "Scissors":
                        Result.text = "The Rock Destroys the Scissors you lose!";
                        break;
                }

                AIChoice.sprite = Rock;
                break;

            case "Paper":
                switch (myChoice)
                {

                    case "Rock":
                        Result.text = "The Paper covers the Rock you lose!";
                        break;

                    case "Paper":
                        Result.text = "Tie!";
                        break;

                    case "Scissors":
                        Result.text = "The scissors cut the paper you win!";
                        break;
                }

                AIChoice.sprite = Paper;
                break;

            case "Scissors":
                switch (myChoice)
                {

                    case "Rock":
                        Result.text = "The Rock Destroys the Scissors, you win! ";
                        break;

                    case "Paper":
                        Result.text = "The Scissors cut the Paper you win!";
                        break;

                    case "Scissors":
                        Result.text = "Tie!";
                        break;

                }

                AIChoice.sprite = Scissors;
                break;


        }
    }
}
