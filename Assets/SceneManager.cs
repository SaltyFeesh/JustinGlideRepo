using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public SceneManage instance;

    private void Awake()
    {
        // ����ģʽ��ȷ��ֻ����һ��ʵ��
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // ���ڳ����л�ʱ����
        }
        else
        {
            Destroy(gameObject); // ��ֹ�ظ�����
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
