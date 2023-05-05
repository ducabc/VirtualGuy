using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDestroy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            StartCoroutine(Damege());
    }

    private IEnumerator Damege()
    {
        yield return new WaitForSeconds(1.2f);
        Destroy(gameObject);
    }
}
