﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using System;
using UnityEngine.UIElements;

public class Client : SocketIOComponent
{
    // Start is called before the first frame update

    [SerializeField]
    private Transform networkContianer;
    public static string ClientId;

    [SerializeField]
    private GameObject playerPrefeb;
    private Dictionary<string, NetworkIdentity> serverObjects;
    public override void Start()
    {
        base.Start();
        Initialize();
        setupEvents();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    private void setupEvents()
    {
        On("open", (E) =>
         {
             Debug.Log("EiEi");
         });

        On("register", (E) =>
         {
             ClientId = E.data["id"].ToString();
             Debug.Log(ClientId);
         });

        On("spawn", (E) =>
        {
            Debug.Log(E.data.ToString());
            string id = E.data["id"].ToString();
            var playerObject = Instantiate(playerPrefeb, networkContianer);
            playerObject.name = id;
            NetworkIdentity networkIdentity = playerObject.GetComponent<NetworkIdentity>();
            networkIdentity.SetControllerID(id);
            networkIdentity.SetSocketComponentReference(this);
            playerObject.transform.SetParent(networkContianer);
            serverObjects.Add(id, networkIdentity);

        });

        On("updatepos", (E) =>
        {
            var id = E.data["id"].ToString();
            float x = E.data["posX"].f;
            float y = E.data["posY"].f;
            float z = E.data["posZ"].f;
       
            NetworkIdentity networkIdentity = serverObjects[id];
            
            networkIdentity.transform.position = new Vector3(x, y, z);

        });
    }

    public void Initialize()
    {
        serverObjects = new Dictionary<string, NetworkIdentity>();
    }
}


