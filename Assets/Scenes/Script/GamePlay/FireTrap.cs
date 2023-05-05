using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    protected Animator fire;
    protected float waitTime=4f;
    protected float timer=8f;

    // Start is called before the first frame update
    void Awake()
    {
        fire = GetComponent<Animator>();
    }

    private void Update()
    {
        if (timer > 0) timer -= Time.deltaTime;
        else 
        { 
            StartCoroutine(ActiveFire());
            timer += 9;
        }
    }

    public IEnumerator ActiveFire()
    {
        yield return new WaitForSeconds(waitTime);
        fire.SetBool("FireOn", true);
        gameObject.tag = "Trap";
        yield return new WaitForSeconds(waitTime);
        fire.SetBool("FireOn", false);
        gameObject.tag = "Untagged";
    }
}
