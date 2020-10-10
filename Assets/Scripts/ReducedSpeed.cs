using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ReducedSpeed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    PlayerController playerController;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        float PSpeed = playerController.speed;
        if (!ispressed)
        {
            playerController.speed =
                playerController.defaultSpeed;
            return;
        }            
        // DO SOMETHING HERE        
        if (PSpeed >= 5.0f)
        {
            PSpeed -= 0.1f;
            playerController.speed = PSpeed;
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
