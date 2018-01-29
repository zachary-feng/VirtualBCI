using UnityEngine;
using System.Collections;

public class TargetFrameRate : MonoBehaviour {
	void Awake() {
		Application.targetFrameRate = 20;
	}
}