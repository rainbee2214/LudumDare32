using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipLoader : MonoBehaviour
{
    public void GetShipColors(ref List<Sprite> shipColors, int shipType = 1)
    {
        shipColors = new List<Sprite>();
        shipColors.Add(Resources.Load("Assets/Sprites/Ships/playerShip"+shipType+"Blue", typeof(Sprite)) as Sprite);
        shipColors.Add(Resources.Load("Assets/Sprites/Ships/playerShip"+shipType+"Red", typeof(Sprite)) as Sprite);
        shipColors.Add(Resources.Load("Assets/Sprites/Ships/playerShip"+shipType+"Green", typeof(Sprite)) as Sprite);
        shipColors.Add(Resources.Load("Assets/Sprites/Ships/playerShip"+shipType+"Orange", typeof(Sprite)) as Sprite);
    }
}
