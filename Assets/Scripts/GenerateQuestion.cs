using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateQuestion : MonoBehaviour
{
    public Text Fnum;
    public Text Snum;
    public Text Expression;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateQ (List<string> Q)
    {
        Fnum.text = Q[0].Substring(1, Q[0].Length - 2);
        Expression.text = Q[1].Substring(1, Q[0].Length - 2);
        Snum.text = Q[2].Substring(1, Q[0].Length - 2);
    }
}
