using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    Text text;

	void Start () {
        text = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        int distance = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().distanceMax;
        int coins = GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().coins;
        text.text = "MaxDistance: " + distance + "\n" + "Coins Collected: " + coins;
    }
}
