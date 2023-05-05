using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Vector3 offSet = new Vector3(0.5f, 0f, -1f);
    protected Vector3 cameraFollow;
    
    protected Transform target;
    // Start is called before the first frame update
    
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null) return;
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Follow();
    }
    void Follow()
    {
        cameraFollow = new Vector3(Mathf.Clamp(target.transform.position.x, -3f , 20f),
            Mathf.Clamp(target.transform.position.y , 0, 2f), target.position.z) + offSet;
        transform.position = cameraFollow;
    }
}
