using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public Mario _Mario;

    void Awake()
    {
        _Mario = GameObject.Find("Mario").GetComponent<Mario>();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        _Mario.isGrounded = true;
        _Mario._animator.SetBool("Jumping", false);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        _Mario.isGrounded = false;
    }
}