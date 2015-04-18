using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SectorGenerator : MonoBehaviour
{
    public List<GameObject> planets;
    //This will generate a sector of space, and populate it with planets
    public float planetDistance = 50f;
    public float planetVariance = 15f;
    public int numPlanets = 10;

    public List<GameObject> currentPlanets;

    void Start()
    {
        GetPlanets();
        currentPlanets = new List<GameObject>();
        Vector3 planetPos;
        for (int i = 0; i < numPlanets; i++)
        {
            planetPos = new Vector3(planetDistance * i, 0, 0);
            planetPos.x += Random.Range(-planetVariance, +planetVariance);
            planetPos.y += Random.Range(-planetVariance, +planetVariance);
            currentPlanets.Add(Instantiate(planets[Random.Range(0, planets.Count)], planetPos, Quaternion.identity) as GameObject);
            currentPlanets[currentPlanets.Count - 1].name = "Planet" + (i + 1);
            currentPlanets[currentPlanets.Count - 1].transform.SetParent(transform);
        
        }
    }

    void Update()
    {

    }

    void GetPlanets()
    {
        planets = new List<GameObject>();
        int i = 1;
        while (i <= 50)
        {
            planets.Add(Resources.Load("Assets/Prefabs/Planets/Planet"+i++, typeof(GameObject)) as GameObject);
        }
    }
}
