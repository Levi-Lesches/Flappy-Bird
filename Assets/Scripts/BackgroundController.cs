using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour {
	public List<Sprite> backgrounds;

	Image background;

	void Awake() {
		background = GetComponent<Image>();   
	}

	void Start() {
		int index = Random.Range(0, backgrounds.Count);
		background.sprite = backgrounds [index];
	}
}
