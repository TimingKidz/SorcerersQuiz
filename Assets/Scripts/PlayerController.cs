using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 Direction = Vector3.zero;
    public float defaultSpeed = 12.0f;
    public float speed;
    public float rotateSpeed = 100.0f;
    public float vSpeed = 20.0f;
    private Vector3 Init = Vector3.zero;
    public bool isStunt = false;
    float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        speed = defaultSpeed;
        controller = GetComponent<CharacterController>();
/*        Init.x = Input.acceleration.x;
        Init.y = Input.acceleration.y;*/
        //Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        print(speed);
        if (isStunt)
        {
            speed = 0.0f;
            if (Time.time >= currentTime + 1.5)
            {
                speed = defaultSpeed;
                isStunt = false;
            }
        }

        // float posX = Input.gyro.attitude.x;
        // float posY = Input.gyro.attitude.y;

        float posX = Input.GetAxis("Horizontal") * rotateSpeed;
        float posY = Input.GetAxis("Vertical") * vSpeed;
        /*
                float posX = Input.acceleration.x * accelerationSpeed;
                float posY = Input.acceleration.y * accelerationSpeed;*/

        Direction = new Vector3(0, posY, speed);
        //controller.Move(Direction * Time.deltaTime);
        Direction = transform.TransformDirection(Direction);
        transform.Rotate(0, posX*Time.deltaTime, 0);

        CollisionFlags flag = controller.Move(Direction * Time.deltaTime);
    }

    public void SpeedReducer()
    {
        float cTime = Time.time;
        speed -= 1;
    }

    public void SpeedZero()
    {
        currentTime = Time.time;
        isStunt = true;
    }
}