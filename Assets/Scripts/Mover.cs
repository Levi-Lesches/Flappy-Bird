using UnityEngine;

public class Mover : MonoBehaviour {
	public GameController controller;

	Rigidbody2D rb;

	void Awake() {
		rb = GetComponent<Rigidbody2D>();
	}

	void Start() {
		rb.linearVelocity = new Vector2(-controller.speed, 0);
	}

	public void OnGameOver() {
		rb.linearVelocity = Vector2.zero;
	}
}
