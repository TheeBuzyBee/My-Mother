using UnityEngine;
using System;

public class ButtonControl : MonoBehaviour
{
    public GameObject Button;
    public GameObject DoorUnlock;

    private void OnCollisionEnter(Collision collision)
    {
        if (Button.CompareTag("Player"))
        {
            Destroy(DoorUnlock);
        }
    }
}
