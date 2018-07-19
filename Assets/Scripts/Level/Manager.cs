using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public TailGenerator generatorScript;
    public static Manager instance = null;

    // Use this for initialization
    public void Awake()
    {
        Debug.Log("Manager");
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        generatorScript = GetComponent<TailGenerator>();
        generatorScript.Start();

    }
}
