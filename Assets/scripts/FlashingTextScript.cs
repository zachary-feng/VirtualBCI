using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FlashingTextScript : MonoBehaviour {

	Text flashingText;

	public float blinkRate = 0.5f;
	public bool runForever = false;
	public float runTime = 5.0f;

	string textToFlash = "O";
	string blankText = "";
	string staticText = "STOPPED FLASHING";
	bool isBlinking = true; // flag to determine if you want blinking to happen

	void Start() {
		flashingText = GetComponent<Text>(); // get Text component
		StartCoroutine(BlinkText()); // call co-routine BlinkText on Start
		if(runForever == false) {
			StartCoroutine(StopBlinking()); // call function to check if it is time to stop the flashing
		}
	}

	// function to blink the text
	public IEnumerator BlinkText() {
		// blink it forever until termination
		while (isBlinking) {
			flashingText.text = blankText; // set text to blank
			yield return new WaitForSeconds (blinkRate); // display blank for blinkRate seconds
			flashingText.text = textToFlash; // set text to value
			yield return new WaitForSeconds (blinkRate); // display text for blinkRate seconds
		}
	}
		
	IEnumerator StopBlinking(){
		yield return new WaitForSeconds(runTime); // wait for runTime seconds
		isBlinking = false; // stop blinking
		flashingText.text = staticText; // reset text value
	}
}
