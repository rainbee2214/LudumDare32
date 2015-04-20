using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SectorGenerator : MonoBehaviour
{
    public List<GameObject> planets;
    //This will generate a sector of space, and populate it with planets
    public float planetDistance = 15f;
    public float planetVariance = 5f;
    public int numPlanets = 10;

    public List<GameObject> currentPlanets;

    List<string> planetNames;

    string[] names = { 
                        "Moexd 125",
                        "Ymsn",
                        "D-Umoyr",
                        "Yapuv",
                        "Eyrzocuif",
                        "Dien",
                        "Siuzra",
                        "Mul-cy",
                        "Tsdhox",
                        "Yokeycy",
                        "Ueoeeex",
                        "Ejfmy-i",
                        "Xdnaiia",
                        "E-Hciyia",
                        "Oi-Alfo",
                        "Tcroo 141",
                        "Nyfaahk",
                        "Upvb",
                        "Uo-uqjszaxo 310",
                        "Oye-Ut",
                        "Mbekqtigigy",
                        "Ru-Ro 151",
                        "Pbloey",
                        "Aaaxuadave 545",
                        "Noeihabiee 235",
                        "Osrpgkginy",
                        "Ogiqiooa",
                        "Byryo",
                        "Dklmli",
                        "El-Kl",
                        "Uuecoz",
                        "Efyooy",
                        "Kxic 147",
                        "Ae-Ne",
                        "Oeunlz 86",
                        "Gyskevigum",
                        "Oouuta-b",
                        "Uaier",
                        "Omsap",
                        "Eyhnox",
                        "Oxia",
                        "Yvuyj 122",
                        "Iiu-Ugepdy",
                        "Iooeyvuu 50",
                        "Nueiyud",
                        "Arduu",
                        "Beui",
                        "Aq-Kciaa",
                        "Ratoapa",
                        "Gecbu 358"    
                     };


    void Start()
    {
        //Setup planet names and shuffle
        planetNames = new List<string>(names);
        for (int i = 0; i < planetNames.Count; i++)
        {
            string temp = planetNames[i];
            int randomIndex = Random.Range(i, planetNames.Count);
            planetNames[i] = planetNames[randomIndex];
            planetNames[randomIndex] = temp;
        }

        GetPlanets();
        currentPlanets = new List<GameObject>();
        Vector3 planetPos;
        for (int i = 1; i < numPlanets; i++)
        {
            planetPos = new Vector3(planetDistance * i, 0, 0);
            planetPos.x += Random.Range(-planetVariance/2f, +planetVariance/2f);
            planetPos.y += Random.Range(-planetVariance, +planetVariance);
            currentPlanets.Add(Instantiate(planets[Random.Range(0, planets.Count)], planetPos, Quaternion.identity) as GameObject);
            currentPlanets[currentPlanets.Count - 1].name = "Planet" + (i + 1);
            currentPlanets[currentPlanets.Count - 1].transform.SetParent(transform);
            currentPlanets[currentPlanets.Count - 1].GetComponent<Planet>().currentName = planetNames[i];
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
            planets.Add(Resources.Load("Assets/Prefabs/Planets/Planet" + i++, typeof(GameObject)) as GameObject);
        }
    }
}
