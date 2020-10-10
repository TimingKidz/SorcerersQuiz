using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRound : MonoBehaviour
{
    public GameObject gobj;
    public GameObject wallstart;
    public int round;
    private NetworkIdentity networkIdentity;
    Client client;
    bool isfin = false;
    bool isSetnet = false;
    // Start is called before the first frame update
    void Start()
    {
        wallstart.SetActive(true);
        client = gobj.GetComponent<Client>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSetnet)
        {
            if (Client.ClientId != null && client.serverNet != null)
            {
                networkIdentity = client.serverNet[Client.ClientId];
                isSetnet = true;
            }

        }

        if (!isfin)
        {
            if (round == 2)
            {
                Debug.Log("sssss");
                GameObject.FindWithTag("Player").GetComponent<PlayerController>().setzero();
                networkIdentity.GetIsSocket().Emit("finish");
                isfin = true;
            }
        }
        
        if (client.range != -1)
        {
            Debug.Log(client.range);
        }
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
        if (obj.gameObject.CompareTag("Player"))
        {
            wallstart.SetActive(true);
        }
    }
}
