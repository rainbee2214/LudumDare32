using UnityEngine;
using System.Collections;

public class Resource : MonoBehaviour
{
    public bool restart;

    protected bool clicked;
    protected bool shrink;
    protected Animator anim;

    protected float shrinkTime;
    protected float delay = 2f;
    protected float delta;

    MiniGameController mgc;

    void Awake()
    {
        delta = delay / 2f;
        anim = GetComponent<Animator>();
    }

    void GetMGC()
    {
        mgc = GameObject.FindGameObjectWithTag("MiniGameController").GetComponent<MiniGameController>();
    }

    void Update()
    {
        if (restart)
        {
            restart = false;
            Restart();
        }
        
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

    public void Restart()
    {
        if (anim == null) anim = GetComponent<Animator>();
        anim.SetTrigger("Restart");
    }

    void OnMouseDown()
    {
        Debug.Log("Resource");

        int r = 0;
        switch (gameObject.name.Substring(0, 4))
        {
            case "Crys": GameController.controller.Crystals = 1; r = 0; break;
            case "Orga": GameController.controller.Organics = 1; r = 1; break;
            case "Meta": GameController.controller.Metals = 1; r = 2; break;
            case "Peop": GameController.controller.People = 1; r = 3; break;
            case "Junk": GameController.controller.Junk = 1; r = 4; break;
            case "Hack": GameController.controller.HackingComputers = 1; r = 5; break;
            case "Defe": GameController.controller.DefenseComputers = 1; r = 6; break;
        }
        clicked = true;
        if (mgc == null) GetMGC();
        mgc.PlaySound(r);
    }
}
