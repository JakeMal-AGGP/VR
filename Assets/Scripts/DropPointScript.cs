using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPointScript : MonoBehaviour
{

    public Material red;
    public Material green;
    private Renderer rend;

    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        rend.material = red;
    }


    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.name == "InteractableSphere")
        {

            rend.material = green;

        }

    }
}
