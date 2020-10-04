using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionTrigger : MonoBehaviour
{
    public GameObject Question;
    public GameObject gobj;
    public GameObject UI;
    int QCount;
    List<List<string>> Q;
    Client client;

    GenerateQuestion genQ;

    // Start is called before the first frame update
    void Start()
    {
        QCount = 0;
        client = gobj.GetComponent<Client>();
        genQ = UI.GetComponent<GenerateQuestion>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Q == null)
        {
            Q = client.Quiz;
        }
    }

    public void AnswerCheck(GameObject obj)
    {
        
    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.CompareTag("Player"))
        {
            Question.SetActive(true);
            Debug.Log(Q[QCount][0] + Q[QCount][1] + Q[QCount][2]);
            genQ.updateQ(Q[QCount++]);
        }
    }
}
