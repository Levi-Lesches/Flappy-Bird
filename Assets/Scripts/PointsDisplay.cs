using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsDisplay : MonoBehaviour {
	public List<Sprite> sprites;

	public GameObject oneDigit;
	public GameObject twoDigits;

	public Image digit;
	public Image tensDigit;
	public Image onesDigit;

	public void Refresh(int points) {
		if (points >= 100) {
			return;
		} else if (points >= 10) {
			twoDigits.SetActive(true);
			oneDigit.SetActive(false);
			tensDigit.sprite = sprites [points / 10];
			onesDigit.sprite = sprites [points % 10];
		} else {
			twoDigits.SetActive(false);
			oneDigit.SetActive(true);
			digit.sprite = sprites [points];
		}
	}
}
