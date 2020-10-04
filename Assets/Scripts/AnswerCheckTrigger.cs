using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerCheckTrigger : MonoBehaviour
{
    public GameObject Question;
    public GameObject gobj;
    public GameObject Q;
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
    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.CompareTag("Player"))
        {
            QTrigger.AnswerCheck(gameObject);
            Question.SetActive(false);
        }
    }
}
