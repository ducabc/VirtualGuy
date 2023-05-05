using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pause;
    // Start is called before the first frame update
    void Start()
    {
        pause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pause.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void Resume()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
    }
    public void Quit()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
