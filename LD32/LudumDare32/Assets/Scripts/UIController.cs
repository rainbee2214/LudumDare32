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
                junkText,
                hackingText,
                defenseText;

    Sprite awtinImage,
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

    bool setName = true;

    void Start()
    {
        GameController.controller.uiController = this;
    }

    void Update()
    {
        if (setName && Application.loadedLevelName == "Level") GameController.controller.SetName();
    }

    public void UpdateResources(int crystalCount, int organicCount, int metalCount, int peopleCount, int junkCount)
    {
        if (crystalText == null) crystalText = GameObject.FindGameObjectWithTag("CrystalsText").GetComponent<Text>();
        if (organicText == null) organicText = GameObject.FindGameObjectWithTag("OrganicsText").GetComponent<Text>();
        if (metalText == null) metalText = GameObject.FindGameObjectWithTag("MetalsText").GetComponent<Text>();
        if (peopleText == null) peopleText = GameObject.FindGameObjectWithTag("PeopleText").GetComponent<Text>();
        if (junkText == null) junkText = GameObject.FindGameObjectWithTag("JunkText").GetComponent<Text>();
        crystalText.text = GetFormattedString(crystalCount);
        organicText.text = GetFormattedString(organicCount);
        metalText.text = GetFormattedString(metalCount);
        peopleText.text = GetFormattedString(peopleCount);
        junkText.text = GetFormattedString(junkCount);
    }

    public void UpdateHackerResources(int hackingCount, int defenseCount)
    {
        if (hackingText == null) hackingText = GameObject.FindGameObjectWithTag("HackingText").GetComponent<Text>();
        if (defenseText == null) defenseText = GameObject.FindGameObjectWithTag("DefenseText").GetComponent<Text>();
        hackingText.text = GetFormattedString(hackingCount);
        defenseText.text = GetFormattedString(defenseCount);
    }

    public void SetName(int raceIndex, string name)
    {
        if (celidImage == null) GetAlienSprites();
        setName = false;
        string race = "";
        switch (raceIndex)
        {
            case 0: raceImage.sprite = celidImage; race = "Celid"; break;
            case 1: raceImage.sprite = todoceImage; race = "Todoce"; break; 
            case 2: raceImage.sprite = quaitoImage; race = "Quaito"; break;
            case 3: raceImage.sprite = awtinImage; race = "Awtin"; break;
        }
        if (nameText == null) nameText = GameObject.FindGameObjectWithTag("NameText").GetComponent<Text>();
        nameText.text = name + " the " + race + " " + GetRandomNoun();
    }

    public void SetShields(int count)
    {
        if (shield1 == null) GetShieldSprites();
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

    void GetAlienSprites()
    {
        raceImage = GameObject.FindGameObjectWithTag("RaceImage").GetComponent<Image>();
        awtinImage = Resources.Load("Assets/Sprites/Aliens/alienGreen_badge2", typeof(Sprite)) as Sprite;
        celidImage = Resources.Load("Assets/Sprites/Aliens/alienBlue_badge2", typeof(Sprite)) as Sprite;
        todoceImage = Resources.Load("Assets/Sprites/Aliens/alienYellow_badge2", typeof(Sprite)) as Sprite;
        quaitoImage = Resources.Load("Assets/Sprites/Aliens/alienPink_badge2", typeof(Sprite)) as Sprite;
    }

    void GetShieldSprites()
    {
        Sprite shieldImage = Resources.Load("Assets/Sprites/UI/shield_silver", typeof(Sprite)) as Sprite;
        shield1 = GameObject.FindGameObjectWithTag("Shield1").GetComponent<Image>();
        shield2 = GameObject.FindGameObjectWithTag("Shield2").GetComponent<Image>();
        shield3 = GameObject.FindGameObjectWithTag("Shield3").GetComponent<Image>();
    
    }
}
