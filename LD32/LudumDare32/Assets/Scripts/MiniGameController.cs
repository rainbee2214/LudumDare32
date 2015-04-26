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

    AudioClip mineCrystalsSound, mineOrganicsSound, mineMetalsSound, minePeopleSound, mineJunkSound;
    AudioSource audioSource;

    int topCrystal, topOrganics, topMetals, topPeople, topJunk;

    void Awake()
    {
        GetResources();
        GetSounds();
    }
    
    void GetSounds()
    {
        mineCrystalsSound = Resources.Load("Assets/Audio/MineCrystalsSound", typeof(AudioClip)) as AudioClip;
        mineOrganicsSound = Resources.Load("Assets/Audio/MineOrganicsSound", typeof(AudioClip)) as AudioClip;
        mineMetalsSound = Resources.Load("Assets/Audio/MineMetalsSound", typeof(AudioClip)) as AudioClip;
        minePeopleSound = Resources.Load("Assets/Audio/MinePeopleSound", typeof(AudioClip)) as AudioClip;
        mineJunkSound = Resources.Load("Assets/Audio/MineJunkSound", typeof(AudioClip)) as AudioClip;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(int resource = 0)
    {
        Debug.Log("Playing sound.");
        switch(resource)
        {
            case 0: audioSource.PlayOneShot(mineCrystalsSound, 1f); break;
            case 1: audioSource.PlayOneShot(mineOrganicsSound, 1f); break;
            case 2: audioSource.PlayOneShot(mineMetalsSound, 1f); break;
            case 3: audioSource.PlayOneShot(minePeopleSound, 2f); break;
            case 4: audioSource.PlayOneShot(mineJunkSound, 1f); break;
        }
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
