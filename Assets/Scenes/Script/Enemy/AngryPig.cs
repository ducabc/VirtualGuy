using System.Collections;
using UnityEngine;

namespace Assets.Scenes.Script.Enemy
{
    public class AngryPig : Animal
    {
        protected float speed = 0.5f;
        protected Animator pig;
        public BoxCollider2D pigBox;
        public Transform[] movePoint;
        public WeakPoint weakPoint;


        public PlayerStatic playerStatic;
        [SerializeField] private float range;
        [SerializeField] private float colliderDistance;
        [SerializeField] private BoxCollider2D boxCollider;
        [SerializeField] private LayerMask playerMark;
        private void Start()
        {
            pig = GetComponent<Animator>();
            weakPoint = GetComponentInChildren<WeakPoint>();
            pigBox = GetComponent<BoxCollider2D>();
        }
        // Update is called once per frame
        void Update()
        {
            Move(this.speed, this.movePoint, gameObject);
            if (weakPoint.playerIn)
                Henshin();
            if (weakPoint.hit)
               Damage();
        }
        void Henshin()
        {
            if(speed < 1)
            {
                pig.SetTrigger("Henshin");
                speed *= 2;
            }
        }

        public void Damage()
        {
            pig.SetTrigger("Hit");
            speed = 0;
            GetComponent<Rigidbody2D>().gravityScale = 0.2f;
            weakPoint.enabled = false;
            pigBox.enabled = false;
            Invoke("Death", 10f);
        }

        public void Death()
        {
            Destroy(gameObject);
        }
    }
}