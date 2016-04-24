using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Resetter : MonoBehaviour {

	public Rigidbody2D projectile;			
	public float resetSpeed = 0.025f;		
	private float resetSpeedSqr;			
	private SpringJoint2D spring;	


	void Start () {
		resetSpeedSqr = resetSpeed * resetSpeed;

		spring = projectile.GetComponent <SpringJoint2D>();
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			Reset ();
		}
			
		if (spring == null && projectile.velocity.sqrMagnitude < resetSpeedSqr) {
			ChangeScene ();

		}

		if (projectile.position.x > 100) {
			ChangeScene ();
			//Reset ();
		}

		if (spring == null && projectile.position.y < -9) {
			ChangeScene ();
			//Reset ();
		}

	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.GetComponent<Rigidbody2D>() == projectile) {
			Reset ();
		}
	}

	void Reset () {
		

		SceneManager.LoadScene ("Level 1", LoadSceneMode.Single);


		//Rename projectiles in each level to level name
		//have the collider be the scene name
		//so that it fits with each of the three levels
	}

	void ChangeScene () {
		string sceneName = SceneManager.GetActiveScene ().name;

		if (sceneName == "Level 1") {
			SceneManager.LoadScene ("Level 2", LoadSceneMode.Single);
		}

		else if (sceneName == "Level 2") {
			SceneManager.LoadScene ("Level 3", LoadSceneMode.Single);
		}

		else if (sceneName == "Level 3") {
			return;
		}
	
	}
}
