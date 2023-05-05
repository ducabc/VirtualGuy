using Assets.Scenes.Script.Enemy.Boss;
using System.Collections;
using UnityEngine;

namespace Assets.Scenes.Script.Enemy
{
    public class BuiletBoss : MonoBehaviour
    {

        private float speed = 2;
        private float time = 3f;
        public Attack boss;
        // Start is called before the first frame update
        void Start()
        {
            boss = GameObject.FindObjectOfType<Attack>();
            if (boss.GetScale() < 0) speed = -2;
            else speed = 2;
        }

        // Update is called once per frame
        void Update()
        {
            transform.parent.position += speed * Time.deltaTime * transform.parent.right;
            if (time > 0) time -= Time.deltaTime;
            else Destroy(transform.parent.gameObject);
        }
    }
}