using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public SceneManage instance;

    private void Awake()
    {
        // 单例模式：确保只保留一个实例
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 不在场景切换时销毁
        }
        else
        {
            Destroy(gameObject); // 防止重复创建
        }
    }

    // Start is called before the first frame update
    public void EntryLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void EntryLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    private void OnEnable()
    {
        Barrier.onPlayerDied += LoadLevelOne;
    }

    private void OnDisable()
    {
        Barrier.onPlayerDied -= LoadLevelOne;
    }

    private void LoadDeathScene()
    {
        SceneManager.LoadScene("Death");
    }
    private void LoadLevelOne()
    {
        SceneManager.LoadScene("Level1");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
