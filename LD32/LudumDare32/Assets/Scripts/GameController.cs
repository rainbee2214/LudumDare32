using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public static GameController controller;

    CameraController cameraController;

    #region Properties
    string playerName = "Bob";
    public string PlayerName
    {
        get { return playerName; }
        set { playerName = value; }
    }

    int shipType = 0;
    public int ShipType
    {
        get { return shipType; }
        set { shipType = value; }
    }

    int shipColor = 0;
    public int ShipColor
    {
        get { return shipColor; }
        set { shipColor = value; }
    }

    int raceType = 0;
    public int RaceType
    {
        get { return raceType; }
        set { raceType = value; }
    }

    bool playerDead = false;
    public bool PlayerDead
    {
        get { return playerDead; }
        set { playerDead = value; }
    }

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
    #endregion

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

    void Update()
    {
        if (playerDead)
        {
            playerDead = false;
            Application.LoadLevel("GameOver");
        }
    }
}
