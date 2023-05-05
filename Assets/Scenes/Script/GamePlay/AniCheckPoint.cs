using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniCheckPoint : MonoBehaviour
{
    protected Animator aniCheck;
    private void Awake()
    {
        aniCheck = GetComponent<Animator>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            aniCheck.SetBool("CheckPoint", true);
        }
    }
}
