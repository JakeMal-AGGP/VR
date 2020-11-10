using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecendingDoorScript : MonoBehaviour
{

    public bool drop;
    private Vector3 start;

    void Start()
    {
        drop = false;
        start = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    
    void Update()
    {
        if(drop)
        {
            if(gameObject.transform.position.y > start.y - 1.5f)
            {
                gameObject.transform.position -= new Vector3(0, .005f, 0);
            }
        }
        else
        {
            if(gameObject.transform.position.y < start.y)
            {
                gameObject.transform.position += new Vector3(0, .005f, 0);
            }
        }
    }
}
