using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 Direction = Vector3.zero;
    public float speed = 5.0f;
    public float accelerationSpeed = 100.0f;
    private Vector3 Init = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Init.x = Input.acceleration.x;
        Init.y = Input.acceleration.y;
        //Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

        // float posX = Input.gyro.attitude.x;
        // float posY = Input.gyro.attitude.y;

        float posX = Input.GetAxis("Horizontal")*accelerationSpeed;
        float posY = Input.GetAxis("Vertical")*accelerationSpeed;

        //float posX = Input.acceleration.x - Init.x;
        //float posY = Input.acceleration.y - Init.y;

        Direction = new Vector3(0,0, speed);
        //controller.Move(Direction * Time.deltaTime);
        transform.Translate(0, posY*Time.deltaTime, speed * Time.deltaTime);
        transform.Rotate(0, posX * Time.deltaTime, 0);
    }
}