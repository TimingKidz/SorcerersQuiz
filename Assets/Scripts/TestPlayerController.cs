using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerController : MonoBehaviour
{
    public float speed;

    void Start()
    {
        
    }

    void Update()
    {
        float speedpersec = speed * Time.deltaTime;
        transform.Translate(0.0f, 0.0f, speedpersec);
    }
}
