using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DestroyFood : MonoBehaviour 
{
	//private Text scoreReference;
	public GameObject foodReference;
	private Scorer scorer;
	private Text scoreReference;
	//private int points=1;
	private int score;


	void Start()
	{
		score = 1;
		scoreReference = GameObject.Find ("Text").GetComponent<Text>();
	}
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.name=="Line")
		{
			
			//Destroy (foodReference);
			//scoreReference.text ="Score: "+(score+=1).ToString();
		}


	}
	void OnTriggerExit(Collider col)
	{
		//points = 1;
		if (col.gameObject.name == "Line") 
		{
			//points--;
			//if (points > -1) 
			//{
			Destroy (foodReference);
			scoreReference.text ="Score: "+score.ToString();


			//}
			//Destroy (foodReference);
			//score += 1;

		}


	}
}	
