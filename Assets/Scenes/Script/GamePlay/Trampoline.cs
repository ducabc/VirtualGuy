using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private Animator trampoline;

    private float jumpForce=5f;
    // Start is called before the first frame update
    void Start()
    {
        trampoline = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up) * jumpForce;
            trampoline.Play("JumpTrampoline");
        }
    }
}
