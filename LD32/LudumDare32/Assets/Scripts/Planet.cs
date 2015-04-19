﻿using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour
{
    //This class will control each individual planet
    //Each planet will have different levels of each resource
    //Junk, metal, organics, crystals, people

    int junk, metals, organics, crystals, people;
    float radius;

    bool playingGame = false;
    float nextEmitTime;
    float emitDelay = 0.5f;

    void Awake()
    {
        //Get the planet radius from the collider
        radius = GetComponent<CircleCollider2D>().radius * 50;
        GetComponent<CircleCollider2D>().radius = (radius / 50f) * 1.25f;
        SetupPlanet();
    }

    public void MineResource(string resourceName)
    {
        switch (resourceName)
        {
            case "Junk": if (junk > 0) junk--; break;
            case "Organics": if (organics > 0) organics--; break;
            case "Metals": if (metals > 0) metals--; break;
            case "Cyrstals": if (crystals > 0) crystals--; break;
            case "People": if (people > 0) people--; break;
            default: break;
        }
    }

    public void MineJunk()
    {
        if (junk > 0)
        {
            junk--;
            GameController.controller.Junk = 1;
        }
    }
    public void MineOrganics()
    {
        if (organics > 0)
        {
            GameController.controller.Organics = 1;
            organics--;
        }
    }
    public void MineMetals()
    {
        if (metals > 0)
        {
            GameController.controller.Metals = 1;
            metals--;
        }
    }
    public void MineCrystals()
    {
        if (crystals > 0)
        {
            GameController.controller.Crystals = 1;
            crystals--;
        }
    }
    public void MinePeople()
    {
        if (people > 0)
        {
            GameController.controller.People = 1;
            people--;
        }
    }

    public void SetupPlanet()
    {
        //Generate the levels of resources for each planet
        //Each planet, based on it's radius, will have a max quota of resources
        junk = 0; organics = 0; metals = 0; crystals = 0; people = 0;
        int count = 0;
        while (count < radius)
        {
            switch (Random.Range(0, 500) % 10)
            {
                case 0: junk++; break;
                case 1: organics++; break;
                case 2: metals++; break;
                case 3: crystals++; break;
                case 4: people++; break;
                case 5: junk += 2; break;
                case 6: organics += 2; break;
                case 7: metals += 2; break;
                case 8: crystals += 2; break;
                case 9: people += 2; break;
                default: break;
            }
            count++;
        }
        //PrintStats();
    }

    public void PrintStats()
    {
        Debug.Log("Radius: " + radius + "\nJunk: " + junk + "\nOrganics: " + organics + "\nMetals: " + metals + "\nCyrstals: " + crystals + "\nPeople: " + people);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") StartMiniGame();
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player") StopMiniGame();
    }

    public void StartMiniGame()
    {
        Debug.Log("Start game!");
        //Set the planet location that was touched
        GameController.controller.CurrentPlanetLocation = transform.position;
        //Set the camera starting position (to go back to after the mini game)
        GameController.controller.StartingLocation = Camera.main.transform.position;
        GameController.controller.StartMiniGame();
        //Start planet mining game over planet.
        playingGame = true;
        nextEmitTime = Time.time;
    }

    void Update()
    {
        if (playingGame && Time.time > nextEmitTime)
        {
            if (!EmptyResources())
            {
                bool foundResource = false;
                while (!foundResource)
                {
                    switch (Random.Range(0, 500) % 5)
                    {
                        case 0:
                            {
                                if (crystals > 0)
                                {
                                    Debug.Log("Turning on the crystal.");
                                    foundResource = true;
                                    crystals--;
                                }
                                break;
                            }
                        case 1:
                            {
                                if (organics > 0)
                                {
                                    Debug.Log("Turning on the organics.");
                                    foundResource = true;
                                    organics--;
                                }
                                break;
                            }
                        case 2:
                            {
                                if (metals > 0)
                                {
                                    Debug.Log("Turning on the metals.");
                                    foundResource = true;
                                    metals--;
                                }
                                break;
                            }
                        case 3:
                            {
                                if (people > 0)
                                {
                                    Debug.Log("Turning on the people.");
                                    foundResource = true;
                                    people--;
                                }
                                break;
                            }
                        case 4:
                            {
                                if (junk > 0)
                                {
                                    Debug.Log("Turning on the junk.");
                                    foundResource = true;
                                    junk--;
                                }
                                break;
                            }
                    }
                }
                nextEmitTime = Time.time + emitDelay;
            }
            else playingGame = false;
        }


    }

    public void StopMiniGame()
    {
        GameController.controller.StopMiniGame();

    }

    bool EmptyResources()
    {
        return (organics == 0 && people == 0 && junk == 0 && metals == 0 && crystals == 0);
    }
}
