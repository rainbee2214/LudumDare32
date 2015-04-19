using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(ShipLoader))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    //This class will control the player, add in numberOfLives

    List<Sprite> ship1Colors;
    List<Sprite> ship2Colors;
    List<Sprite> ship3Colors;

    [Range(0,3)]
    public int currentColor;
    int lastColor = -1;
    [Range(0, 2)]
    public int currentShipType;
    int lastShipType = -1;

    PlayerMovement movement;
    ShipLoader shipLoader;

    Animator anim;
    SpriteRenderer srenderer;

    //Reference for death explosion
    public GameObject explosion;
    bool exploding = false;

    void Awake()
    {
        srenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();

        //Load in player choices for ships
        shipLoader = GetComponent<ShipLoader>();
        shipLoader.GetShipColors(ref ship1Colors, 1);
        shipLoader.GetShipColors(ref ship2Colors, 2);
        shipLoader.GetShipColors(ref ship3Colors, 3);
    }

    void Start()
    {
        currentColor = GameController.controller.ShipColor;
        currentShipType = GameController.controller.ShipType;
    }

    void Update()
    {
        if (lastColor != currentColor || lastShipType != currentShipType) ChangeShipColor();
        if (Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0) movement.Move(Input.GetAxisRaw("Vertical"));
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0) movement.Rotate(Input.GetAxisRaw("Horizontal"));
        
        if ((Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0) || (Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0))
            anim.SetBool("PlayerFlying", true);
        else anim.SetBool("PlayerFlying", false);
    }

    public void ChangeShipColor()
    {
        switch (currentShipType)
        {
            case 0: srenderer.sprite = ship1Colors[currentColor]; break;
            case 1: srenderer.sprite = ship2Colors[currentColor]; break;
            case 2: srenderer.sprite = ship3Colors[currentColor]; break;
        }
        
        lastColor = currentColor;
        lastShipType = currentShipType;
    }

    public void Explode()
    {
        if (explosion != null && !exploding)
        {
            exploding = true;
            Instantiate(explosion, transform.position, transform.rotation);
            GameObject.Destroy(this.gameObject);
        }
    }
}
