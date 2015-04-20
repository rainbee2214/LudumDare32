using UnityEngine;
using System.Collections;

public class RotateShip : MonoBehaviour
{
    public bool rotate = false;
    public Vector2 centerLocation;

    public float radius = 1f;
    public float rotateDelay = 0.005f;
    float rotationSpeed = 1f;
    float theta = 0;
    Vector2 position;
    float nextRotateTime;
    bool setValues;

    public void StartOrbit()
    {
        rotate = true;
    }

    public void StopOrbit()
    {
        rotate = false;
    }

    void Update()
    {
        if (rotate) Rotate();
        //if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.25 || Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.25) rotate = false;
    }

    void Rotate()
    {
        centerLocation = GameController.controller.CurrentPlanetLocation;
        radius = GameController.controller.CurrentPlanetRadius;
        Debug.Log("center " + centerLocation);
        position.x = Mathf.Cos(theta) * radius + centerLocation.x;
        position.y = Mathf.Sin(theta) * radius + centerLocation.y;
        theta += rotateDelay;
        if (theta >= Mathf.PI * 2) theta = 0;
        Debug.Log(position);
        transform.position = position;
        nextRotateTime = Time.time + rotateDelay;

        transform.eulerAngles = new Vector3(0f, 0f, theta * 180 / Mathf.PI);
    }
}
