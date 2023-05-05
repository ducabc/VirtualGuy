using System.Collections;
using UnityEngine;

namespace Assets.Scenes.Script.Enemy
{
    public class BuiletRain : MonoBehaviour
    {

        private float speed = 3;
        private float time = 3f;
        public Attack boss;

        // Update is called once per frame
        void Update()
        {
            transform.parent.position += speed * Time.deltaTime * transform.parent.right;
            if (time > 0) time -= Time.deltaTime;
            else Destroy(transform.parent.gameObject);
        }
    }
}