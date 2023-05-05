using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrownFly : MonoBehaviour
{
    public GameObject[] movePoint;
    public int currentPoint;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(movePoint[currentPoint].transform.position, transform.position) < .1f)
        {
            currentPoint++;
            if (currentPoint >= movePoint.Length)
            {
                currentPoint = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, movePoint[currentPoint].transform.position, speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
