using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FlashingSpriteScript : MonoBehaviour {

	Image flashingImage;

	public float blinkRate = 0.5f;
	public bool runForever = false;
	public float runTime = 5.0f;

	private bool isBlinking = true;

	void Start() {
		flashingImage = GetComponent<Image>();
		StartCoroutine(BlinkImage());
		if(runForever == false) {
			StartCoroutine(StopBlinking());
		}
	}
		
	public IEnumerator BlinkImage() {
		while (isBlinking) {
			var tempColor = flashingImage.color;
			tempColor.a = 0.0f;
			flashingImage.color = tempColor;
			yield return new WaitForSeconds (blinkRate);
			tempColor = flashingImage.color;
			tempColor.a = 1.0f;
			flashingImage.color = tempColor;
			yield return new WaitForSeconds (blinkRate);
		}
	}

	IEnumerator StopBlinking(){
		yield return new WaitForSeconds(runTime);
		isBlinking = false; 
		var tempColor = flashingImage.color;
		tempColor.a = 0.0f;
		flashingImage.color = tempColor;
	}
}
