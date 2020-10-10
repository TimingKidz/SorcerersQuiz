using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckRound : MonoBehaviour
{
    public GameObject gobj;
    public GameObject wallstart;
    public GameObject EndCanvas;
    public Text rank;
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
                GameObject.Find("Playing/SlowButton").SetActive(false);
                GameObject.Find("Playing/BoostButton").SetActive(false);
                EndCanvas.SetActive(true);
                isfin = true;
            }
        }
        
        if (client.range != -1)
        {
            Debug.Log(client.range);
            if (client.range == 1)
            {
                rank.text = "1st";
            }
            else if (client.range == 2)
            {
                rank.text = "2nd";
            }
            else if (client.range == 3)
            {
                rank.text = "3rd";
            }
            else
            {
                rank.text = client.range + "th";
            }
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
