using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MarketMenu : MonoBehaviour
{
    public Button leftBtn;
    public Button rightBtn;
    public Button backBtn;
    public Button priceBtn;
    public Button speedUpBtn;
    public Button powerUpBtn;

    public GameObject[] sharkArray;
    public GameObject notificationPanel;
    public GameObject confirmPanel;
    public GameObject specialPower;
    public GameObject[] speedBoneSprite;
    public GameObject[] speedSpineSprite;
    public GameObject[] powerBoneSprite;
    public GameObject[] powerSpineSprite;

    GameObject sharkOnTheScreen;

    public Text totalCoin;
    public Text priceOutput;
    public Text speedLevelTxt;
    public Text powerLevelTxt;
    public Text speedUpTxt;
    public Text powerUpTxt;

    public DataManager dataManager;

    public Sprite btnInActive;
    public Sprite btnActive;
    public Sprite boneActive;
    public Sprite spineActive;
    public Sprite boneInActive;
    public Sprite spineInActive;

    public int sharkIndex;
    string notificationOutput;

    // Start is called before the first frame update
    void Start()
    {
        dataManager.Load();
        sharkIndex = dataManager.data.selectedSharkIndex;
        PriceOutput(sharkIndex);
        SpeedSkeletActive(SpeedActiveIndexFind());
        PowerSkeletActive(PowerActiveIndexFind());

        sharkOnTheScreen = Instantiate(sharkArray[sharkIndex], new Vector3(-2f, 3.5f, -0.1f), Quaternion.Euler(-5, 20, 20));

        SpeedUpdatePrice();
        PowerUpdatePrice();

        backBtn.onClick.AddListener(TaskOnTouchBack);
        leftBtn.onClick.AddListener(TaskOnTouchLeft);
        rightBtn.onClick.AddListener(TaskOnTouchRight);
        priceBtn.onClick.AddListener(TaskOnTouchPrice);
        speedUpBtn.onClick.AddListener(TaskOnTouchSpeed);
        powerUpBtn.onClick.AddListener(TaskOnTouchPower);

        TotalCoin();

        BtnControl();
    }

    void TotalCoin()
    {
        dataManager.Load();
        this.totalCoin.text = dataManager.data.totalCoin + " Altın";
    }
    void TaskOnTouchBack()
    {
        SceneManager.LoadScene("GameScene");
    }

    void TaskOnTouchLeft()
    {
        if (sharkIndex > 0)
        {
            sharkIndex--;
            SelectedShark();
            rightBtn.gameObject.GetComponent<Image>().sprite = btnActive;
            Debug.Log("sharkIndex left: " + sharkIndex);
        }
        if (sharkIndex == 0)
        {
            leftBtn.gameObject.GetComponent<Image>().sprite = btnInActive;
            Debug.Log("sharkIndex left none: " + sharkIndex);
        }
        SpeedSkeletInActive();
        PowerSkeletInActive();
        SpeedSkeletActive(SpeedActiveIndexFind());
        PowerSkeletActive(PowerActiveIndexFind());
    }

    void TaskOnTouchRight()
    {
        if (sharkIndex < sharkArray.Length - 1)
        {
            sharkIndex++;
            SelectedShark();
            Debug.Log("sharkIndex right: " + sharkIndex);
            leftBtn.gameObject.GetComponent<Image>().sprite = btnActive;
        }
        if (sharkIndex == sharkArray.Length - 1)
        {
            rightBtn.gameObject.GetComponent<Image>().sprite = btnInActive;
            Debug.Log("sharkIndex right none: " + sharkIndex);
        }
        SpeedSkeletInActive();
        PowerSkeletInActive();
        SpeedSkeletActive(SpeedActiveIndexFind());
        PowerSkeletActive(PowerActiveIndexFind());
    }

    void SelectedShark()
    {
        Destroy(sharkOnTheScreen);
        PriceOutput(sharkIndex);
        switch (sharkIndex)
        {
            case 0:
                sharkOnTheScreen = Instantiate(sharkArray[sharkIndex], new Vector3(-2f, 3.5f, -0.1f), Quaternion.Euler(-5, 20, 20));
                break;
            case 1:
                sharkOnTheScreen = Instantiate(sharkArray[sharkIndex], new Vector3(-2f, 3.5f, 0.8f), Quaternion.Euler(-5, 20, 20));
                break;
            case 2:
                sharkOnTheScreen = Instantiate(sharkArray[sharkIndex], new Vector3(-2f, 3.5f, 0.3f), Quaternion.Euler(-5, 20, 20));
                break;
            case 3:
                sharkOnTheScreen = Instantiate(sharkArray[sharkIndex], new Vector3(-2f, 3.5f, -0.2f), Quaternion.Euler(-5, 20, 20));
                break;
            case 4:
                sharkOnTheScreen = Instantiate(sharkArray[sharkIndex], new Vector3(-3f, 3.2f, -0.3f), Quaternion.Euler(-5, 20, 20));
                break;
            default:
                break;
        }
    }

    void BtnControl()
    {
        if (sharkIndex == 0)
        {
            leftBtn.gameObject.GetComponent<Image>().sprite = btnInActive;
        }
        else if (sharkIndex < sharkArray.Length - 1)
        {
            rightBtn.gameObject.GetComponent<Image>().sprite = btnInActive;
        }
    }

    void PriceOutput(int sharkIndex)
    {
        dataManager.Load();
        if (dataManager.data.buyingShark[sharkIndex] && dataManager.data.selectedSharkIndex == sharkIndex)
        {
            priceOutput.text = "Secili";
            specialPower.gameObject.SetActive(true);
        }
        if (dataManager.data.buyingShark[sharkIndex] && dataManager.data.selectedSharkIndex != sharkIndex) 
        {
            priceOutput.text = "Sec";
            specialPower.gameObject.SetActive(true);
        }
        if (!dataManager.data.buyingShark[sharkIndex])
        {
            priceOutput.text = dataManager.data.sharkPrice[sharkIndex] + " ALTIN";
            specialPower.gameObject.SetActive(false);
        }
    }

    void TaskOnTouchPrice()
    {
        if (dataManager.data.buyingShark[sharkIndex])
        {
            dataManager.Load();
            priceOutput.text = "Secili";
            dataManager.data.selectedSharkIndex = sharkIndex;
            dataManager.Save();
            specialPower.gameObject.SetActive(true);
        }
        else
        {
            dataManager.Load();
            if (dataManager.data.totalCoin >= dataManager.data.sharkPrice[sharkIndex])
            {
                confirmPanel.gameObject.SetActive(true);
            }
            else
            {
                notificationOutput = "Yeterli altın yok.";
                notificationPanel.gameObject.SetActive(true);
            }
        }
    }

    void TaskOnTouchSpeed()
    {
        if (dataManager.data.totalCoin < dataManager.data.sharkSpeedPrice[sharkIndex] && dataManager.data.sharkSpeedPrice[sharkIndex] != 100)
        {
            notificationOutput = "Yeterli altın yok.";
            notificationPanel.gameObject.SetActive(true);
        }
        else if (dataManager.data.sharkSpeedPrice[sharkIndex] == 100)
        {
            notificationOutput = "Bu özellik daha fazla yükseltilemez.";
            notificationPanel.gameObject.SetActive(true);
        }
        if (dataManager.data.totalCoin >= dataManager.data.sharkSpeedPrice[sharkIndex] && dataManager.data.sharkSpeedPrice[sharkIndex] != 100)
        {
            dataManager.data.sharkSpeed[sharkIndex] += 1;
            dataManager.data.totalCoin -= dataManager.data.sharkSpeedPrice[sharkIndex];
            totalCoin.text = dataManager.data.totalCoin + " ALTIN";
            dataManager.data.sharkSpeedPrice[sharkIndex] += 10;
            SpeedSkeletActive(SpeedActiveIndexFind());

            SpeedUpdatePrice();

            dataManager.Save();
        }
    }

    void SpeedUpdatePrice()
    {
        if (dataManager.data.sharkSpeedPrice[sharkIndex] != 100)
        {
            speedUpTxt.text = dataManager.data.sharkSpeedPrice[sharkIndex] + " ALTIN";
        }
        else
        {
            speedUpTxt.text = "";
        }
    }

    void TaskOnTouchPower()
    {
        if (dataManager.data.totalCoin < dataManager.data.sharkPowerPrice[sharkIndex] && dataManager.data.sharkPowerPrice[sharkIndex] != 100)
        {
            notificationOutput = "Yeterli altın yok.";
            notificationPanel.gameObject.SetActive(true);
        }
        else if(dataManager.data.sharkPowerPrice[sharkIndex] == 100)
        {
            notificationOutput = "Bu özellik daha fazla yükseltilemez.";
            notificationPanel.gameObject.SetActive(true);
        }
        if (dataManager.data.totalCoin >= dataManager.data.sharkPowerPrice[sharkIndex] && dataManager.data.sharkPowerPrice[sharkIndex] != 100)
        {
            dataManager.data.sharkPower[sharkIndex] += 1;
            dataManager.data.totalCoin -= dataManager.data.sharkPowerPrice[sharkIndex];
            totalCoin.text = dataManager.data.totalCoin + " ALTIN";
            dataManager.data.sharkPowerPrice[sharkIndex] += 10;
            PowerSkeletActive(PowerActiveIndexFind());

            PowerUpdatePrice();

            dataManager.Save();
        }
    }

    void PowerUpdatePrice()
    {
        if (dataManager.data.sharkPowerPrice[sharkIndex] != 100)
        {
            powerUpTxt.text = dataManager.data.sharkPowerPrice[sharkIndex] + " ALTIN";
        }
        else
        {
            powerUpTxt.text = "";
        }
    }

    void SpeedSkeletActive(int activeIndex)
    {
        for (int i = 0; i < activeIndex; i++)
        {
            if (i < 4)
            {
                speedBoneSprite[i].gameObject.GetComponent<Image>().sprite = boneActive;
                speedSpineSprite[i].gameObject.GetComponent<Image>().sprite = spineActive;
                speedLevelTxt.text = i + 1 + "/5";
            }
            else if (i == 4)
            {
                speedBoneSprite[i].gameObject.GetComponent<Image>().sprite = boneActive;
                speedLevelTxt.text = i + 1 + "/5";
            }
        }
    }

    void PowerSkeletActive(int activeIndex)
    {
        for (int i = 0; i < activeIndex; i++)
        {
            if (i < 4)
            {
                powerBoneSprite[i].gameObject.GetComponent<Image>().sprite = boneActive;
                powerSpineSprite[i].gameObject.GetComponent<Image>().sprite = spineActive;
                powerLevelTxt.text = i + 1 + "/5";
            }
            else if (i == 4)
            {
                powerBoneSprite[i].gameObject.GetComponent<Image>().sprite = boneActive;
                powerLevelTxt.text = i + 1 + "/5";
            }
        }
    }

    int SpeedActiveIndexFind()
    {
        int activeIndex = ((dataManager.data.sharkSpeedPrice[sharkIndex] - 50) / 10);
        return activeIndex;
    }

    int PowerActiveIndexFind()
    {
        int activeIndex = ((dataManager.data.sharkPowerPrice[sharkIndex] - 50) / 10);
        return activeIndex;
    }

    void SpeedSkeletInActive()
    {
        for (int i = 0; i < speedBoneSprite.Length; i++)
        {
            speedBoneSprite[i].gameObject.GetComponent<Image>().sprite = boneInActive;
        }

        for (int i = 0; i < speedSpineSprite.Length; i++)
        {
            speedSpineSprite[i].gameObject.GetComponent<Image>().sprite = spineInActive;
        }

        speedLevelTxt.text = "0/5";

        if (dataManager.data.sharkSpeedPrice[sharkIndex] == 100)
        {
            speedUpTxt.text = "";
        }
        else
        {
            speedUpTxt.text = dataManager.data.sharkSpeedPrice[sharkIndex] + " ALTIN";
        }
        
    }

    void PowerSkeletInActive()
    {
        for (int i = 0; i < powerBoneSprite.Length; i++)
        {
            powerBoneSprite[i].gameObject.GetComponent<Image>().sprite = boneInActive;
        }

        for (int i = 0; i < powerSpineSprite.Length; i++)
        {
            powerSpineSprite[i].gameObject.GetComponent<Image>().sprite = spineInActive;
        }

        powerLevelTxt.text = "0/5";

        if (dataManager.data.sharkPowerPrice[sharkIndex] == 100)
        {
            powerUpTxt.text = "";
        }
        else
        {
            powerUpTxt.text = dataManager.data.sharkPowerPrice[sharkIndex] + " ALTIN";
        }

    }

    public string getNotificationOutput()
    {
        return notificationOutput;
    }
}
