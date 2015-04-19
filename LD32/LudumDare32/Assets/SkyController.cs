using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkyController : MonoBehaviour
{
    List<Sprite> skySprites;
    SpriteRenderer[] skyPieces;

    [Range(0, 4)]
    public int currentSkyColor;
    int lastSkyColor;

    void Start()
    {
        GetSkySprites();
        skyPieces = GetComponentsInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (lastSkyColor != currentSkyColor) ChangeSkyColor();
    }

    public void ChangeSkyColor(int newColor = -1)
    {
        if (newColor != -1) currentSkyColor = newColor;
        foreach (SpriteRenderer sr in skyPieces)
        {
            sr.sprite = skySprites[currentSkyColor];
        }
        lastSkyColor = currentSkyColor;
    }

    void GetSkySprites()
    {
        skySprites = new List<Sprite>();
        skySprites.Add(Resources.Load("Assets/Sprites/Backgrounds/BlueStars", typeof(Sprite)) as Sprite);
        skySprites.Add(Resources.Load("Assets/Sprites/Backgrounds/BlackStars", typeof(Sprite)) as Sprite);
        skySprites.Add(Resources.Load("Assets/Sprites/Backgrounds/GreenStars", typeof(Sprite)) as Sprite);
        skySprites.Add(Resources.Load("Assets/Sprites/Backgrounds/PurpleStars", typeof(Sprite)) as Sprite);
        skySprites.Add(Resources.Load("Assets/Sprites/Backgrounds/RedStars", typeof(Sprite)) as Sprite);
    }
}
