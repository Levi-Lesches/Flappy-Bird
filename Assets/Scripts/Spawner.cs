using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	public GameObject pipeGroup;
	public Transform pipeSpawnTransform;

	public float spawnDelay = 2f;
	public float minY = -0.5f;
	public float maxY = 1.25f;

	GameController controller;
	List<Mover> movingObjects = new List<Mover>();

	float timer;
	bool isPlaying = false;

	void Awake() {
		controller = GetComponentInParent<GameController>();
	}

	void Update() {
		if (controller.state != GameState.Playing) {
			if (isPlaying)
				OnGameOver();
			return;
		}
		isPlaying = true;
		if (controller.state != GameState.Playing) return;
		timer += Time.deltaTime;
		if (timer >= spawnDelay) {
			timer -= spawnDelay;
			Spawn();
		}
	}

	public void OnGameOver() {
		foreach (Mover movingObject in movingObjects) {
			movingObject.OnGameOver();
		}
	}

	void Spawn() {
		GameObject pipe = Instantiate(pipeGroup, pipeSpawnTransform);
		Debug.Log("LOcations: " + pipe.transform.localPosition);
		float yPos = Random.Range(minY, maxY);
		pipe.transform.localPosition = new Vector3(0, yPos, 0);
		Mover script = pipe.GetComponent<Mover>();
		script.controller = controller;
		movingObjects.Add(script);
	}

	public void Despawn() {
		movingObjects.RemoveAt(0);
	}
}
