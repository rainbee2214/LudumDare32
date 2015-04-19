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

    void Awake()
    {
        GetResources();
    }
    
    public void StartResource(string resourceType)
    {
        switch (resourceType)
        {
            case "Crystals": break;
            case "Organics": break;
            case "Metals": break;
            case "People": break;
            case "Junk": break;
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
