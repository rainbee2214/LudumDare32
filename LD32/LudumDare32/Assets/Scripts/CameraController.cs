using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraController : MonoBehaviour 
{
    public Animator shieldDamage;

    public bool stop = false;
    public float speed = 1f;
    Vector3 position;

    //References for lerping when player is dead
    bool playerDead = false;
    Vector3 lastCamPos, playerDeathPos;
    float journeyLength;
    float startTime;
    float lerpSpeed = 5f;

    public bool moveToPlanet = false;
    public float turnOnTime;
    public float lerpDelay = 0.8f;
    public bool readyToStart = false;

    bool shieldDown = false;

    void Start ()
    {
        stop = false;
        playerDead = false;
        moveToPlanet = false;
        readyToStart = false;
    }

	void Update ()
    {
        if (Application.loadedLevelName == "HackLevel")
        {
            transform.position = new Vector3(0f, 0f, -10f);
        }
        else
        {
            if (readyToStart && Time.time > turnOnTime)
            {
                stop = false;
                readyToStart = false;
            }
            if (stop)
            {
                if (moveToPlanet) //Lerp to the planet position
                {
                    //Debug.Log("Moving to planet.");
                    transform.position = Vector3.Lerp(transform.position, GameController.controller.CurrentPlanetLocation, Time.deltaTime * lerpSpeed);
                    transform.position = new Vector3(transform.position.x, transform.position.y, -10);
                }
                else //Still stopped but not moving towards the planet, lerp to the old position that we started at
                {
                    transform.position = Vector3.Lerp(transform.position, GameController.controller.StartingLocation, Time.deltaTime * lerpSpeed);
                    transform.position = new Vector3(transform.position.x, transform.position.y, -10);
                    //When we get to the startingLocation (within a small amount), start the movement again 
                }
            }
            else
            {
                if (playerDead) //Lerp to death site, lock at z of -10
                {
                    transform.position = Vector3.Lerp(lastCamPos, playerDeathPos, ((Time.time - startTime) * lerpSpeed*2) / journeyLength);
                    transform.position = new Vector3(transform.position.x, transform.position.y, -10);
                    //If camera has reached the death site, set the playerDead in gameController
                    if (transform.position.x == playerDeathPos.x)
                    {
                        playerDead = false;
                        GameController.controller.PlayerDead = true;
                    }

                }
                else //Player alive
                {
                    if (shieldDown) //Shield damage, lerp to damage site
                    {
                        transform.position = Vector3.Lerp(lastCamPos, playerDeathPos, ((Time.time - startTime) * lerpSpeed * 5) / journeyLength);
                        transform.position = new Vector3(transform.position.x, 0, -10);
                        if (transform.position.x == playerDeathPos.x)
                        {
                            shieldDamage.SetBool("TakingDamage", false);
                            shieldDown = false;
                        }
                    }
                    else //Move Normally
                    {
                        position = transform.position;
                        position.x += Time.deltaTime * speed;
                        transform.position = position;
                    }
                }
            }
        }
	}

    //Alert the player when approaching the boundary
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            string message;
            if (other.transform.position.x < transform.position.x) message = "Hurry Up!";
            else message = "Slow Down!";
            Debug.Log(message);
        }
    }

    //Explode the player as out of bounds
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && Application.loadedLevelName == "Level")
        {
            if (GameController.controller.ShieldCount > 0)
            {
                GameController.controller.ShieldCount = -1;
                lastCamPos = transform.position;
                playerDeathPos = collision.gameObject.transform.position;
                startTime = Time.time;
                journeyLength = Vector3.Distance(lastCamPos, playerDeathPos);
                shieldDown = true;
                shieldDamage.SetBool("TakingDamage", true);
            }
            else
            {
                collision.gameObject.GetComponent<Player>().Explode();
                lastCamPos = transform.position;
                playerDeathPos = collision.gameObject.transform.position;
                startTime = Time.time;
                journeyLength = Vector3.Distance(lastCamPos, playerDeathPos);
                playerDead = true;
                Debug.Log("Setting true in camera controller on scene " + Application.loadedLevelName);
            }
        }
    }
}
