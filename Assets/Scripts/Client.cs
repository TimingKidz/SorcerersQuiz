using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using System;
using UnityEngine.UIElements;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class Client : SocketIOComponent
{
    // Start is called before the first frame update

    [SerializeField]
    private Transform networkContianer;

    public static string ClientId;

    [SerializeField]
    private GameObject playerPrefeb;
    private Dictionary<string, GameObject> serverObjects;
    public  Dictionary<string, NetworkIdentity> serverNet;
    public Text NubText;

    public List<List<string>> Quiz;
    public List<List<string>> Ans;
    public List<List<string>> Pos;


    public int time = -1;
    public int latency = -1;
    public int nub = -1;
    public int miliTime = -1;
    public int range = -1;
    bool chk = true;

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
        if (time != -1)
        {
            DateTime t = DateTime.Now;

            miliTime = (t.Minute * 60 * 1000 + t.Second * 1000 + t.Millisecond) - latency;
            nub = (time - miliTime)/1000;
            if(nub > 0)
            {
                NubText.text = nub.ToString();
            }
            else
            {
                NubText.text = "";
            }
            
            if ( miliTime >= time && chk)
            {

                GameObject tmp = GameObject.Find(ClientId);
                tmp.AddComponent<PlayerController>();
                chk = false;
            }
        }
    }
    /*this.Emit();*/


    private void setupEvents()
    {
        On("open", (E) =>
         {
            
         });


        On("Initail", (E) =>
        {
            playerid tmp = new playerid();
            tmp.id = authmanage.instance.User.UserId;
            tmp.name = authmanage.instance.User.DisplayName;
            this.Emit("Initail", new JSONObject(JsonUtility.ToJson(tmp)));
        });

        On("joinroom", (E) =>
        {
            this.Emit("joinroom");
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
            playerObject.transform.eulerAngles = new Vector3(0, E.data["roY"].f, 0);
            string f = "[sever object parent]/" + id + "/PlayerName";
            GameObject.Find(f).GetComponent<TextMeshPro>().text = E.data["username"].ToString().Substring(1, E.data["username"].ToString().Length - 2);
            serverObjects.Add(id, playerObject);
            serverNet.Add(id, networkIdentity);


            if (networkIdentity.GetIsControlling())
            {
                string a = "[sever object parent]/" + ClientId + "/Camera";
                GameObject cam = GameObject.Find(a);
                playerObject.tag = "Player";
                GameObject.Find(f).SetActive(false);
                cam.SetActive(true);
            }

        });

        On("MatchReady", (E) =>
        {
            JSONObject quiz = E.data["Quiz"];
            JSONObject ans = E.data["Ans"];
            JSONObject pos = E.data["Pos"];
            time = int.Parse(E.data["Time"].ToString());
            int Stime = int.Parse(E.data["Timenow"].ToString());
            DateTime t = DateTime.Now;
            latency = (t.Minute * 60 * 1000 + t.Second * 1000 + t.Millisecond) - Stime;
            
            Quiz = JsonTOArray(quiz);
            Ans = JsonTOArray(ans);
            Pos = JsonTOArray(pos);
        });

        On("discon", (E) =>
        {
            Destroy(GameObject.Find(E.data["id"].ToString()));
        });


        On("updatepos", (E) =>
        {
            var id = E.data["id"].ToString();
            float x = E.data["posX"].f;
            float y = E.data["posY"].f;
            float z = E.data["posZ"].f;
            float ry = E.data["roY"].f;
            GameObject networkIdentity = serverObjects[id];
            networkIdentity.transform.position = new Vector3(x, y, z);
            networkIdentity.transform.eulerAngles = new Vector3(0, ry, 0);

        });

        On("finish", (E) =>
        {
            range = int.Parse(E.data["No"].ToString());
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

    void OnGUI()
    {
        GUILayout.Label("");
        GUILayout.Label("");

        GUILayout.Label("     "+nub.ToString());
    }
    public void Initialize()
    {
        serverObjects = new Dictionary<string, GameObject>();
        serverNet = new Dictionary<string, NetworkIdentity>();

    }

    public void Disconect()
    {
       Close();
    }
}
    


[Serializable]
public class playerid
{
    public string id;
    public string name;
   
}