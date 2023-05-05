using Assets.Scenes.Script.Enemy;
using Assets.Scenes.Script.Enemy.Boss;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveB : MonoBehaviour
{
    protected float speed = 0.7f;
    protected int bossLife = 2;
    protected Animator boss;
    protected int currentPoint;
    protected float idleTime = 2f;
    protected GameObject player;
    protected bool getPositionPl = true;
    protected Vector3 playerPosition;

    public Transform[] movePoint;
    // Start is called before the first frame update
    void Awake()
    {
        boss = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnDisable()
    {
        Animation(false);
    }
    private void OnEnable()
    {
        Animation(true);
    }
    // Update is called once per frame
    void Update()
    {
        if(HPBoss.instance.CurrentHP() > 50)
        {
            Move(speed, movePoint);
        }
        else
        {
            if (getPositionPl)
            {
                playerPosition = player.transform.position;
                getPositionPl = false;
            }
            BossMoveLow();
        }
    }

    protected virtual void Move(float speed, Transform[] movePoint)
    {
        if (gameObject.transform.localScale.x > 0) currentPoint = movePoint.Length - 1;
        if (Vector2.Distance(movePoint[currentPoint].position, gameObject.transform.position) < .1f)
        {
            Animation(false);
            idleTime -= Time.deltaTime;
            if (idleTime <= 0)
            {
                Animation(true);
                idleTime = 2f;
                gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * (-1), gameObject.transform.localScale.y, 1);
                currentPoint++;
                if (currentPoint >= movePoint.Length) currentPoint = 0;
            }

        }
        
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, movePoint[currentPoint].position, speed * Time.deltaTime);
    }

    protected void BossMoveLow()
    {
        Vector3 target = new Vector3(playerPosition.x, transform.position.y, transform.position.z);
        //if (gameObject.transform.localScale.x > 0) currentPoint = movePoint.Length - 1;
        if (Vector2.Distance(target, gameObject.transform.position) < .1f)
        {
            Animation(false);
            idleTime -= Time.deltaTime;
            if (idleTime <= 0)
            {
                Animation(true);
                idleTime = 1f;
                playerPosition = player.transform.position;

            }
        }
        if (target.x > transform.position.x) gameObject.transform.localScale = new Vector3(0.5f, gameObject.transform.localScale.y, 1);
        if (target.x < transform.position.x) gameObject.transform.localScale = new Vector3(-0.5f, gameObject.transform.localScale.y, 1);
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, target, 1.5f * Time.deltaTime);
    }
    protected void Animation(bool active)
    {
        boss.SetBool("Moving", active);
    }
}
