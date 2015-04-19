using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Image raceImage;
    public Text nameText;

    public Image shield1,
                 shield2,
                 shield3;

    public Text crystalText,
                organicText,
                metalText,
                peopleText,
                junkText;

    public Sprite awtinImage,
                  celidImage,
                  todoceImage,
                  quaitoImage;

    string[] nouns = {
                         "Explorer",
                         "Adventurer",
                         "Pathfinder",
                         "Experimenter",
                         "Pioneer",
                         "Seeker",
                         "Traveler",
                         "Pilgrim",
                         "Conquistador",
                         "Cosmonaut",
                         "Astronaut",
                         "Trailblazer",
                         "King",
                         "Queen",
                         "Prince",
                         "Jester",
                         "Mercenary",
                         "Entrepreneur",
                         "Hero",
                         "Pirate",
                         "Opportunist",
                         "Venturer",
                         "Wanderer",
                         "Voyager",
                         "Scout",
                         "Detective",
                         "Escort",
                         "Protagonist",
                         "Escort",
                         "Conqueror",
                         "Guard",
                         "Lookout",
                         "Patrol",
                         "Navigator",
                         "Pilot",
                         "Captain"
                     };

    void Start()
    {
        GameController.controller.uiController = this;
        GameController.controller.SetName();
    }

    public void UpdateResources(int crystalCount, int organicCount, int metalCount, int peopleCount, int junkCount)
    {
        crystalText.text = GetFormattedString(crystalCount);
        organicText.text = GetFormattedString(organicCount);
        metalText.text = GetFormattedString(metalCount);
        peopleText.text = GetFormattedString(peopleCount);
        junkText.text = GetFormattedString(junkCount);
    }

    public void SetName(int raceIndex, string name)
    {
        string race = "";
        switch (raceIndex)
        {
            case 0: raceImage.sprite = celidImage; race = "Celid"; break;
            case 1: raceImage.sprite = awtinImage; race = "Awtin"; break;
            case 2: raceImage.sprite = quaitoImage; race = "Quaito"; break;
            case 3: raceImage.sprite = todoceImage; race = "Todoce"; break;
        }
        nameText.text = name + " the " + race + " " + GetRandomNoun();
    }

    public void SetShields(int count)
    {
        switch (count)
        {
            case 0:
                {
                    shield1.color = Color.clear;
                    shield2.color = Color.clear;
                    shield3.color = Color.clear;
                    break;
                }
            case 1:
                {
                    shield1.color = Color.white;
                    shield2.color = Color.clear;
                    shield3.color = Color.clear;
                    break;
                }
            case 2:
                {
                    shield1.color = Color.white;
                    shield2.color = Color.white;
                    shield3.color = Color.clear;
                    break;
                }
            case 3:
                {
                    shield1.color = Color.white;
                    shield2.color = Color.white;
                    shield3.color = Color.white;
                    break;
                }
        }
    }

    string GetRandomNoun()
    {
        int index = Random.Range(0, 1000) % nouns.Length;
        return nouns[index];
    }

    string GetFormattedString(int count)
    {
        string s;
        if (count < 10) s = "x000" + count;
        else if (count >= 10 && count < 100) s = "x00" + count;
        else if (count >= 100 && count < 1000) s = "x0" + count;
        else s = "x" + count;
        return s;
    }
}
