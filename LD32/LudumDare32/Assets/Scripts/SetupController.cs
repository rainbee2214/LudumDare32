using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetupController : MonoBehaviour
{
    public GameObject[] shipSelect;
    public GameObject[] raceSelect;
    public InputField playerName;

    int selectedRace = 0;
    int selectedShipType = 0;
    int selectedShipColor = 0;

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

    //Sets the selected image on ship when clicked
    public void ShipButtonClick(GameObject overlay)
    {
        ResetShips();
        overlay.SetActive(true);
    }
    
    //Sets the type/color of ship when clicked
    public void ShipButtonSetType(int typeIndex) { selectedShipType = typeIndex; }
    public void ShipButtonSetColor(int colorIndex) { selectedShipColor = colorIndex; LogSelection(); }

    //Sets the selected image on race when clicked
    public void RaceButtonClick(GameObject overlay)
    {
        ResetRaces();
        overlay.SetActive(true);
    }
    
    //Sets the index of race when clicked
    public void RaceButtonSetIndex(int typeIndex) { selectedRace = typeIndex; LogSelection(); }

    void LogSelection()
    {
        Debug.Log("Selected Ship - Type: " + selectedShipType + " Color: " + selectedShipColor + "   Selected Race: " + selectedRace);
    }
}
