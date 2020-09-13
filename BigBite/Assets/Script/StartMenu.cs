using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public DataManager dataManager;
    SharkCreate sharkCreate;
    MenuControl menuControl;

    public GameObject settingsPanel;

    public Button playBtn;
    public Button marketBtn;
    public Button voiceBtn;
    public Button settingsBtn;

    public Text highScoreTxt;

    public Sprite onVoice;
    public Sprite offVoice;

    // Start is called before the first frame update
    void Start()
    {
        menuControl = FindObjectOfType<MenuControl>();
        sharkCreate = FindObjectOfType<SharkCreate>();
        HighScore();
        GamePlay();
        PlayerPrefs.SetInt("Start", 0);
        settingsBtn.onClick.AddListener(TaskOnTouchSettings);
        playBtn.onClick.AddListener(TaskOnTouchPlay);
        marketBtn.onClick.AddListener(TaskOnTouchMarket);
    }

    // play butonunu dinler
    void TaskOnTouchPlay()
    {
        PlayerPrefs.SetInt("Start", 1);
        sharkCreate.setPlayBool(true);
        menuControl.GamePlayMenu(true);
        menuControl.StartMenu(false);
    }
    void GamePlay()
    {
        if (PlayerPrefs.GetInt("Start") == 1)
        {
            sharkCreate.setPlayBool(true);
            menuControl.GamePlayMenu(true);
            menuControl.StartMenu(false);
        }
    }

    // market butonunu dinler
    void TaskOnTouchMarket()
    {
        SceneManager.LoadScene("MarketScene");
    }

    void TaskOnTouchSettings()
    {
        settingsPanel.gameObject.SetActive(true);
    }

    void HighScore()
    {
        dataManager.Load();
        highScoreTxt.text = "High Score: " + dataManager.data.HighScore;
    }
}
