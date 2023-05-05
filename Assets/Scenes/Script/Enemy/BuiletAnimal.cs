using Assets.Scenes.Script.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuiletAnimal : MonoBehaviour
{
    private float speed = 2;
    private float time=3f;
    public Trunk trunk;
    // Start is called before the first frame update
    void Start()
    {
        trunk = GameObject.FindObjectOfType<Trunk>();
        if (trunk.GetScale() == 1) speed =-2;
        else speed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        Fly();
    }

    private void Fly()
    {
        transform.parent.position += speed * Time.deltaTime * transform.parent.right;
        if (time > 0) time -= Time.deltaTime;
        else Destroy(transform.parent.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player"))
            Destroy(transform.parent.gameObject);
    }

}
