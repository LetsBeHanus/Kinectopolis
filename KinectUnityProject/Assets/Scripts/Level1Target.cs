using UnityEngine;
using System.Collections;

public class Level1Target : MonoBehaviour {

	private SpriteRenderer spriteRenderer;
	private int currentCollisions;
	private int maxCollisions = 5;
	private int projectileCollision = 2;
	private int boardCollision = 1;
	private BoxCollider2D collision;
	private Transform pig;

	// Use this for initialization
	void Start () {
		currentCollisions = 0;
		spriteRenderer = GetComponent <SpriteRenderer> ();
	}

	// Update is called once per frame
	void Update () {

		if (currentCollisions == maxCollisions) {
			//Kill ();
		}
	}


//	void Kill () {
//		
//		spriteRenderer.enabled = false;
//		GetComponent<BoxCollider2D>().enabled = false;
//		GetComponent<Rigidbody2D>().isKinematic = true;
//
//	}


	void onCollisionEnter2D (BoxCollider2D collision) {
		string tag = collision.GetComponent<Collider2D>().tag;
		//string tag = collider2D.gameObject.tag;
		if (tag == null) {
			
		}
		else if (tag == "Projectile" || tag == "Board") {
			Destroy (pig, 0.2f);
		}
//		if (collision.GetComponent<Collider> ().name == "Projectile") {
//			currentCollisions += projectileCollision;
//		}
//		if (collision.GetComponent<Collider> ().name == "Board") {
//			currentCollisions += boardCollision;
//		}

	}

	void changeScene () {

			
	}

}