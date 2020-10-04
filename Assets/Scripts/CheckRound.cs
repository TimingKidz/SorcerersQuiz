using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRound : MonoBehaviour
{
    public GameObject wallstart;
    public int round;

    // Start is called before the first frame update
    void Start()
    {
        wallstart.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.CompareTag("Player"))
        {
            wallstart.SetActive(false);
            round += 1;
        }
    }

    private void OnTriggerExit(Collider obj)
    {
        wallstart.SetActive(true);
    }
}
