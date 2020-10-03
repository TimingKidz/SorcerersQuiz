using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkTranform : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 oldPos;
    private Player player;
    private float standStillCounter = 0;
    private NetworkIdentity networkIdentity;

    void Start()
    {
        networkIdentity = GetComponent<NetworkIdentity>();
        oldPos = transform.position;
        player = new Player();
        player.posX = 0;
        player.posY = 0;
        player.posZ = 0;

        if(!networkIdentity.GetIsControlling())
        {
            enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (networkIdentity.GetIsControlling())
        {
            if(oldPos != transform.position)
            {
                oldPos = transform.position;
                standStillCounter = 0;
                SendData();
            }
            else
            {
                standStillCounter += Time.deltaTime;
                if(standStillCounter > 1)
                {
                    standStillCounter = 0;
                    SendData();
                }
            }
        }
    }

    private void SendData()
    {
        player.posX = Mathf.Round(transform.position.x * 1000.0f) / 1000.0f;
        player.posY = Mathf.Round(transform.position.y * 1000.0f) / 1000.0f;
        player.posZ = Mathf.Round(transform.position.z * 1000.0f) / 1000.0f;
        player.roY = Mathf.Round(transform.rotation.eulerAngles.y * 1000.0f) / 1000.0f;

        networkIdentity.GetIsSocket().Emit("updatepos", new JSONObject(JsonUtility.ToJson(player)));
    }
}

[Serializable]
public class Player
{
    public string id;
    public float posX;
    public float posY;
    public float posZ;
    public float roY;
}