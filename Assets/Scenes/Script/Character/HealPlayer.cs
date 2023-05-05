using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scenes.Script.Character
{
    public class HealPlayer : MonoBehaviour
    {
        public Slider healBar;
        public GameObject player;
        public PlayerStatic hPBar;

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            hPBar = player.GetComponent<PlayerStatic>();
        }

        private void FixedUpdate()
        {
            UpdateHPBar();
        }
        protected void UpdateHPBar()
        {
            this.healBar.value = hPBar.CurrentHP();
        }
    }
}