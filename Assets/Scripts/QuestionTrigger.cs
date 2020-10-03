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
    Client client;

    // Start is called before the first frame update
    void Start()
    {
        client = GameObject.Find("GameObject").GetComponent<Client>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.CompareTag("Player"))
        {
            canvas.SetActive(true);
            Fnum.text = "0";
            Snum.text = "0";
            Expression.text = "+";

        }
    }
}
