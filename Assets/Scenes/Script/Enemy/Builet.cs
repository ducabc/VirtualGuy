using System.Collections;
using UnityEngine;

namespace Assets.Scenes.Script.Enemy
{
    public class Builet : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("Ground")|| collision.gameObject.CompareTag("Player"))
                Destroy(transform.gameObject);
        }
    }
}