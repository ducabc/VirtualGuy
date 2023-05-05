using System.Collections;
using UnityEngine;

namespace Assets.Scenes.Script.Enemy
{
    public class Trunk : Animal
    {
        protected float speed = 1f;
        protected int petLife = 2;
        protected Animator trunk;
        protected float attackSpeed = 1f;

        public Transform[] movePoint;
        private void Start()
        {
            trunk = GetComponent<Animator>();
            InvokeRepeating("Attack", 2f, attackSpeed);
        }
        // Update is called once per frame
        void Update()
        {
            Move(this.speed, this.movePoint, gameObject);
        }

        public float GetScale()
        {
            return transform.localScale.x;
        }

        public void Damage()
        {
            //pig.SetTrigger("Hit");
            speed *= 2;
            petLife--;
            if (petLife == 0)
            {
                Destroy(gameObject);
            }
        }

        protected void Attack()
        {
            BuiletManager.instance.SpamBuilet("TrunkBuilet", transform.position,GetScale());
        }
    }
}