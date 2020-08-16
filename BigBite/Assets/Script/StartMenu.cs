using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    SharkCreate sharkCreate;
    MenuControl menuControl;
    SharkSwim sharkSwim;

    public GameObject settingsPanel;

    public Button playBtn;
    public Button marketBtn;
    public Button voiceBtn;
    public Button settingsBtn;

    public Sprite onVoice;
    public Sprite offVoice;

    // Start is called before the first frame update
    void Start()
    {
        menuControl = FindObjectOfType<MenuControl>();
        sharkCreate = FindObjectOfType<SharkCreate>();
        sharkSwim = FindObjectOfType<SharkSwim>();
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

    void TaskOnTouchSettings()
    {
        settingsPanel.gameObject.SetActive(true);
    }

}
