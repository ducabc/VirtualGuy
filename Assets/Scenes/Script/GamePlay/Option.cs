using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Option : MonoBehaviour
{
    [SerializeField] private GameObject option;
    public static Option Instance;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        //pause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OptionBtn()
    {
        option.SetActive(true);
        Time.timeScale = 0;
    }

    public void OptionQuit()
    {
        option.SetActive(false);
        Time.timeScale = 1;
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
