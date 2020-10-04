using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendReturntoStart : MonoBehaviour
{

    public GameObject wallstart;
    void Start()
    {
        wallstart.SetActive(true);
    }
    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.CompareTag("Player"))
        {
            wallstart.SetActive(true);
        }

    }
}
