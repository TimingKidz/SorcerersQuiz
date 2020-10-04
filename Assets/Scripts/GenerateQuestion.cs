using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GenerateQuestion : MonoBehaviour
{
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
        round = 0;
        client = gobj.GetComponent<Client>();
    }

    // Update is called once per frame
    void Update()
    {
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
        for (int i = 0; i < Ans.Length; i++)
        {
            int index = (round * 5) + i;
            for (int j = 1; j <= 4; j++)
            {
                var t = "Ans/" + Ans[i].name + "/Ans" + j;
                GameObject.Find(t).GetComponent<TextMeshPro>().text = A[index][j - 1];
                Question[i].GetComponent<QuestionTrigger>().QT = Q[index];
            }

        }
    }

    public void updateQ(List<string> QT)
    {
        /*Debug.Log(Q[index][0] + Q[index][1] + Q[index][2] + Q[index][3]);*/
        Fnum.text = QT[0].Substring(1, QT[0].Length - 2);
        Expression.text = QT[1].Substring(1, QT[0].Length - 2);
        Snum.text = QT[2].Substring(1, QT[0].Length - 2);
    }
}
