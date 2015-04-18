using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetupController : MonoBehaviour
{
    public Button[] ship;
    public Button[] race;
    public InputField name;

    void ResetShips()
    {
        for (int i = 0; i < ship.Length; i++)
            ship[i].GetComponentInChildren<GameObject>().SetActive(false);
    }

    void ResetRaces()
    {
        for (int i = 0; i < race.Length; i++)
            race[i].GetComponentInChildren<GameObject>().SetActive(false);   
    }

    public void ShipButtonClick(GameObject button)
    {
        ResetShips();
        button.GetComponentInChildren<GameObject>().SetActive(true);
    }

    public void RaceButtonClick(GameObject button)
    {
        ResetRaces();
        button.GetComponentInChildren<GameObject>().SetActive(true);
    }
}
