using UnityEngine;
using System.Collections;

public class SlingshotScore : MonoBehaviour {

	private double hitPoints = 2.0;	
	private Sprite damagedSprite;				
	private float damageImpactSpeed;				
	private double boardHit = 0.25;
	private double currentHitPoints;				
	private float damageImpactSpeedSqr;			
	private SpriteRenderer spriteRenderer;	
	private int totalScore = 0;

	void Start () {
		spriteRenderer = GetComponent <SpriteRenderer> ();

		currentHitPoints = hitPoints;

		damageImpactSpeedSqr = damageImpactSpeed * damageImpactSpeed;
	}

	void OnCollisionEnter2D (Collision2D collision) {

		if (collision.relativeVelocity.sqrMagnitude < damageImpactSpeedSqr) {
			currentHitPoints--;
			return;
		}

		if (collision.collider.tag == "Projectile") {
			currentHitPoints--;
			if (currentHitPoints <= 0) {
				Kill ();
			}
		}
			
		if (collision.collider.tag == "Board") {
			currentHitPoints -= boardHit;
			if (currentHitPoints <= 0) {
				Kill ();
			}
		}

//		if (currentHitPoints <= 0) {
//			Kill ();
//		}
	}

	void Update (){
		
	}

	void Kill () {
		spriteRenderer.enabled = false;
		GetComponent<Collider2D>().enabled = false;
		GetComponent<Rigidbody2D>().isKinematic = true;
		totalScore++;
	}
}