using UnityEngine;
using System.Collections;

public class Resource : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Collecting " + gameObject.name);
        }
    }
}
