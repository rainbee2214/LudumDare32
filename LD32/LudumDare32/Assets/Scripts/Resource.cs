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

    void Awake()
    {
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
    }

    public void Restart()
    {
        anim.SetTrigger("Restart");
    }

    void OnMouseDown()
    {
        switch (gameObject.name.Substring(0, 4))
        {
            case "Crys": GameController.controller.Crystals = 1; break;
            case "Orga": GameController.controller.Organics = 1; break;
            case "Meta": GameController.controller.Metals = 1; break;
            case "Peop": GameController.controller.People = 1; break;
            case "Junk": GameController.controller.Junk = 1; break;
        }
        anim.SetTrigger("Clicked");
    }
}
