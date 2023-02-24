using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public GameObject stick;
    public GameObject pausePanel;
    // Start is called before the first frame update
    void Start()
    {
        if (AudioListener.pause == false)
        {
           stick.SetActive(false);
        }
        else
        {
            stick.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Level1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1");
    }
    public void Level2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level2");
    }
    public void Level3()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level3");
    }
    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void exit()
    {
        Application.Quit();
    }
    public void sound()
    {
        if (AudioListener.pause == true)
        {
            AudioListener.pause = false;
            stick.SetActive(false);
        }
        else
        {
            AudioListener.pause = true;
            stick.SetActive(true);
        }

    }
}
