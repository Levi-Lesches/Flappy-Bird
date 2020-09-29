using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour {

  public GameController controller;
  public List<Sprite> defaultColors;

	public float floatAngle = 6f;
  public float fallSpeed = -2f;

  // public float rotationSpeed = 0.5f;
  // public float initialAngle = 45;
  public float finalAngle = -90;
  
	Rigidbody2D rb;
  Animator animator;
  Rotater rotater;

  // float t = 0;

  // Initializes references
  void Awake() {
  	rb = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
    rotater = GetComponent<Rotater>();
  }

  // Initializes bird graphics
  void Start() {
    int colorIndex = Random.Range(0, 3);
    animator.SetInteger("color", colorIndex);
  }

  // Runs every frame
  void Update() {
    if (controller.state == GameState.GameOver) return;
    else if (GetShouldFlap()) Flap();
    // else if (controller.state == GameState.Playing)
  	// else if (controller.state != GameState.Start && t <= 1) {
      // t += rotationSpeed * Time.deltaTime;
      // transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Lerp(initialAngle, finalAngle, t));
    // }
  }

  bool GetShouldFlap() {
    return 
      (Input.touchCount > 0 && Input.touches [0].phase == TouchPhase.Began) 
      || Input.GetKeyDown(KeyCode.Space);
  }


  // Runs on first input
  void StartGame() {
    controller.StartGame();
    rotater.shouldRotate = true;
    rb.isKinematic = false;
  }

  void Flap() {
    if (controller.state == GameState.Start)
      StartGame();
    rb.velocity = new Vector2(0, floatAngle);
    controller.audioPlayer.Flap();
    rotater.Reset();
  }

  // Runs on all collisions
  void OnTriggerEnter2D(Collider2D collider) {
    if (collider.tag == "Detector" && controller.state == GameState.Playing)
      controller.AddPoint();
    else 
      controller.GameOver();  
  }

  // Runs when the player dies
  public void Fall() {
    rotater.shouldRotate = false;
    rb.velocity += new Vector2(1, fallSpeed);
    transform.rotation = Quaternion.Euler(0f, 0f, finalAngle);
    animator.SetBool("isAlive", false);
  }
}
