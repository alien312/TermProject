using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public int coins = 0;
    public int distanceMax = 0;
    private int distanceFact = 0;
    public int immobilityTime = 0;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            coins++;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Edge")
        {
            Application.LoadLevel("GameOver");
        }

        if (collision.gameObject.tag == "Trap")
        {
            Animator animator = collision.gameObject.GetComponent<Animator>();
            if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Active"))
                Application.LoadLevel("GameOver");
        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            Debug.Log("Trap");
            Animator animator = collision.gameObject.GetComponent<Animator>();
            if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Active"))
                Application.LoadLevel("GameOver");
        }
    }

    IEnumerator Wait(float duration)
    {
        yield return new WaitForSeconds(duration);  
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(Wait(5));
            transform.Translate(-1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
            transform.Translate(1, 0, 0);

        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(0, 1, 0);
            distanceFact++;
            distanceMax = Mathf.Max(distanceMax, distanceFact);
            if (distanceFact == distanceMax)
                immobilityTime = 0;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(0, -1, 0);
            distanceFact--;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        immobilityTime++;
        if (immobilityTime == (1000 - distanceMax * 2))
            Application.LoadLevel("GameOver");
    }
}
