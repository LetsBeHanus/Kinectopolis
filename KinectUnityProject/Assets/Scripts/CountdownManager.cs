using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountdownManager : MonoBehaviour {

    private Text count;
    public int countdown;

    void Start()
    {
        count = GetComponent<Text>();
    }

    public void Count()
    {
        count.text = countdown.ToString();
    }
	
}
