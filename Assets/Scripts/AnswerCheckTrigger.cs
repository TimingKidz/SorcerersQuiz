using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerCheckTrigger : MonoBehaviour
{
    public GameObject gobj;
    public GameObject Q;
    List<List<string>> A;
    Client client;
    QuestionTrigger QTrigger;

    // Start is called before the first frame update
    void Start()
    {
        client = gobj.GetComponent<Client>();
        QTrigger = Q.GetComponent<QuestionTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (A == null)
        {
            A = client.Quiz;
        }
    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.CompareTag("Player"))
        {
            QTrigger.AnswerCheck(gameObject);
        }
    }
}
