using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrapStay : MonoBehaviour {

    public void OnTriggerStay2D(Collider2D collision)
    {
        Animator animator = this.gameObject.GetComponent<Animator>();
        Debug.Log(animator.GetCurrentAnimatorStateInfo(0).tagHash);
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Active"))
            Application.LoadLevel("GameOver");
    }

    public void OnCollisionStay2D(Collision2D other)
    {
        Animator animator = this.gameObject.GetComponent<Animator>();
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Active"))
            Application.LoadLevel("GameOver");
    }

}
