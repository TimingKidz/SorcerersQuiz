using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateQuation : MonoBehaviour
{
    public Text scoreText;
    public Text scoreText2;
    public Text scoreText3;
    int score;
    int score2;
    public string[] familyMembers;
    string O;
    // Start is called before the first frame update
    void Start()
    {
        //familyMembers = new string[] { "+", "-", "X", "÷" };
        O = familyMembers[Random.Range(0, 4)];
        score = Random.Range(1,11); 
        score2 = Random.Range(1, 11);
        scoreText.text = score.ToString();
        scoreText2.text = score2.ToString();
        scoreText3.text = O.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
