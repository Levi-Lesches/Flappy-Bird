using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {
	public void LoadLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}