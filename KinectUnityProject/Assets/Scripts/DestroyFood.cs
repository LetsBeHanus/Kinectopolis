using UnityEngine;
using System.Collections;

public class DestroyFood : MonoBehaviour 
{
	public GameObject foodReference;
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.name=="Line")
		{
			Destroy (foodReference);
		}
	}

}	
