using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class physicsButtonTrigger : MonoBehaviour
{

    public DecendingDoorScript door;

    private void OnTriggerStay(Collider other)
    {
        door.drop = true;
    }

    private void OnTriggerExit(Collider other)
    {
        door.drop = false;
    }
}
