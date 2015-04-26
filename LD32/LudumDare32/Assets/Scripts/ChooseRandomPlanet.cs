using UnityEngine;
using System.Collections;

public class ChooseRandomPlanet : MonoBehaviour
{
    Sprite planet;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        GetPlanet();
    }

    void GetPlanet()
    {
        int i = Random.Range(1, 51);
        planet = Resources.Load("Assets/Sprites/Planets/Planet" + i++, typeof(Sprite)) as Sprite;
        spriteRenderer.sprite = planet;
    }
}
