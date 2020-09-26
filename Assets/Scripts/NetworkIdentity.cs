using SocketIO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkIdentity : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private string id;
    [SerializeField]
    private bool isControlling;

    private SocketIOComponent socket;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSocketComponentReference(SocketIOComponent Socket)
    {
        socket = Socket;
    }

    private void Awake()
    {
        isControlling = false;
    }

    public void SetControllerID(string ID)
    {
        id = ID;
        if (Client.ClientId == ID)
            isControlling = true;
        else
            isControlling = false;
    }   

    public string GetID()
    {
        return id;
    }

    public bool GetIsControlling()
    {
        return isControlling;
    }

    public SocketIOComponent GetIsSocket()
    {
        return socket;
    }


}
