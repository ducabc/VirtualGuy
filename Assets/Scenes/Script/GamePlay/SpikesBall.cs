using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesBall : MonoBehaviour
{

    //public float maxRota;
    //public float minRota;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}
