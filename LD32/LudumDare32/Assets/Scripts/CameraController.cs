using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
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

	void Update ()
    {
        if (stop)
        {
            if (moveToPlanet) //Lerp to the planet position
            {
                //Debug.Log("Moving to planet.");
                transform.position = Vector3.Lerp(transform.position, GameController.controller.CurrentPlanetLocation, Time.deltaTime * lerpSpeed);
                transform.position = new Vector3(transform.position.x, transform.position.y, -10);
            }
            else //Wait in place until the mining game is over
            {
                Debug.Log("Playing mini game.");
            }
        }
        else
        {
            if (playerDead) //Lerp to death site, lock at z of -10
            {
                transform.position = Vector3.Lerp(lastCamPos, playerDeathPos, ((Time.time - startTime) * lerpSpeed) / journeyLength);
                transform.position = new Vector3(transform.position.x, transform.position.y, -10);
            }
            else //Move Normally
            {
                position = transform.position;
                position.x += Time.deltaTime * speed;
                transform.position = position;
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
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().Explode();
            lastCamPos = transform.position;
            playerDeathPos = collision.gameObject.transform.position;
            startTime = Time.time;
            journeyLength = Vector3.Distance(lastCamPos, playerDeathPos);
            playerDead = true;
        }
    }
}
