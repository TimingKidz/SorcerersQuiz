using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionTrigger : MonoBehaviour
{
    public GameObject canvas;
    public Text Fnum;
    public Text Snum;
    public Text Expression;
    List<List<string>> Q;
    Client client;
    GenerateQuation genQ;
    bool c = true;

    // Start is called before the first frame update
    void Start()
    {
        client = GameObject.Find("GameObject").GetComponent<Client>();
        genQ = GameObject.Find("UIController").GetComponent<GenerateQuation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (c && Q == null)
        {
            Q = client.Quiz;
            Debug.Log(Q[0]);
            c = false;
        }
    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.CompareTag("Player"))
        {
            canvas.SetActive(true);
            genQ.updateQ(Q[0]);
        }
    }
}
