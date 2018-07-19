using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

    Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update () {
        int time = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().immobilityTime;
        int d = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().distanceMax;
        text.text = "Time left: " + ((1000 - d*2) - time) / 100;
    }
}
