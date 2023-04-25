using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPanel : MonoBehaviour
{
   public static MenuPanel Instance { get; private set; }
    [SerializeField] private AudioClip  _winn;
    [SerializeField] private AudioSource _audio;
    [SerializeField] 
   
    public GameObject[] panel;
    
    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            //sahneler arasi gecis yapmamiza yariyor.
            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        
    }
    public void GameOver(int index)
    {
        panel[index].SetActive(true);
        

    }
    public void Winn(int index)
    {
        panel[index].SetActive(true);
        _audio.PlayOneShot(_winn);
    }
    
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("Level1");
    }
    public void RestartButton2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void Level2()
    {
        SceneManager.LoadScene(2);
    }
}
