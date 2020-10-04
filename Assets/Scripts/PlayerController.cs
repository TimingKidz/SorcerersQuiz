using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 Direction = Vector3.zero;
    public float speed = 10.0f;
    public float accelerationSpeed = 100.0f;
    private Vector3 Init = Vector3.zero;
    public bool isStunt = false;
    float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
/*        Init.x = Input.acceleration.x;
        Init.y = Input.acceleration.y;*/
        //Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStunt)
        {
            speed = 0.0f;
            if (Time.time >= currentTime + 5)
            {
                speed = 10.0f;
                isStunt = false;
            }
        }

        // float posX = Input.gyro.attitude.x;
        // float posY = Input.gyro.attitude.y;

        float posX = Input.GetAxis("Horizontal") * accelerationSpeed;
        float posY = Input.GetAxis("Vertical") * accelerationSpeed;
        /*
                float posX = Input.acceleration.x * accelerationSpeed;
                float posY = Input.acceleration.y * accelerationSpeed;*/

        Direction = new Vector3(0, posY, speed);
        //controller.Move(Direction * Time.deltaTime);
        Direction = transform.TransformDirection(Direction);
        transform.Rotate(0, posX*Time.deltaTime, 0);

        CollisionFlags flag = controller.Move(Direction * Time.deltaTime);
    }

    public void SpeedReducer(float s)
    {
        currentTime = Time.time;
        isStunt = true;
    }
}