using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public static GameController controller;

    void Awake()
    {
        if (controller != this) Destroy(controller);
        else
        {
            controller = this;
            DontDestroyOnLoad(controller);
        }
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
