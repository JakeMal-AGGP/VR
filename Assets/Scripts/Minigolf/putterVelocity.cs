using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class putterVelocity : MonoBehaviour
{

    public Transform trans; // this gameobjects transform
    Vector3 prevPos { get; set; } // transform position of previous frame
    Vector3 frameVel { get; set; } // transform position of this frame (after smoothing)
    public Vector3 displayVel; // velocity accessible by ball

    public TextMeshProUGUI strokesText;
    public TextMeshProUGUI powerText;

    public GameController game;
    public ballScript golfBall;

    void Start()
    {
        trans = gameObject.transform;
    }

    
    void Update()
    {

        strokesText.text = "Strokes: " + game.strokes; // Update stroke text

        if(golfBall)
        {
            powerText.text = golfBall.velocityFactor.ToString(); // Update power text;
        }

        //strokesText.color = Color.Lerp(Color.green, Color.yellow, game.strokes / game.par + 5);


        Vector3 curFrameVel = (trans.position - prevPos) / Time.deltaTime; // get the velocity by comparing the transform of the current frame to the transform of the last frame

        frameVel = Vector3.Lerp(frameVel, curFrameVel, 0.1f); // smooth the transition between frames (not doing this can cause random spikes in velocity regardless of player input)

        displayVel = frameVel; // update DisplayVel so the ball can access the putters velocity

        prevPos = trans.position; // update previous frames transform

    }


}
