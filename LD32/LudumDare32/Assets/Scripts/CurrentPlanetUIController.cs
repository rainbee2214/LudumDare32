using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CurrentPlanetUIController : MonoBehaviour
{
    public GameObject panel;

    public Text planetNameText,
                crystalText,
                organicText,
                metalText,
                peopleText,
                junkText;

    bool isActive = false;

    public void TurnOn()
    {
        isActive = true;
        panel.SetActive(true);
    }

    public void TurnOff()
    {
        isActive = false;
        panel.SetActive(false);
    }

    void Start()
    {
        GameController.controller.planetUIController = this;
    }

    void Update()
    {
        if (isActive)
        {
            planetNameText.text = GameController.controller.CurrentPlanetName;
            crystalText.text = FormatText(GameController.controller.CurrentPlanetCrystals);
            organicText.text = FormatText(GameController.controller.CurrentPlanetOrganics);
            metalText.text = FormatText(GameController.controller.CurrentPlanetMetals);
            peopleText.text = FormatText(GameController.controller.CurrentPlanetPeople);
            junkText.text = FormatText(GameController.controller.CurrentPlanetJunk);
        }
    }

    string FormatText(int count)
    {
        return count + " x";
    }
}
