using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GuessTheNumber : MonoBehaviour
{
    [SerializeField] TMP_InputField textInput;
    [SerializeField] TMP_Text titleText;
    [SerializeField] Button submitButton;

    private int randomNum;
    private int attempts;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameSetUp();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //call on start and reset button press
    public void GameSetUp()
    {
        //random number between 1 and 10
        randomNum = Random.Range(1, 11);

        //update text based on attempts
        attempts = 3;
        titleText.text = "I am thinking of a number between 1 and 10. You have " + attempts + " attempts to guess it.";

        //clear input field
        textInput.text = "";

        //reset button
        submitButton.interactable = true;
    }

    public void SubmitGuess()
    {

        //check if the user has attempts left
        if(attempts > 1)
        {
            //check if the user is correct
            int guess = int.Parse(textInput.text);

            //check if number is in range
            if (guess >= 1 && guess <= 10)
            {
                //determine if user is correct
                if (guess == randomNum)
                {
                    titleText.text = "Correct. You have guessed the right number.";

                    //disable button if correct
                    submitButton.interactable = false;
                }
                else
                {
                    attempts--;
                    titleText.text = "Incorrect. You have " + attempts + " attempts left.";

                }
            }
            else
            {
                titleText.text = "Please enter a number between 1 and 10.";

            }

        }
        else
        {
            titleText.text = "You have run out of attempts";

            //disable button once lost
            submitButton.interactable = false;
        }

    }

}
