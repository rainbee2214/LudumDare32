using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public static GameController controller;

    Vector2 currentPlanetLocation;
    public Vector2 CurrentPlanetLocation
    {
        get { return currentPlanetLocation; }
        set { currentPlanetLocation = value; }
    }

    Vector2 startingLocation;
    public Vector2 StartingLocation
    {
        get { return startingLocation; }
        set { startingLocation = value; }
    }

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
