using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour
{

    private bool isOpen;

    void Start()
    {
        isOpen = false;
        gameObject.SetActive(true);
    }

    public void open()
    {

        isOpen = true;
        gameObject.SetActive(false);

    }

    public void close()
    {

        isOpen = false;
        gameObject.SetActive(true);

    }

}
