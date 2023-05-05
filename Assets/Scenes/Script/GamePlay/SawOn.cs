using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawOn : MonoBehaviour
{
    public List<Transform> movePoint;
    protected int currentPoint;
    public float speed=0.5f;
    // Start is called before the first frame update
    void Start()
    {
        //GameObject move = GameObject.Find("MoveSaw");
        //foreach(Transform point in move.transform)
        //{
        //    movePoint.Add(point);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 180 * 3.5f * Time.deltaTime);
        if (Vector2.Distance(movePoint[currentPoint].position, transform.position) < .1f)
        {
            currentPoint++;
            if (currentPoint >= movePoint.Count)
            {
                currentPoint = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, movePoint[currentPoint].position, speed * Time.deltaTime);
    }
}
