using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Scorer : MonoBehaviour 
{
	public GameObject food;
	private string score;
	private Text textBox;

	public void incrementScore()
	{
		this.score += "X";
	}

	public string getScore()
	{
		return this.score;
	}
	
	//public void AddScore(int newScore)
	//{
	//	score += newScore;
	//	UpdateScore ();
	//}
	//void UpdateScore () 
	//{
		
		//textBox.text = "Score" + score;

	//}
}
