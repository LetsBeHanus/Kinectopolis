using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

	float timer=0.0f;
	private Text scoreReference;

	// Use this for initialization
	void Start () 
	{
		scoreReference = GameObject.Find ("Text").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;
		int n=(int)timer;
		scoreReference.text ="Score: "+n.ToString();
	}
}
