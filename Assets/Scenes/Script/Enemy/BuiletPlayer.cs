using System.Collections;
using UnityEngine;

namespace Assets.Scenes.Script.Enemy
{
    public class BuiletPlayer : MonoBehaviour
    {

        private float speed = 2;
        private float time = 3f;
        public PlayerCtrl player;
        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.FindObjectOfType<PlayerCtrl>();
            if (player.GetScale() == -1) speed = -2;
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