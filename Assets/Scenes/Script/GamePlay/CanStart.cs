using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanStart : MonoBehaviour
{
   
    public void SelectCharacter()
    {
        SceneManager.LoadScene(1);
    }
    public void SelectLevel()
    {
        SceneManager.LoadScene(2);
    }
}
