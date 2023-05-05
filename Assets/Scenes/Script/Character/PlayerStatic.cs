using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStatic : MonoBehaviour
{
    public Rigidbody2D rb;
    protected Animator aniPlayer;
    public int indexScene;
    private float HP;
    private Transform TelePosi;

    public static PlayerStatic instance;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        aniPlayer = GetComponent<Animator>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        indexScene = 1;
        HP = 100f;
    }
    private void Start()
    {
        if (instance != null) return;
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            HP -= 10;
            if (HP > 0)
            {
                aniPlayer.SetTrigger("Hit");
            }
            else Die();
        }
        if (collision.gameObject.CompareTag("Hell"))
        {
            Die();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            if(indexScene<=2)
                SceneManager.LoadScene(indexScene + 1);
            else SceneManager.LoadScene(0);
        }
        if (collision.gameObject.CompareTag("Saw"))
        {
            HP -= 10;
            if (HP > 0)
            {
                aniPlayer.SetTrigger("Hit");
            }
            else Die();
        }
    }

    public float CurrentHP()
    {
        return this.HP;
    }
    public void DamegePlayer()
    {
        HP -= 20;
        if (HP > 0)
        {
            aniPlayer.SetTrigger("Hit");
        }
        else Die();
    }
    public void Die()
    {
        aniPlayer.SetTrigger("Death");
        rb.bodyType = RigidbodyType2D.Static;
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
