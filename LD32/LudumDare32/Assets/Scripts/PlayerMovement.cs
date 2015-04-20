using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    //This class will control all the player (ship) motion and movements
    //Up and down to move forwards and back, right and left to rotate around your center point

    public float speed = 2f;
    public float rotationSpeed = 3f;
    Vector2 position;
    Vector2 force;

    float rotation;

    void Awake()
    {
        position = transform.position;
    }

    public void Move(float distance)
    {
        position = transform.position;
        //Forward the distance amount (go backwards if it is negative) this will take an axis value
        force.Set(Mathf.Sin(-rotation)* -distance * Time.deltaTime * speed, Mathf.Cos(-rotation) * -distance * Time.deltaTime * speed);
        position += force;
        transform.position = position;
    }

    public void Rotate(float rotation)
    {
        //Rotate the rotation amount (go backwards if it is negative) this will take an axis value
        Vector3 angles = transform.localEulerAngles;
        angles.z -= rotation * rotationSpeed;

        transform.localEulerAngles = angles;
        this.rotation = transform.localEulerAngles.z * Mathf.PI / 180f;

    }
}
