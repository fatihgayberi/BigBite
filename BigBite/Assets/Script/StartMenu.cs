using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Button playBtn;
    public Button marketBtn;

    // Start is called before the first frame update
    void Start()
    {
        playBtn.onClick.AddListener(TaskOnTouchPlay);
        marketBtn.onClick.AddListener(TaskOnTouchBack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnTouchPlay()
    {
        SceneManager.LoadScene("GameScene");
    }

    void TaskOnTouchBack()
    {
        SceneManager.LoadScene("MarketScene");
    }
}
