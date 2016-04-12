using UnityEngine;
using System.Collections;

public class MoveProjectile : MonoBehaviour
{
	private Rigidbody2D projectile;
	private Rigidbody2D clone;


	// Use this for initialization
	void Start ()
	{
		clone.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Instantiate a rigidbody then set the velocity
			if (Input.GetButtonDown("Fire1")) {
				// Instantiate the projectile at the position and rotation of this transform
			clone = (Rigidbody2D)Instantiate(projectile, transform.position, transform.rotation);
			if(clone.GetComponent<Rigidbody2D>() != null){
				clone.AddForce(clone.transform.forward * 10);
			}
		}
	}
}

//public Rigidbody projectile;
//void Update() {
//	if (Input.GetButtonDown("Fire1")) {
//		Rigidbody clone;
//		clone = Instantiate(projectile, transform.position, transform.rotation);
//		clone.velocity = transform.TransformDirection(Vector3.forward * 10);
//	}
//}
	
