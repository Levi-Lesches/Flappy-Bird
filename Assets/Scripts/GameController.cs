using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState {Playing, Start, GameOver}

public class GameController : MonoBehaviour {
	public BirdController birdController;
  public HUDController hudController;
  public AudioPlayer audioPlayer;
  public GameObject globalGame;
  public Mover ground;

	public GameState state = GameState.Start;
  public int points = 0;
  public int highScore = 0;
  public float speed = 0.015f;

  void Awake() {
    audioPlayer = GetComponentInChildren<AudioPlayer>();
    highScore = PlayerPrefs.GetInt("highScore", 0);
  }

  public void StartGame() {
    state = GameState.Playing;
    hudController.RemoveStartScreen();
  }

  public void AddPoint() {
    points++;
    hudController.RefreshPointsDisplay(points);
    audioPlayer.AddPoint();
  }

  public void GameOver() {
    if (state == GameState.GameOver) return;
    ground.OnGameOver();
  	state = GameState.GameOver;
		birdController.Fall();
    audioPlayer.GameOver();
    bool isHighScore = points > highScore;
    if (isHighScore) {
      highScore = points;
      PlayerPrefs.SetInt("highScore", highScore);
    }
		hudController.GameOver(isHighScore);
	}
}
