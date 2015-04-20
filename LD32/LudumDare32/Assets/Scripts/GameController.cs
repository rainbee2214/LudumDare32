using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public static GameController controller;

    public CurrentPlanetUIController planetUIController;
    public UIController uiController;
    CameraController cameraController;
    //[HideInInspector]
    public GameObject player;

    [HideInInspector]
    public MiniGameController miniGameController;

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

    int currentPlanetCrystals = 0;
    public int CurrentPlanetCrystals
    {
        get { return currentPlanetCrystals; }
        set { currentPlanetCrystals = value; }
    }

    int currentPlanetOrganics = 0;
    public int CurrentPlanetOrganics
    {
        get { return currentPlanetOrganics; }
        set { currentPlanetOrganics = value; }
    }

    int currentPlanetMetals = 0;
    public int CurrentPlanetMetals
    {
        get { return currentPlanetMetals; }
        set { currentPlanetMetals = value; }
    }

    int currentPlanetPeople = 0;
    public int CurrentPlanetPeople
    {
        get { return currentPlanetPeople; }
        set { currentPlanetPeople = value; }
    }

    int currentPlanetJunk = 0;
    public int CurrentPlanetJunk
    {
        get { return currentPlanetJunk; }
        set { currentPlanetJunk = value; }
    }

    float currentPlanetRadius;
    public float CurrentPlanetRadius
    {
        get { return currentPlanetRadius; }
        set { currentPlanetRadius = value; }
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
        cameraController = mainCam.GetComponent<CameraController>();
        miniGameController = GetComponentInChildren<MiniGameController>();
    }

    public void StartMiniGame()
    {
        cameraController.stop = true;
        cameraController.moveToPlanet = true;
        if (planetUIController != null) planetUIController.TurnOn();
    }

    public void StopMiniGame()
    {
        cameraController.moveToPlanet = false;
        cameraController.readyToStart = true;
        cameraController.turnOnTime = Time.time + cameraController.lerpDelay;
        if (planetUIController != null) planetUIController.TurnOff();
    }

    public void SetName()
    {
        if (uiController != null) uiController.SetName(raceType, playerName);
    }

    void Update()
    {
        if (Application.loadedLevelName == "Level" && player == null) player = GameObject.FindGameObjectWithTag("Player");
        //When the game over scene is loaded, turn the main camera off
        //When the setup scene is loaded, turn the main camera back on
        if (playerDead && Application.loadedLevelName == "Level")
        {
            playerDead = false;
            Debug.Log("Loading game over");
            Application.LoadLevel("GameOver");
        }

        if (Application.loadedLevelName == "GameOver")
        {
            mainCam.SetActive(false);
        }
        else if (Application.loadedLevelName == "Setup")
        {
            playerDead = false;
            mainCam.SetActive(true);
        }
        
        if  (uiController != null) uiController.UpdateResources(crystals, organics, metals, people, junk);

    }
}
