using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryText : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scoreText;
    void Start()
    {
        if (GameObject.FindWithTag("VictoryCheck") != null)
        {
            if (GameObject.FindWithTag("VictoryCheck").GetComponent<VictoryCheck>().Victory)
            {
                gameObject.GetComponent<Text>().text = "Victory!";
            }
            else
            {
                gameObject.GetComponent<Text>().text = "Defeat";
            }
        }
        else
        {
            gameObject.GetComponent<Text>().text = "Defeat";
        }

        if (GameObject.FindWithTag("VictoryCheck") != null && scoreText != null)
        {
            scoreText.text = "Your score was " + GameObject.FindWithTag("VictoryCheck").GetComponent<VictoryCheck>().Score.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
