using UnityEngine;
using System.Collections;

public class Resource : MonoBehaviour
{

    void OnMouseDown()
    {
        Debug.Log("Collecting " + gameObject.name);
    }
}
