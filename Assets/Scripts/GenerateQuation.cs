using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateQuation : MonoBehaviour
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
        Fnum.text = "0";
        Snum.text = "0";
        Expression.text = "+";
    }
}
