using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipLoader : MonoBehaviour
{
    public void GetShipColors(ref List<Sprite> shipColors)
    {
        shipColors = new List<Sprite>();
        shipColors.Add(Resources.Load("Assets/Sprites/Ships/playerShipBlue", typeof(Sprite)) as Sprite);
        shipColors.Add(Resources.Load("Assets/Sprites/Ships/playerShipRed", typeof(Sprite)) as Sprite);
        shipColors.Add(Resources.Load("Assets/Sprites/Ships/playerShipGreen", typeof(Sprite)) as Sprite);
        shipColors.Add(Resources.Load("Assets/Sprites/Ships/playerShipOrange", typeof(Sprite)) as Sprite);
    }
}
