using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    Text time;
    public int maxMinutes = 3;

    void Awake()
    {
        time = GetComponent<Text>();
    }

    void Update()
    {
        UpdateTime();
    }

    void UpdateTime()
    {

        int seconds = ((int)Time.timeSinceLevelLoad);
        int minutes = seconds/60;
        int leftoverSeconds = seconds%60;
        time.text = minutes + ":" + (leftoverSeconds < 10 ? "0" : "") +leftoverSeconds;

        if (minutes >= maxMinutes)
        {
            if (Application.loadedLevelName == "Level") Application.LoadLevel("Between");
            if (Application.loadedLevelName == "HackLevel") Application.LoadLevel("EndGameBetween");
        }
    }
}
