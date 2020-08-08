using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    SharkCreate sharkCreate;
    public Button playBtn;
    public Button marketBtn;
    public Button voiceBtn;
    public Sprite offVoice;
    public Sprite onVoice;
    public GameObject startMenu;
    public GameObject gameMenu;

    // Start is called before the first frame update
    void Start()
    {
        sharkCreate = FindObjectOfType<SharkCreate>();
        voiceBtn.onClick.AddListener(TaskOnTouchVoice);
        playBtn.onClick.AddListener(TaskOnTouchPlay);
        marketBtn.onClick.AddListener(TaskOnTouchBack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnTouchPlay()
    {
        sharkCreate.setPlayBool(true);
        gameMenu.gameObject.SetActive(true);
        startMenu.gameObject.SetActive(false);
    }

    void TaskOnTouchBack()
    {
        SceneManager.LoadScene("MarketScene");
    }    
    
    void TaskOnTouchVoice()
    {
        if (voiceBtn.image.sprite == onVoice)
        {
            voiceBtn.image.sprite = offVoice;
        }
        else
        {
            voiceBtn.image.sprite = onVoice;
        }
    }
}
