using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {
	public float lifetime=0;
	// Use this for initialization
	void Start () 
	{
		Destroy (gameObject,lifetime);
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}