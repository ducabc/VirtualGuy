using Assets.Scenes.Script.Enemy.Boss;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaCheck : MonoBehaviour
{
    public GameObject door;
    public GameObject boss;

    private void Start()
    {
        door.SetActive(false);
        boss.SetActive(false);
    }
    private void Update()
    {
        if (HPBoss.instance.bossDie)
        {
            Destroy(door);
        } 

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            door.SetActive(true);
            boss.SetActive(true);
        }
    }

}
