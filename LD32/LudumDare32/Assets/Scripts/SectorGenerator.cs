using UnityEngine;
using System.Collections;

public class SectorGenerator : MonoBehaviour
{
    //This will generate a sector of space, and populate it with planets
    public float planetDistance = 200f;
    public float planetVariance = 25f;
    public int numPlanets = 10;
    public GameObject planetPrefab;

    void Start()
    {
        Vector3 planetPos;
        for (int i = 0; i < numPlanets; i++)
        {
            planetPos = new Vector3(planetDistance * i, 0, 0);
            planetPos.x += Random.Range(-planetVariance, +planetVariance);
            planetPos.y += Random.Range(-planetVariance, +planetVariance);
            Instantiate(planetPrefab, planetPos, Quaternion.identity);
        }
    }

    void Update()
    {

    }
}
