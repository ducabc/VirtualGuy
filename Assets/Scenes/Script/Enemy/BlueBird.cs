using System.Collections;
using UnityEngine;

namespace Assets.Scenes.Script.Enemy
{
    public class BlueBird : Animal
    {
        protected float speed = 1f;
        protected int petLife = 1;
        protected Animator bird;
        public Transform[] movePoint;
        private void Start()
        {
            bird = GetComponent<Animator>();
        }
        // Update is called once per frame
        void Update()
        {
            Move(this.speed, this.movePoint, gameObject);

        }


        public void Damage()
        {
            bird.SetTrigger("Hit");
        }

        public void Death()
        {
            Destroy(gameObject);
        }
    }
}