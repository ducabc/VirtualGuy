using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public GameObject[] skin;
    private int selectedCharacter;
    private void Awake()
    {
        PlayerPrefs.SetInt("LifeCount", 3);

        selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
        foreach (GameObject player in skin)
            player.SetActive(false);

        skin[selectedCharacter].SetActive(true);
    }
    public void NextSkin()
    {
        skin[selectedCharacter].SetActive(false);
        selectedCharacter++;
        if (selectedCharacter == skin.Length)
            selectedCharacter = 0;

        skin[selectedCharacter].SetActive(true);
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
    }
    public void PrewSkin()
    {
        skin[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter == -1)
            selectedCharacter = skin.Length - 1;

        skin[selectedCharacter].SetActive(true);
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
    }
    public void BackStart()
    {
        SceneManager.LoadScene(0);
    }
}
