using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holeScript : MonoBehaviour
{

    public GameController game;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "golfBall")
        {
            Debug.Log("Hole in: " + game.strokes);
            game.gameActive = false;
        }
    }

}
