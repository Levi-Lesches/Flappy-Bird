using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour {
	public float xMax = -6f;

	Vector2 origin;

	void Awake() {
		origin = new Vector2(0, transform.position.y);
	}

	void Update() {
		if (transform.position.x <= xMax) {
			transform.localPosition = origin;
		} 
	}
}