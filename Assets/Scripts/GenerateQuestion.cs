using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GenerateQuestion : MonoBehaviour
{
    public GameObject chkRound;
    public GameObject gobj;
    public Text Fnum;
    public Text Snum;
    public Text Expression;
    public GameObject[] Question;
    public GameObject[] Ans;
    List<List<string>> Q;
    List<List<string>> A;
    List<List<string>> pos;
    Client client;
    int round;

    // Start is called before the first frame update
    void Start()
    {
        client = gobj.GetComponent<Client>();
    }

    // Update is called once per frame
    void Update()
    {
        if (chkRound.GetComponent<CheckRound>().round != 0)
        {
            round = chkRound.GetComponent<CheckRound>().round;
        }
        else
        {
            round = 1;
        }
        if (Q == null)
        {
            Q = client.Quiz;
        }
        if (A == null)
        {
            A = client.Ans;
        }
        else
        {
            updateAandQ();
        }
        if (pos == null)
        {
            pos = client.Pos;
        }
    }

    public void updateAandQ()
    {
        for (int i = 0; i < 5; i++)
        {
            /*Debug.Log(round);*/
            int index = ((round - 1) * 5) + i;
            for (int j = 0; j < 4; j++)
            {
                var t = "Ans/" + Ans[i].name + "/Ans" + (j+1);
                GameObject AnsPlane = GameObject.Find(t);
                /*Debug.Log(A[index][j]);*/
                AnsPlane.GetComponent<TextMeshPro>().text = A[index][j];
                AnsPlane.GetComponent<RectTransform>().localPosition = 
                    new Vector3(
                        AnsPlane.GetComponent<RectTransform>().localPosition.x, 
                        float.Parse(pos[index][j]), 
                        AnsPlane.GetComponent<RectTransform>().localPosition.z
                    );
                Question[i].GetComponent<QuestionTrigger>().QT = Q[index];
            }

        }
    }

    public void updateQ(List<string> QT)
    {
        /*Debug.Log(Q[index][0] + Q[index][1] + Q[index][2] + Q[index][3]);*/
        Fnum.text = QT[0];
        Expression.text = QT[1].Substring(1, QT[1].Length - 2);
        Snum.text = QT[2];
    }
}
