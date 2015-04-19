using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetupController : MonoBehaviour
{
    public GameObject[] shipSelect;
    public GameObject[] raceSelect;
    public InputField playerName;

    #region ResetUI
    void ResetShips()
    {
        for (int i = 0; i < shipSelect.Length; i++)
            shipSelect[i].SetActive(false);
    }

    void ResetRaces()
    {
        for (int i = 0; i < raceSelect.Length; i++)
            raceSelect[i].SetActive(false);
    }
    #endregion

    #region SetShip 
    //Sets the selected image on ship when clicked
    public void ShipButtonClick(GameObject overlay)
    {
        ResetShips();
        overlay.SetActive(true);
    }
    
    //Sets the type/color of ship when clicked
    public void ShipButtonSetType(int typeIndex) { GameController.controller.ShipType = typeIndex; }
    public void ShipButtonSetColor(int colorIndex) { GameController.controller.ShipColor = colorIndex; }
    #endregion

    #region SetRace
    //Sets the selected image on race when clicked
    public void RaceButtonClick(GameObject overlay)
    {
        ResetRaces();
        overlay.SetActive(true);
    }
    
    //Sets the index of race when clicked
    public void RaceButtonSetIndex(int typeIndex) { GameController.controller.RaceType = typeIndex; }
    #endregion

    public void SetPlayerName(InputField input){ GameController.controller.PlayerName = input.text; }
}
