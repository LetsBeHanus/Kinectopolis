using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public string foodNinja;
    public string jetpack;
    public string slingshot;

    public void FoodNinjaLevel()
    {
        SceneManager.LoadScene(foodNinja);
    }

    public void JetpackLevel()
    {
        SceneManager.LoadScene(jetpack);
    }

    public void SlingshotLevel()
    {
        SceneManager.LoadScene(slingshot);
    }
}
