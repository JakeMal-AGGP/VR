using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour
{

    bool canCollide;
    Rigidbody body;
    float debounceTime;

    public float hitCooldown; // How long the player must wait inbetween hits
    public float minSpeed; // The minimum speed the ball can be rolling before it is manually stopped (waiting for the natural drag to bring it to a stop takes too long, lets speed up the process)
    public float velocityFactor; // The factor by which the balls hit velocity is multiplied by. 5 is a good starting point

    Vector3 lastPos;

    public GameController game;
    GameObject putterReference;

    private void Awake()
    {
        canCollide = true;
        body = gameObject.GetComponent<Rigidbody>();


        //Set some default values if they have been forgotten to be set in the inspector
        if(minSpeed == 0)
        {
            minSpeed = .2f;
        }

        if(hitCooldown == 0)
        {
            hitCooldown = 2f;
        }

        if(velocityFactor == 0)
        {
            velocityFactor = 5f;
        }
    }

    private void Update()
    {


        if(body.velocity.magnitude <= minSpeed)
        {
            body.velocity *= 0f;
        }

        //Make sure the putter cant collide when it shouldnt
        if(putterReference != null)
        {
            if(!canCollide)
            {
                Physics.IgnoreCollision(putterReference.GetComponent<Collider>(), gameObject.GetComponent<Collider>(), true);
            }
            else
            {
                Physics.IgnoreCollision(putterReference.GetComponent<Collider>(), gameObject.GetComponent<Collider>(), false);
            }
        }

        
        //Debounce timer
        if (debounceTime > 0)
        {
            debounceTime -= Time.deltaTime;
            
        }

        if(debounceTime <= 0)
        {
            debounceTime = 0;
            canCollide = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {


        //Check for water
        if(collision.gameObject.tag == "water")
        {
            body.velocity = Vector3.zero;

            gameObject.transform.position = lastPos;

        }

        if (collision.gameObject.name == "putter" && canCollide && game.gameActive)
        {

            lastPos = gameObject.transform.position;

            Physics.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider>(), true); // First strokes collision behaves wierd if removed; leave in

            canCollide = false; // Make sure the player can't hit it again immediately after initiall hitting it (to prevent multiple accidental collisions)

            putterReference = collision.gameObject; // Set putterReference to the putter game object

            var velocity = collision.gameObject.GetComponent<putterVelocity>().displayVel; // the balls velocity equal to the putters velocity

            body.velocity = velocity *= velocityFactor; // multiply the velocity by a factor of 5 to make it feel more natural (pure velocity speeds are way to slow, 5 was the best factor in my opinion)

            if(game != null)
            {
                game.strokes += 1; // increase stroke count
            }

            debounceTime = hitCooldown; // set the debounce timer to 2 seconds (in which the player cannot hit the ball again)

        }

    }

    public void increaseVelocity()
    {

        if(velocityFactor < 11)
        {
            velocityFactor += 1;
        }

    }

    public void decreaseVelocity()
    {

        if (velocityFactor > 0)
        {
            velocityFactor -= 1;
        }

    }

}
