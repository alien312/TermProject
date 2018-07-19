using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

    public GameObject manager;

    public void Awake()
    {
        Debug.Log("Loader");
        if (Manager.instance == null)
        {
            Instantiate(manager);
        }
    }
}
