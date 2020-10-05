using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ReducedSpeed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float PSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().speed;
        if (!ispressed)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().speed = 
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().defaultSpeed;
            return;
        }            
        // DO SOMETHING HERE        
        if (PSpeed >= 5.0f)
        {
            PSpeed -= 0.1f;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().speed = PSpeed;
        }
    }

    bool ispressed = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        ispressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ispressed = false;
    }
}
