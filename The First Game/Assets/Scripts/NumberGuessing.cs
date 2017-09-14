using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberGuessing : MonoBehaviour {

	//Khai Bao Bien binh thuong
	int numberToGuess;
	string questionContent;
	int guessCount = 0;
	float timeLeft;

	//UI Components
	public InputField numberInputField;
	public Text displayText;
	public Text timerText;
	public Button playAgainButton;

	// Use this for initialization

	void Start () {
		
		PlayAgain ();
	}

	void Update(){
		
		if (timeLeft > 0) {
			timeLeft -= Time.deltaTime;
			timerText.text = timeLeft.ToString();
		} else {
			displayText.text = "Time Up";
			timerText.text = "0";
			playAgainButton.gameObject.SetActive (true);
		}

	}

	public void CheckAnswer(){
		guessCount ++;
		int theRealNumber = int.Parse(numberInputField.text);

		if (theRealNumber < numberToGuess) {
			displayText.text = "So be qua, doan lai de !!!";
			ResetInputField ();
		} 
		else if(theRealNumber > numberToGuess) {
			displayText.text = "So To qua, doan lai de !!!";
			ResetInputField ();
		}
		else{
			displayText.text = "Chuan dey !!! Good job <3. Mat den " + guessCount + " lan de doan dung";
			playAgainButton.gameObject.SetActive (true);
		}
	}

	public void ResetInputField(){
		numberInputField.text = "";
		numberInputField.ActivateInputField ();
	}

	public void PlayAgain(){
		timeLeft = 30f;
		playAgainButton.gameObject.SetActive (false);
		guessCount = 0;
		questionContent = "Doan so cua tao di (trong pham vi tu 0-1000)";	
		displayText.text = questionContent;
		numberToGuess = Random.Range(0,1000);
	}

}
