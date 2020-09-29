using UnityEngine;

public class Rotater : MonoBehaviour {
	public float start = 15f;
	public float end = -60f;
	public float duration = 2f;
	public float power = 3;

	public bool shouldRotate = false;

	CurvedAnimation<float> animator;
	float t = 0;

	void Awake() {
		Curve curve = new ExponentialCurve(power);
		Tween<float> tween = new RotationTween(start, end);
		animator = new CurvedAnimation<float>(
			curve: curve, tween: tween, duration: duration
		);
	}

	void Update() {
		if (shouldRotate) {
			t += Time.deltaTime;
			transform.rotation = Quaternion.Euler(0f, 0f, animator.Evaluate(t));
		}
	}

	public void Reset() {
		t = 0;
	}
}
