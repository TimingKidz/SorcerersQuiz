using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 Direction = Vector3.zero;
    public float speed = 12.0f;
    public float rotateSpeed = 100.0f;
    public float vSpeed = 20.0f;
    private Vector3 Init = Vector3.zero;
    public bool isStunt = false;
    float currentTime;
    Vector3 theAcceleration;
    Vector3 accelerationSnapshot;
    // Start is called before the first frame update

    void CalibrateAccelerometer()
    {
        accelerationSnapshot = Input.acceleration;
      
    }

    void Start()
    {
        controller = GetComponent<CharacterController>();
        CalibrateAccelerometer();
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
            if (Time.time >= currentTime + 1.5)
            {
                speed = 12.0f;
                isStunt = false;
            }
        }

        // float posX = Input.gyro.attitude.x;
        // float posY = Input.gyro.attitude.y;
        /*
                float posX = Input.GetAxis("Horizontal") * rotateSpeed;
                float posY = Input.GetAxis("Vertical") * vSpeed;*/
       
        theAcceleration = Input.acceleration - new Vector3(0,accelerationSnapshot.y,0);

        /*
                float posX = Input.acceleration.x * accelerationSpeed;
                float posY = Input.acceleration.y * accelerationSpeed;*/
       
        float posX = theAcceleration.x * 150.0f;
        float posY = theAcceleration.y * 50.0f;
        Direction = new Vector3(0, posY, speed);
        //controller.Move(Direction * Time.deltaTime);
        Direction = transform.TransformDirection(Direction);
        transform.Rotate(0, posX*Time.deltaTime, 0);

        CollisionFlags flag = controller.Move(Direction * Time.deltaTime);
    }

    void OnGUI()
    {
        GUILayout.Label("");
        GUILayout.Label("");


        GUILayout.Label(accelerationSnapshot.x.ToString() + " " + accelerationSnapshot.y.ToString() + " " + accelerationSnapshot.z.ToString());
        GUILayout.Label(theAcceleration.x.ToString() + " " + theAcceleration.y.ToString() + " " + theAcceleration.z.ToString());
    }

    public void SpeedReducer(float s)
    {
        currentTime = Time.time;
        isStunt = true;
    }
}