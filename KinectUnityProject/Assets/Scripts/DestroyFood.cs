using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DestroyFood : MonoBehaviour 
{
	//private Text strikeReference;

	public GameObject foodReference;
	private Scorer scorer;
	//private int points=1;
	//private int score;
	public string strike;


	void Start()
	{
		
		strike = "";
		//score = 1;
		//strikeReference = GameObject.Find ("Text2").GetComponent<Text>();
	}
	//void OnTriggerEnter(Collider col)
	//{
		//if(col.gameObject.name=="Line")
		//{
			
			//Destroy (foodReference);
			//scoreReference.text ="Score: "+(score+=1).ToString();
		//}


	//}
	void Update()
	{
//		float position = foodReference.transform.position.y;
//		if (position<= -10) 
//		{
//			strike = strike + "X";
//			Destroy (foodReference);
//			strikeReference.text = "Strikes: " + strike;
//		}
	}

//	void OnTriggerExit(Collider col)
//	{
//		//points = 1;
//		if (col.gameObject.name == "Line") {
//			//points--;
//			//if (points > -1) 
//			//{
//			Destroy (foodReference);
//			//scoreReference.text ="Score: "+score.ToString();
//
//
//			//}
//			//Destroy (foodReference);
//			//score += 1;
//
//		}
//	}

		void OnTriggerEnter(Collider col)
		{
		if (col.gameObject.name=="Slicer") 
			{
				Destroy (foodReference);
			}
		}



}	
