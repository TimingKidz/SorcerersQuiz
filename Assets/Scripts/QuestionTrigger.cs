using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionTrigger : MonoBehaviour
{
    public GameObject Question;
    public GameObject gobj;
    public GameObject UI;
    public GameObject stuntPlane;
    public GameObject ansPlane;
    public List<string> QT;
    GenerateQuestion genQ;

    // Start is called before the first frame update
    void Start()
    {
        genQ = UI.GetComponent<GenerateQuestion>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AnswerCheck(GameObject obj)
    {
        /*ansPlane.SetActive(false);*/
        for (int i = 0; i < 4; i++)
        {
            if ((int.Parse(obj.name[3].ToString()) - 1).ToString() == QT[3].Substring(1, QT[3].Length - 2))
            {
                stuntPlane.SetActive(false);
                break;
            }
        }
    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.CompareTag("Player"))
        {
            Question.SetActive(true);
            ansPlane.SetActive(true);
            stuntPlane.SetActive(true);
            genQ.updateQ(QT);
        }
    }
}
