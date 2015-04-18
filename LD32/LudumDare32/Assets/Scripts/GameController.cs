using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public static GameController controller;

    CameraController cameraController;
    
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
        if (controller == null)
        {
            DontDestroyOnLoad(gameObject);
            controller = this;
        }
        else if (controller != this)
        {
            Destroy(gameObject);
        }
        cameraController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
    }

    public void StartMiniGame()
    {
        cameraController.stop = true;
        cameraController.moveToPlanet = true;
    }

    public void StopMiniGame()
    {
        cameraController.moveToPlanet = false;
        cameraController.readyToStart = true;
        cameraController.turnOnTime = Time.time + cameraController.lerpDelay;
    }
}
