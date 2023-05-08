using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject[] playerPrefabs;
    protected int playerIndex;
    protected int items=0;
    public CinemachineVirtualCamera Vcam;
    public static PlayerManager instance;

    public Text itemCount;

    private void Awake()
    {
        playerIndex= PlayerPrefs.GetInt("SelectedCharacter", 0);
        GameObject player = Instantiate(playerPrefabs[playerIndex], new Vector3(-3,0,0), Quaternion.identity);
        Vcam.m_Follow = player.transform;
    }

    private void Start()
    {
        if (instance != null) return;
        instance = this;
    }

    public int AddItem()
    {
        items++;
        itemCount.text = $" x {items}";
        return items;
    }
}
