using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	private Text strikeReference;


    void Start()
    {
		
		strikeReference = GameObject.Find ("Text2").GetComponent<Text>();
    }

    void Update()
    {
		strikeReference.text = "Strikes: " + StrikeCounter.strikes;
    }

}
