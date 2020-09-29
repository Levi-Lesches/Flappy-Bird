using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class HUDController : MonoBehaviour {
	public Animator startScreenAnimator;
	public GameObject deathScreen;
	public GameObject flash;

	PointsDisplay pointsDisplay;

	void Start() {
		pointsDisplay = GetComponentInChildren<PointsDisplay>();
	}

	public void GameOver(bool isHighScore) {
		flash.SetActive(true);
		deathScreen.GetComponent<DeathScreenController>().isHighScore = isHighScore;
		deathScreen.SetActive(true);
	}

	public void RefreshPointsDisplay(int points) {
		pointsDisplay.Refresh(points);
	}

	public void RemoveStartScreen() {
		startScreenAnimator.SetBool("gameStarted", true);
	}
}
