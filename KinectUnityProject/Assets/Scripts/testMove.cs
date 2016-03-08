using UnityEngine;
using System.Collections;

public class testMove : MonoBehaviour {
    public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        player.gameObject.GetComponent<Rigidbody>().AddForce(0.0f, 1.0f, 0.0f, ForceMode.Acceleration);
	}
}
