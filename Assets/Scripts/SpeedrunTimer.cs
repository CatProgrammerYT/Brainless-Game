using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedrunTimer : MonoBehaviour
{

    [HideInInspector]
    public DateTime startTime;
    [SerializeField]
    private Text speedrunTimerText;

    public List<DateTime> allLevelTime;

    private void Start()
    {
        speedrunTimerText = GameObject.Find("SpeedrunText").GetComponent<Text>();
        startTime = DateTime.Now;
    }

    private void Update()
    {
        speedrunTimerText.text = (DateTime.Now - startTime).ToString();
    }
}
