using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blinking : MonoBehaviour {

	public Image sprite;

	public bool startBlinking = true;
	public float blinkTime = 0.5f;

	private float lastBlink = 0.0f;
	private float totalTime = 0.0f;

	void Start () {
		sprite.fillAmount = 1.0f;
	}

	void Update () {
		if (startBlinking == true) {
			StartBlinkingEffect ();
		}
	}

	void StartBlinkingEffect () {
		totalTime += Time.deltaTime;

		if(totalTime - lastBlink >= blinkTime) {
			if (sprite.fillAmount > 0.5f) {
				sprite.fillAmount = 0.0f;
			} else {
				sprite.fillAmount = 1.0f;
			}
			lastBlink = totalTime;
		}
	}
}
