using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Resetter : MonoBehaviour {

	public Rigidbody2D projectile;			
	public float resetSpeed = 0.025f;		

	private float resetSpeedSqr;			
	private SpringJoint2D spring;	

	//create the boundary around scene
	//if ball is outside the boundary change the scene







	void Start ()
	{
		resetSpeedSqr = resetSpeed * resetSpeed;

		spring = projectile.GetComponent <SpringJoint2D>();
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			Reset ();
		}
			
		if (spring == null && projectile.velocity.sqrMagnitude < resetSpeedSqr) {
			Reset ();
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.GetComponent<Rigidbody2D>() == projectile) {
			Reset ();
		}
	}

	void Reset () {
		
		//Application.LoadLevel (Application.loadedLevel);

		SceneManager.LoadScene ("Level 1", LoadSceneMode.Single);


		//Rename projectiles in each level to level name
		//have the collider be the scene name
		//so that it fits with each of the three levels
	}
}
