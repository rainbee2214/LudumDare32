using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour
{
    public bool paused = false;
    public GameObject pauseUI;

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (paused)
            {
                Time.timeScale = 1.0f;
                pauseUI.SetActive(false);
            }
            else
            {
                Time.timeScale = 0.0f;
                pauseUI.SetActive(true);
            }
            paused = !paused;
        }
    }
}
