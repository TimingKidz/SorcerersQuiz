using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 Direction = Vector3.zero;
    public float speed = 5.0f;
    public float accelerationSpeed = 50.0f;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        //Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

     //   float posX = Input.gyro.attitude.x;
     //   float posY = Input.gyro.attitude.y;
        float posX = Input.acceleration.x;
        float posY = Input.acceleration.y;
        Direction = new Vector3(posX*accelerationSpeed, posY*accelerationSpeed, speed);
        controller.Move(Direction*Time.deltaTime);
    }
}
