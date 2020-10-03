using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuntTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.CompareTag("Player"))
        {
            obj.gameObject.GetComponent<PlayerController>().SpeedReducer(0);
        }
    }
}
