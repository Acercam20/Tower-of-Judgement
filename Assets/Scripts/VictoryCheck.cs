using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryCheck : MonoBehaviour
{
    public bool Victory;
    public int Score;
    void Start()
    {
        DontDestroyOnLoad(this);
    }
}
