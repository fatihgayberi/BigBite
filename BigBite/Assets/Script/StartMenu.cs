using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    SharkCreate sharkCreate;
    MenuControl menuControl;
    //SharkSwim sharkSwim;

    public GameObject settingsPanel;

    public Button playBtn;
    public Button marketBtn;
    public Button voiceBtn;
    public Button settingsBtn;

    public Sprite onVoice;
    public Sprite offVoice;

    bool startedControl;

    // Start is called before the first frame update
    void Start()
    {
        menuControl = FindObjectOfType<MenuControl>();
        sharkCreate = FindObjectOfType<SharkCreate>();
        //sharkSwim = FindObjectOfType<SharkSwim>();
        PlayerPrefs.SetInt("Start", 0);
        settingsBtn.onClick.AddListener(TaskOnTouchSettings);
        playBtn.onClick.AddListener(TaskOnTouchPlay);
        marketBtn.onClick.AddListener(TaskOnTouchMarket);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // play butonunu dinler
    void TaskOnTouchPlay()
    {
        //Debug.Log("StartedPositionZ: " + StartedPositionZ());
        //sharkSwim.ResetSecond();
        PlayerPrefs.SetInt("Start", 1);
        sharkCreate.setPlayBool(true);
        menuControl.GamePlayMenu(true);
        menuControl.StartMenu(false);
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
}
