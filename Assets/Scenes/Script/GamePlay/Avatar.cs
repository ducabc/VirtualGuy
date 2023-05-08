using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Avatar : MonoBehaviour
{
    public Image avatar;
    public Sprite avt1;
    public Sprite avt2;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("SelectedCharacter") == 0)
            avatar.sprite = avt1;
        else avatar.sprite = avt2;
    }

}
