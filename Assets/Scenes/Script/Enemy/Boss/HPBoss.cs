using System.Collections;
using UnityEngine;

namespace Assets.Scenes.Script.Enemy.Boss
{
    public class HPBoss : MonoBehaviour
    {
        public static HPBoss instance;
        protected float maxHP=100f;
        protected Animator boss;
        private float damge;
        public float HP;
        public bool bossDie = false;

        private void Awake()
        {
            if (instance != null) return;
            instance = this;
        }
        // Use this for initialization
        void Start()
        {
            HP = maxHP;
            boss = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                HP -= 50;
            }
        }

        public float CurrentHP()
        {
            return this.HP;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("BuiletPlayer"))
            {
                HP -= SetDamage();
            }
            if (HP <= 0)
            {
                bossDie = true;
                boss.SetTrigger("BossDie");
            }
        }

        public bool ActiveBar()
        {
            return HP < maxHP;
        }
        private float SetDamage()
        {
            if (HP > 50) damge = 5;
            else damge = 2.5f;
            return damge;
        }
        public void Die()
        {
            Destroy(transform.parent.gameObject);

        }
    }
}