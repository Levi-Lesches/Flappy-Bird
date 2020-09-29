using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumbersDisplay : MonoBehaviour {
	public Image tensDigit;
	public Image onesDigit;

	public List<Sprite> digits;

	public void DisplayNumber(int num) {
		if (num >= 100) return;
		if (num >= 10) {
			tensDigit.enabled = true;
			int tensDigitNum = num / 10;
			int onesDigitNum = num % 10;
			tensDigit.sprite = digits [tensDigitNum];
			onesDigit.sprite = digits [onesDigitNum];
		} else {
			tensDigit.enabled = false;
			onesDigit.sprite = digits [num];
		}
	}
}
