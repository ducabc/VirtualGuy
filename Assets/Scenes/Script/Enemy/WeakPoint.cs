using Assets.Scenes.Script.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPoint : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool hit = false;
    public bool playerIn = false;
    public PlayerStatic playerStatic;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerMark;
    // Start is called before the first frame update
    void Start()
    {
        rb = GameObject.FindObjectOfType<Rigidbody2D>();
    }

    private void Update()
    {
        if(PlayerInSight())
            playerIn = true;
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * boxCollider.gameObject.transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0,
            Vector2.left, 0, playerMark);
        if (hit.collider != null)
        {
            playerStatic = hit.transform.GetComponent<PlayerStatic>();
        }
        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * boxCollider.gameObject.transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.velocity = Vector2.up * 5f;
            hit = true;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}

