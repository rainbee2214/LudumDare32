﻿using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour
{
    //This class will control each individual planet
    //Each planet will have different levels of each resource
    //Junk, metal, organics, crystals, people

    int junk, metals, organics, cyrstals, people;
    float radius;

    void Awake()
    {
        //Get the planet radius from the collider
        radius = GetComponent<CircleCollider2D>().radius * 50;
        GetComponent<CircleCollider2D>().radius = (radius / 50f) * 1.25f;
        SetupPlanet();
    }

    public void Explode()
    {
        //Planet will explode and play an explosion animation and then turn itself off

        //Play animation

        gameObject.SetActive(false);
    }

    public void MineResource(string resourceName)
    {
        switch(resourceName)
        {
            case "Junk": if (junk > 0) junk--; break;
            case "Organics": if (organics > 0) organics--; break;
            case "Metals": if (metals > 0) metals--; break;
            case "Cyrstals": if (cyrstals > 0) cyrstals--; break;
            case "People": if (people > 0) people--; break;
            default: break;
        }
    }

    public void MineJunk() { if (junk > 0) junk--; }
    public void MineOrganics() { if (organics > 0) organics--; }
    public void MineMetals() { if (metals > 0) metals--; }
    public void MineCyrstals() { if (cyrstals > 0) cyrstals--; }
    public void MinePeople() { if (people > 0) people--; }

    public void SetupPlanet()
    {
        //Generate the levels of resources for each planet
        //Each planet, based on it's radius, will have a max quota of resources
        junk = 0; organics = 0; metals = 0; cyrstals = 0; people = 0;
        int count = 0;
        while (count < radius)
        {
            switch (Random.Range(0,500) % 10)
            {
                case 0: junk++; break;
                case 1: organics++; break;
                case 2: metals++; break;
                case 3: cyrstals++; break;
                case 4: people++; break;
                case 5: junk += 2; break;
                case 6: organics += 2; break;
                case 7: metals += 2; break;
                case 8: cyrstals += 2; break;
                case 9: people +=2; break;
                default: break; 
            }
            count++;
        }
        //PrintStats();
    }

    public void PrintStats()
    {
        Debug.Log("Radius: " + radius + "\nJunk: " + junk + "\nOrganics: " + organics + "\nMetals: " + metals + "\nCyrstals: " + cyrstals + "\nPeople: " + people);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Start game!");
            //Start planet mining game over planet.
        }
    }
}
