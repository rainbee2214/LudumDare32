using UnityEngine;
using System.Collections;

public class Resource : MonoBehaviour
{
    public bool restart;

    bool clicked;
    bool shrink;
    Animator anim;

    float shrinkTime;
    float delay = 2f;
    float delta;

    MiniGameController mgc;

    void Awake()
    {
        mgc =GameObject.FindGameObjectWithTag("MiniGameController").GetComponent<MiniGameController>();
        delta = delay / 2f;
        anim = GetComponent<Animator>();
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
        anim.SetTrigger("Restart");
    }

    void OnMouseDown()
    {
        int r = 0;
        switch (gameObject.name.Substring(0, 4))
        {
            case "Crys": GameController.controller.Crystals = 1; r = 0; break;
            case "Orga": GameController.controller.Organics = 1; r = 1; break;
            case "Meta": GameController.controller.Metals = 1; r = 2; break;
            case "Peop": GameController.controller.People = 1; r = 3; break;
            case "Junk": GameController.controller.Junk = 1; r = 4; break;
        }
        clicked = true;
        mgc.PlaySound(r);
    }
}
