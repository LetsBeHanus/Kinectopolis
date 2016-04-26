using UnityEngine;
using System.Collections;

public class StrikeCounter : MonoBehaviour {

	public static string strikes;
	// Use this for initialization	
	void Start () 
	{
		strikes = "";
	}
	

	void OnTriggerExit(Collider col)
	{
		//if (col.gameObject.name == "Food") 
		//{
			strikes += "X";
		//}

	}
}
