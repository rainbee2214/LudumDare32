using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
    public float speed = 1f;
    Vector3 position;

    //References for lerping when player is dead
    bool playerDead = false;
    Vector3 lastCamPos, playerDeathPos;
    float journeyLength;
    float startTime;
    float lerpSpeed = 5f;
	
	void Update ()
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
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            c.gameObject.GetComponent<Player>().Explode();
            lastCamPos = transform.position;
            playerDeathPos = c.gameObject.transform.position;
            startTime = Time.time;
            journeyLength = Vector3.Distance(lastCamPos, playerDeathPos);
            playerDead = true;
        }
    }
}
