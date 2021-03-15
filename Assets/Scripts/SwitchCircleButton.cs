using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SwitchCircleButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnRedButtonPressed()
    {
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().ChangeColour(GameManager.WorldColour.Red);
    }
    public void OnWhiteButtonPressed()
    {
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().ChangeColour(GameManager.WorldColour.White);
    }
    public void OnGreenButtonPressed()
    {
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().ChangeColour(GameManager.WorldColour.Green);
    }
    public void OnBlueButtonPressed()
    {
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().ChangeColour(GameManager.WorldColour.Blue);
    }
}
