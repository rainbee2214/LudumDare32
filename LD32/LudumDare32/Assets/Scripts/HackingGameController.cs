using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HackingGameController : MonoBehaviour
{
    public List<GameObject> resources;

    public List<GameObject> hackingComputerPool;
    public List<GameObject> defenseComputerPool;

    AudioClip buildHackingComputer, buildDefenseComputer;
    AudioSource audioSource;

    int topHacking, topDefense;

    float nextEmitTime;
    public float emitDelay = 0.5f;

    public float resourceRange = 3f;

    void Awake()
    {
        GetResources();
        GetSounds();
    }

    void FixedUpdate()
    { 
        if (Time.time > nextEmitTime)
        {
            EmitResource();
            nextEmitTime = Time.time + emitDelay;
        }
    }

    public void EmitResource()
    {
        string type = "HackingComputer";
        if (Random.Range(0, 100) % 2 == 0) type = "DefenseComputer";
        Vector2 location = new Vector2(Random.Range(-resourceRange, resourceRange), Random.Range(-resourceRange, resourceRange));
        StartResource(type, location);
    }

    void GetSounds()
    {
        buildHackingComputer = Resources.Load("Assets/Audio/BuildHackingComputer", typeof(AudioClip)) as AudioClip;
        buildDefenseComputer = Resources.Load("Assets/Audio/BuildDefenseComputer", typeof(AudioClip)) as AudioClip;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(int resource = 0)
    {
        Debug.Log("Playing sound.");
        switch (resource)
        {
            case 0: audioSource.PlayOneShot(buildHackingComputer, 1f); break;
            case 1: audioSource.PlayOneShot(buildDefenseComputer, 1f); break;
        }
    }

    public void StartResource(string resourceType, Vector2 location)
    {
        switch (resourceType)
        {
            case "HackingComputer":
                {
                    hackingComputerPool[topHacking].transform.position = location;
                    hackingComputerPool[topHacking].GetComponent<Resource>().Restart();
                    topHacking++;
                    if (topHacking >= hackingComputerPool.Count) topHacking = 0;
                    break;
                }
            case "DefenseComputer":
                {
                    defenseComputerPool[topDefense].transform.position = location;
                    defenseComputerPool[topDefense].GetComponent<Resource>().Restart();
                    topDefense++;
                    if (topDefense >= defenseComputerPool.Count) topDefense = 0;
                    break;
                }
        }
    }

    void GetResources()
    {
        resources = new List<GameObject>();
        resources.Add(Resources.Load("Assets/Prefabs/Resource/HackingComputer", typeof(GameObject)) as GameObject);
        resources.Add(Resources.Load("Assets/Prefabs/Resource/DefenseComputer", typeof(GameObject)) as GameObject);

        hackingComputerPool = new List<GameObject>();
        defenseComputerPool = new List<GameObject>();

        BuildPool(ref hackingComputerPool, resources[0], "HackingComputer");
        BuildPool(ref defenseComputerPool, resources[1], "DefenseComputer");

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
