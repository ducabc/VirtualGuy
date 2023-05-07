using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public GameObject win;
    private PlayerStatic playerStatic;
    private int indexScene=1;
    // Start is called before the first frame update
    void Start()
    {
        playerStatic = FindObjectOfType<PlayerStatic>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnWin()
    {
        Time.timeScale = 0;
        win.SetActive(true);
    }
    public void OffWin()
    {
        Time.timeScale = 1;
        win.SetActive(false);
    }

    public void Resume()
    {
        if (indexScene <= 2)
            SceneManager.LoadScene(indexScene +1);
        else SceneManager.LoadScene(0);
        OffWin();
    }
    public void Quit()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
