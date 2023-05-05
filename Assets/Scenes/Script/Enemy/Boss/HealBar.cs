using Assets.Scenes.Script.Enemy.Boss;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealBar : MonoBehaviour
{
    public Slider healBar;
    public Image avatar;
    public GameObject boss;
    public HPBoss hPBar;

    private void Start()
    {
        //healBar.gameObject.SetActive(false);
        //avatar.gameObject.SetActive(false);
        hPBar = boss.GetComponent<HPBoss>();
    }

    private void FixedUpdate()
    {
        UpdateHPBar();
    }
    protected void UpdateHPBar()
    {
        healBar.gameObject.SetActive(hPBar.ActiveBar());
        avatar.gameObject.SetActive(hPBar.ActiveBar());
        this.healBar.value = hPBar.CurrentHP();
    }
}
