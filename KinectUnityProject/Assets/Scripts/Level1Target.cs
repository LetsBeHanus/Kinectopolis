using UnityEngine;
using System.Collections;

public class Level1Target : MonoBehaviour {

	private SpriteRenderer spriteRenderer;
	private int currentCollisions;
	private int maxCollisions = 5;

	// Use this for initialization
	void Start () {
		//spriteRenderer = GetComponent <SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (maxCollisions == 5) {
			//Kill ();
		}
	}


//	void Kill () {
//		
//		spriteRenderer.enabled = false;
//		GetComponent<BoxCollider2D>().enabled = false;
//		GetComponent<Rigidbody2D>().isKinematic = true;
//
//		GetComponent<ParticleSystem>().Play();
//	}


	//void onCollisionEnter2D (BoxCollider2D collision) {
//		if (collision.collider2D.gameObject.name == "Projectile" || collision.collider2D.gameObject.name == "Board") {
//
//		}
	//}
}
