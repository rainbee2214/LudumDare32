using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(ShipLoader))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    //This class will control the player
    public List<Sprite> shipColors;
    [Range(0,3)]
    public int currentColor;
    int lastColor = -1;

    PlayerMovement movement;
    ShipLoader shipLoader;

    Animator anim;
    SpriteRenderer srenderer;



    void Awake()
    {
        srenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();
        shipLoader = GetComponent<ShipLoader>();
        shipLoader.GetShipColors(ref shipColors);
    }

    void Update()
    {
        if (lastColor != currentColor) ChangeShipColor();
        if (Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0) movement.Move(Input.GetAxisRaw("Vertical"));
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0) movement.Rotate(Input.GetAxisRaw("Horizontal"));
        
        if ((Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0) || (Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0))
            anim.SetBool("PlayerFlying", true);
        else anim.SetBool("PlayerFlying", false);
    }

    public void ChangeShipColor()
    {
        srenderer.sprite = shipColors[currentColor];
        lastColor = currentColor;
    }
}
