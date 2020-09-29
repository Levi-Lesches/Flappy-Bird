using UnityEngine;

public class Mover : MonoBehaviour {
	public GameController controller;

	Rigidbody2D rb;

	void Awake() {
		rb = GetComponent<Rigidbody2D>();
	}

	void Start() {
		rb.velocity = new Vector2(-controller.speed, 0);
	}

	public void OnGameOver() {
		rb.velocity = Vector2.zero;
	}
}
