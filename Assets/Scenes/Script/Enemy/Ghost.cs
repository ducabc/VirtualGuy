using Assets.Scenes.Script.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Animal
{
    protected float speed = 1f;
    protected int petLife = 2;
    protected Animator ghost;
    private float time = 1f;
    public Transform[] movePoint;
    // Start is called before the first frame update
    void Start()
    {
        ghost = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move(this.speed, this.movePoint, gameObject);
        time -= Time.deltaTime;
        if (time <= 0)
        {
            StartCoroutine(WaitGhost(15));
            time = 20f;
        }
        
    }
    protected void GhostOn(bool active)
    {
         gameObject.GetComponent<BoxCollider2D>().enabled = active;
         ghost.SetBool("Ghost", active);
    }
    protected IEnumerator WaitGhost(float time)
    {
        yield return new WaitForSeconds(time/3);
        GhostOn(true);
        yield return new WaitForSeconds(time);
        GhostOn(false);
    }
}
