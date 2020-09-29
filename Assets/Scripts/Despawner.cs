using UnityEngine;

public class Despawner : MonoBehaviour {
	public Spawner spawner;
	public bool isChild;

	void OnTriggerEnter2D(Collider2D collider) {
  	GameObject toDestroy = isChild 
  		? collider.transform.parent.gameObject
  		: collider.gameObject;
  	spawner.Despawn();
  	Destroy(toDestroy);
  }
}
