using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using System;
using UnityEngine.UIElements;
using UnityEngine.UI;
using System.Linq;

public class Client : SocketIOComponent
{
    // Start is called before the first frame update

    [SerializeField]
    private Transform networkContianer;
    public static string ClientId;

    [SerializeField]
    private GameObject playerPrefeb;
    private Dictionary<string, GameObject> serverObjects;
    private Dictionary<string, NetworkIdentity> serverNet;

    public List<List<string>> Quiz;
    public List<List<string>> Ans;
    public List<List<string>> Pos;

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
  /*  this.Emit();*/


    private void setupEvents()
    {
        On("open", (E) =>
         {
             
             Debug.Log("EiEi");
         });

        On("Initail", (E) =>
         {
             this.Emit("xx", new JSONObject(JsonUtility.ToJson(new test())));
         });
        
        
        On("register", (E) =>
         {
             ClientId = E.data["id"].ToString();
             Debug.Log(ClientId);
             
         });

        On("spawn", (E) =>
        {
            string id = E.data["id"].ToString();
            var playerObject = Instantiate(playerPrefeb, networkContianer);
            playerObject.name = id;
            NetworkIdentity networkIdentity = playerObject.GetComponent<NetworkIdentity>();
            networkIdentity.SetControllerID(id);
            networkIdentity.SetSocketComponentReference(this);
            playerObject.transform.SetParent(networkContianer);
            playerObject.transform.position = new Vector3(E.data["posX"].f,E.data["posY"].f, E.data["posZ"].f);
            serverObjects.Add(id, playerObject);
            serverNet.Add(id, networkIdentity);


            if (networkIdentity.GetIsControlling())
            {
                string a = "[sever object parent]/" + ClientId + "/Camera";
                GameObject cam = GameObject.Find(a);
                playerObject.tag = "Player";
                cam.SetActive(true);
            }

        });

        On("MatchReady", (E) =>
        {
            GameObject tmp = GameObject.Find(ClientId);
            JSONObject quiz = E.data["Quiz"];
            JSONObject ans = E.data["Ans"];
            JSONObject pos = E.data["Pos"];
            Quiz = JsonTOArray(quiz);
            Ans = JsonTOArray(ans);
            Pos = JsonTOArray(pos);

            tmp.AddComponent<PlayerController>();
            
        });



        On("updatepos", (E) =>
        {
            var id = E.data["id"].ToString();
            float x = E.data["posX"].f;
            float y = E.data["posY"].f;
            float z = E.data["posZ"].f;
            float ry = E.data["roY"].f;
            Debug.Log(ry);
            GameObject networkIdentity = serverObjects[id];
            networkIdentity.transform.position = new Vector3(x, y, z);
            networkIdentity.transform.eulerAngles = new Vector3(0, ry, 0);

        });

    }

    public List<List<string>> JsonTOArray(JSONObject obj)
    {
        List<List<string>> temp1 = new List<List<string>>();
        List<string> temp2 = new List<string>();
        int i = 0;
        int j = 0;
        while (true)
        {
            j = 0;
            temp2 = new List<string>();
            if (obj[i] == null)
            {
                break;
            }
            while (true)
            {
                if (obj[i][j] == null)
                {
                    break;
                }
                temp2.Add(obj[i][j].ToString());
                j++;
            }
            temp1.Add(temp2);
            i++;
        }
        return temp1;
    }

    public void Initialize()
    {
        serverObjects = new Dictionary<string, GameObject>();
        serverNet = new Dictionary<string, NetworkIdentity>();

    }
}



[Serializable]
public class test
{
    public string text = "eiei";
   
}