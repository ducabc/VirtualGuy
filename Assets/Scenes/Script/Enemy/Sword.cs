using System.Collections;
using UnityEngine;

namespace Assets.Scenes.Script.Enemy
{
    public class Sword : MonoBehaviour
    {
        public GameObject player;
        private Vector3 target;
        private Attack sword;
        // Use this for initialization
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            target = player.transform.position;
            sword = GameObject.FindObjectOfType<Attack>();
            transform.parent.eulerAngles = new Vector3(0, 0, GetAngle(Dir())-90);
        }

        // Update is called once per frame
        void Update()
        {
            transform.parent.position += Dir() * 4 * Time.deltaTime;
        }

        private Vector3 Dir()
        {
            Vector3 dir = (target - sword.swordPosition.position).normalized;
            return dir;
        }

        private float GetAngle(Vector3 dir)
        {
            float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            if (n < 0) n += 360;
            return n;
        }
    }
}