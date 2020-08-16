using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    SharkCreate sharkCreate;
    MenuControl menuControl;
    SharkSwim sharkSwim;

    public Button playBtn;
    public Button marketBtn;
    public Button voiceBtn;

    public Sprite onVoice;
    public Sprite offVoice;

    // Start is called before the first frame update
    void Start()
    {
        menuControl = FindObjectOfType<MenuControl>();
        sharkCreate = FindObjectOfType<SharkCreate>();
        sharkSwim = FindObjectOfType<SharkSwim>();
        voiceBtn.onClick.AddListener(TaskOnTouchVoice);
        playBtn.onClick.AddListener(TaskOnTouchPlay);
        marketBtn.onClick.AddListener(TaskOnTouchMarket);
        VoiceStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // play butonunu dinler
    void TaskOnTouchPlay()
    {
        sharkSwim.ResetSecond();
        sharkCreate.setPlayBool(true);
        menuControl.GamePlayMenu(true);
        menuControl.StartMenu(false);
    }

    // market butonunu dinler
    void TaskOnTouchMarket()
    {
        SceneManager.LoadScene("MarketScene");
    }    
    
    void TaskOnTouchVoice()
    {
        VoiceIconChange();
    }

    void VoiceIconChange()
    {
        if (PlayerPrefs.GetInt("voice") == 0)
        {
            voiceBtn.image.sprite = onVoice;
            PlayerPrefs.SetInt("voice", 1);
        }
        else
        {
            voiceBtn.image.sprite = offVoice;
            PlayerPrefs.SetInt("voice", 0);
        }
    }

    void VoiceStart()
    {
        if (PlayerPrefs.GetInt("voice") == 0)
        {
            voiceBtn.image.sprite = offVoice;
        }
        else
        {
            voiceBtn.image.sprite = onVoice;
        }
    }
}
