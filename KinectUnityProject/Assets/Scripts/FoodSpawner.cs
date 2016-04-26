using UnityEngine;
using System.Collections;

public class FoodSpawner : MonoBehaviour {

	public GameObject foodReference;
	private Vector3 throwForce;

	// Use this for initialization
	void Start () 
	{
		InvokeRepeating ("SpawnFood", .05f, 4);

	}
	

	void SpawnFood ()
	{
		for(byte i=0;i<Random.Range(2,7);i++)
		{
			throwForce=new Vector3(Random.Range(-2,2),Random.Range(12,16),0);
			GameObject food= Instantiate(foodReference,new Vector3(Random.Range(-7,7), Random.Range(-5,0),0),Quaternion.identity) as GameObject;

			food.GetComponent<Rigidbody> ().AddForce (throwForce, ForceMode.Impulse);
		}

	}

}
