using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreChecker : MonoBehaviour
{
    public TMP_Text Distancee;
    public TMP_Text Scoree;
    private float Score = PlayerMovement.A;
    private float Distance = PlayerMovement.B;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Distancee.text = "Distance: " + (Distance).ToString("0");
        Scoree.text = "Score: " + (Score).ToString("0");
        Debug.Log(Score + " Score");
        Debug.Log(Distance + " Distance");
    }
}
