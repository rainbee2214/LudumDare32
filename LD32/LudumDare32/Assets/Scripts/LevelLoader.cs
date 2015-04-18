using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
    public bool clickToLoad = true;
    public string level = "Menu";
    public float delay = 1f;

    float loadTime;

    void Start()
    {
        loadTime = Time.time + delay;
    }

    void Update()
    {
        if (clickToLoad && Input.GetButtonDown("StartGame")) LoadLevel(level);
        else if (!clickToLoad && Time.time > loadTime) LoadLevel(level);
    }

    public void LoadLevel(string level)
    {
        Application.LoadLevel(level);
    }
}
