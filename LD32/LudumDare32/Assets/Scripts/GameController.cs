﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public static GameController controller;

    CameraController cameraController;

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

    int cyrstals;
    public int Cyrstals
    {
        get { return cyrstals; }
        set { cyrstals += value; }
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
