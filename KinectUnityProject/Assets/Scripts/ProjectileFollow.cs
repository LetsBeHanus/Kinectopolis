using UnityEngine;
using System.Collections;

public class ProjectileFollow : MonoBehaviour {

	public Transform projectile;        
	public Transform farLeft;           
	public Transform farRight;          

	void Update () {
		Vector3 newPosition = transform.position;

		newPosition.x = projectile.position.x;

		newPosition.x = Mathf.Clamp (newPosition.x, farLeft.position.x, farRight.position.x);

		if (projectile.position.x > 100) {
			newPosition.x = 80;
		}


		transform.position = newPosition;
	}
}