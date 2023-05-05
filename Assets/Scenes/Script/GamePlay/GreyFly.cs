using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyFly : MonoBehaviour
{
    public GameObject movePoint;
    private float speed=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePoint.transform.position, speed * Time.deltaTime);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            speed = 2;
            StartCoroutine(Damage(3f));
        }

    }

    private IEnumerator Damage(float timeDelay)
    {
        yield return new WaitForSeconds(timeDelay);
        Destroy(gameObject);
    }
}
