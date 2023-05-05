using System.Collections;
using UnityEngine;

namespace Assets.Scenes.Script.Enemy
{
    public class HeadAttack : MonoBehaviour
    {

        private float time = 4f;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.parent.position += -5f * Time.deltaTime * transform.parent.right;
            if (time > 0) time -= Time.deltaTime;
            else Destroy(transform.parent.gameObject);
        }
    }
}