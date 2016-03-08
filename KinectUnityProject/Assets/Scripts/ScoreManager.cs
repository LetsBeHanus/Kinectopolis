using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public GameObject player;
    private Text textBox;

    void Start()
    {
        textBox = GetComponent<Text>();
    }

    void Update()
    {
        textBox.text = "Score: " + (int)player.transform.position.y;
    }

}
