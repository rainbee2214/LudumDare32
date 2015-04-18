using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    //This class will control the player

    PlayerMovement movement;
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0) movement.Move(Input.GetAxisRaw("Vertical"));
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0) movement.Rotate(Input.GetAxisRaw("Horizontal"));
        
        if ((Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0) || (Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0))
            anim.SetBool("PlayerFlying", true);
        else anim.SetBool("PlayerFlying", false);
    }
}
