using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFall : MonoBehaviour
{
    [SerializeField] protected float timeFall=1.5f;
    protected Rigidbody2D gf;
    // Start is called before the first frame update
    void Start()
    {
        gf = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            StartCoroutine(Fall());
        if(collision.gameObject.CompareTag("Hell"))
            Destroy(gameObject);
    }
    protected IEnumerator Fall()
    {
        yield return new WaitForSeconds(timeFall);
        gf.bodyType = RigidbodyType2D.Dynamic;
    }
}
