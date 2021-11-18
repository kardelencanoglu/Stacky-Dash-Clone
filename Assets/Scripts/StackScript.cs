using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Dashes")
        {
            Debug.Log("girdi");
            other.gameObject.tag = "Normal";
            PlayerController.instance.TakeDashes(other.gameObject);
            other.gameObject.AddComponent<Rigidbody>();
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.AddComponent<StackScript>();
            Destroy(this);

        }
    }
}
