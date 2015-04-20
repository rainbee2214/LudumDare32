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
    float shipOffset = 0.6f;

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
    }

    void Rotate()
    {
        centerLocation = GameController.controller.CurrentPlanetLocation;
        radius = GameController.controller.CurrentPlanetRadius;
        position.x = Mathf.Cos(theta) * radius + centerLocation.x;
        position.y = Mathf.Sin(theta) * radius + centerLocation.y;
        theta += rotateDelay;
        if (theta >= Mathf.PI * 2) theta = 0;
        transform.position = position;
        nextRotateTime = Time.time + rotateDelay;

        transform.eulerAngles = new Vector3(0f, 0f, theta * 180 / Mathf.PI);
    }
}
