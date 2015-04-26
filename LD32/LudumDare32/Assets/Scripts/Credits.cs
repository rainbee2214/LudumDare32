using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    Text text;
    bool startCredits = true;
    string[] lines;

    float nextCreditTime;
    float creditdelay = 0.5f;
    int count = 0;

    void Start()
    {
        text = GetComponent<Text>();
        lines = new string[10];
        lines[0] = "Created for Ludum Dare 32\n";
        lines[1] = "\n";
        lines[2] = " Theme: Unconventional Weapon\n";
        lines[3] = "\n";
        lines[4] = " April 17th-19th, 2015\n";
        lines[5] = "\n";
        lines[6] = "\n";
        lines[7] = " Sarah & Joel\n";
        lines[8] = "\n";
        lines[9] = " rainbee2214 & frozenfire92\n";

        nextCreditTime = Time.time + creditdelay;
    }

    void Update()
    {
        if (Time.time > nextCreditTime && count < 10)
        {
            text.text += lines[count];
            count++;
            nextCreditTime += creditdelay;
        }
    }

    
}
