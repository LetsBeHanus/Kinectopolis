using UnityEngine;
using System.Collections;

public class FollowRock : MonoBehaviour {

	public Transform projectile;        
	public Transform farLeft;          
	public Transform farRight;          

	// Use this for initialization
	void Start () {
		//camera needs to follow
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition = transform.position;
	
		newPosition.x = projectile.position.x;

		newPosition.x = Mathf.Clamp (newPosition.x, farLeft.position.x, farRight.position.x);

		transform.position = newPosition;
	}

// code for changing between game levels
//	using UnityEngine.SceneManagement;
//	SceneManager.LoadScene(scenename, level2);
//
}