using UnityEngine;
using System.Collections;

public class HackingResource : Resource
{
    HackingGameController hackingGameController;

    void Awake()
    {
        hackingGameController = GameObject.FindGameObjectWithTag("HackingGameController").GetComponent<HackingGameController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Invisible"))
        {
            anim.ResetTrigger("Clicked");
            clicked = false;
        }

        if (clicked)
        {
            anim.SetTrigger("Clicked");
            clicked = false;
        }
    }

    void OnMouseDown()
    {
        //Debug.Log("Hacking resource");

        int r = 0;
        switch (gameObject.name.Substring(0, 4))
        {
            case "Hack": GameController.controller.HackingComputers = 1; r = 0; break;
            case "Defe": GameController.controller.DefenseComputers = 1; r = 1; break;
        }
        clicked = true;
        hackingGameController.PlaySound(r);
    }
    
}
