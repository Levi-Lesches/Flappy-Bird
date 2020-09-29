using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScreenController : MonoBehaviour {
	public NumbersDisplay scoreDisplay;
	public NumbersDisplay highScoreDisplay;
	public GameController controller;
	public Animator colorOverlay;
	public Image medalDisplay;
	public Image newRecord;

	public List<Sprite> digits;
	public Sprite bronzeMedal;
	public Sprite silverMedal;
	public Sprite goldMedal;
	public Sprite platinumMedal;

	public float scoreAnimationDelay = 0.1f;
	public bool isHighScore = false;

	WaitForSeconds delay;
	int score;
	int highScore;

	void Awake() {
		delay = new WaitForSeconds(scoreAnimationDelay);
		score = controller.points;
		highScore = controller.highScore;
	}

	void Start() {
		scoreDisplay.digits = digits;
		highScoreDisplay.digits = digits;

		scoreDisplay.DisplayNumber(0);
		highScoreDisplay.DisplayNumber(highScore);
		
		newRecord.enabled = isHighScore;
		Sprite medal = GetMedal(score);
		if (medal == null) {
			medalDisplay.enabled = false;
		} else {
			medalDisplay.sprite = medal;
		}
	}

	Sprite GetMedal(int score) {
		if (score >= 40) {
			return platinumMedal;
		} else if (score >= 30) {
			return goldMedal;
		} else if (score >= 20) {
			return silverMedal;
		} else if (score >= 10) {
			return bronzeMedal;
		} else {
			return null;
		}
	}

	public void Restart() {
		colorOverlay.SetTrigger("FadeOut");
	}

	public IEnumerator AnimateScore() {
		for (int num = 0; num <= score; num++) {
			scoreDisplay.DisplayNumber(num);
			yield return delay;
		}
	}

	public void PlayWhoosh() {
		controller.audioPlayer.Whoosh();
	}
}
