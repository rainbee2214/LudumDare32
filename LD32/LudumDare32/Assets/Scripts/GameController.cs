using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public static GameController controller;

    public UIController uiController;
    CameraController cameraController;
    public GameObject mainCam;

    #region Properties
    int junk;
    public int Junk
    {
        get { return junk; }
        set { junk += value; }
    }

    int metals;
    public int Metals
    {
        get { return metals; }
        set { metals += value; }
    }

    int organics;
    public int Organics
    {
        get { return organics; }
        set { organics += value; }
    }

    int crystals;
    public int Crystals
    {
        get { return crystals; }
        set { crystals += value; }
    }

    int people;
    public int People
    {
        get { return people; }
        set { people += value; }
    }

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
        cameraController = mainCam.GetComponent<CameraController>();//GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
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

    public void SetName()
    {
        if (uiController != null) uiController.SetName(raceType, playerName);
    }

    void Update()
    {
        if  (uiController != null) uiController.UpdateResources(crystals, organics, metals, people, junk);
        if (playerDead)
        {
            playerDead = false;
            Application.LoadLevel("GameOver");
        }

        //When the game over scene is loaded, turn the main camera off
        if (Application.loadedLevelName == "GameOver") mainCam.SetActive(false);
        //When the setup scene is loaded, turn the main camera back on
        if (Application.loadedLevelName == "Setup") mainCam.SetActive(true);
    }
}
