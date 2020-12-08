using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    
    public void loadHoleOne()
    {

        SceneManager.LoadScene("Minigolf");

    }

    public void loadHoleTwo()
    {
        SceneManager.LoadScene("Minigolf2");
    }

    public void loadHoleThree()
    {
        SceneManager.LoadScene("Minigolf3");
    }

}
