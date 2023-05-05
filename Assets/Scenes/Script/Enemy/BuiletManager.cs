using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scenes.Script.Enemy
{
    public class BuiletManager : MonoBehaviour
    {
        public List<Transform> builets;
        public static BuiletManager instance;
        // Use this for initialization
        void Start()
        {
            instance = this;
            LoadBuilet();
            HideBuilet(false);
        }

        private void LoadBuilet()
        {
            foreach(Transform builet in transform)
            {
                this.builets.Add(builet);
            }
        }

        public Transform SpamBuilet(string builetName, Vector3 builetPosi,float scalex)
        {
            Transform builet = GetBuiletByName(builetName);
            Transform newBuilet =Instantiate(builet);
            newBuilet.gameObject.SetActive(true);
            newBuilet.position = builetPosi;
            newBuilet.localScale = new Vector3(newBuilet.localScale.x * (scalex),newBuilet.localScale.y * (scalex),1);
            return newBuilet;
        }

        protected Transform GetBuiletByName(string builetName) 
        {
            foreach(Transform builet in builets)
            {
                if (builet.name == builetName) return builet;
            }
            return null;
        }

        protected void HideBuilet(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}