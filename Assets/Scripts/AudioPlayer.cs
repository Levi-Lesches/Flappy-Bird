using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {
	public AudioSource flap;
	public AudioSource addPoint;
	public AudioSource hit;
	public AudioSource die;
	public AudioSource whoosh;

	public float primaryVolume = 0.5f;
	public float secondaryVolume = 0.25f;

	void Start() {
		hit.volume = primaryVolume;
		die.volume = primaryVolume;
		flap.volume = secondaryVolume;
		addPoint.volume = secondaryVolume;
		whoosh.volume = primaryVolume;	
	}

  public void Flap() {
  	flap.Play();
  }

  public void GameOver() {
  	hit.Play();
  	die.Play();
  }

  public void AddPoint() {
  	addPoint.Play();
  }

  public void Whoosh() {
  	whoosh.Play();
  }
}
