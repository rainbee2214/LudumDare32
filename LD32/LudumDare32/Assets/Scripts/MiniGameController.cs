using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MiniGameController : MonoBehaviour
{
    public List<GameObject> resources;

    public List<GameObject> crystalPool;
    public List<GameObject> organicsPool;
    public List<GameObject> metalsPool;
    public List<GameObject> peoplePool;
    public List<GameObject> junkPool;

    int topCrystal, topOrganics, topMetals, topPeople, topJunk;

    void Awake()
    {
        GetResources();
    }
    
    public void StartResource(string resourceType, Vector2 location)
    {
        switch (resourceType)
        {
            case "Crystals":
                {
                    crystalPool[topCrystal].transform.position = location;
                    crystalPool[topCrystal].GetComponent<Resource>().Restart();
                    topCrystal++;
                    if (topCrystal >= crystalPool.Count) topCrystal = 0;
                    break;
                }
            case "Organics":
                {
                    organicsPool[topOrganics].transform.position = location;
                    organicsPool[topOrganics].GetComponent<Resource>().Restart();
                    topOrganics++;
                    if (topOrganics >= organicsPool.Count) topOrganics = 0;
                    break;
                }
            case "Metals":
                {
                    metalsPool[topMetals].transform.position = location;
                    metalsPool[topMetals].GetComponent<Resource>().Restart();
                    topMetals++;
                    if (topMetals >= metalsPool.Count) topMetals = 0;
                    break;
                }
            case "People":
                {
                    peoplePool[topPeople].transform.position = location;
                    peoplePool[topPeople].GetComponent<Resource>().Restart();
                    topPeople++;
                    if (topPeople >= peoplePool.Count) topPeople = 0;
                    break;
                }
            case "Junk":
                {
                    junkPool[topJunk].transform.position = location;
                    junkPool[topJunk].GetComponent<Resource>().Restart();
                    topJunk++;
                    if (topJunk >= junkPool.Count) topJunk = 0;
                    break;
                }
        }
    }

    void GetResources()
    {
        resources = new List<GameObject>();
        resources.Add(Resources.Load("Assets/Prefabs/Resource/Crystals", typeof(GameObject)) as GameObject);
        resources.Add(Resources.Load("Assets/Prefabs/Resource/Organics", typeof(GameObject)) as GameObject);
        resources.Add(Resources.Load("Assets/Prefabs/Resource/Metals", typeof(GameObject)) as GameObject);
        resources.Add(Resources.Load("Assets/Prefabs/Resource/People", typeof(GameObject)) as GameObject);
        resources.Add(Resources.Load("Assets/Prefabs/Resource/Junk", typeof(GameObject)) as GameObject);

        crystalPool = new List<GameObject>();
        organicsPool = new List<GameObject>();
        metalsPool = new List<GameObject>();
        peoplePool = new List<GameObject>();
        junkPool = new List<GameObject>();

        BuildPool(ref crystalPool, resources[0], "Crystal");
        BuildPool(ref organicsPool, resources[1], "Organics");
        BuildPool(ref metalsPool, resources[2], "Metals");
        BuildPool(ref peoplePool, resources[3], "People");
        BuildPool(ref junkPool, resources[4], "Junk");
    }

    void BuildPool(ref List<GameObject> pool, GameObject obj, string name)
    {
        for (int i = 0; i < 10; i++) 
        {
            pool.Add(Instantiate(obj));
            pool[pool.Count - 1].name = name + (i + 1);
            pool[pool.Count - 1].transform.SetParent(transform);
        }
    }
}
