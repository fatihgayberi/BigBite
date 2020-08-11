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

    public GameObject[] sharkArray;
    public GameObject noLimitPanel;
    public GameObject confirmPanel;

    GameObject sharkOnTheScreen;

    public Text totalCoin;
    public Text priceOutput;

    public DataManager dataManager;

    public Sprite btnInActive;
    public Sprite btnActive;

    public int sharkIndex;

    // Start is called before the first frame update
    void Start()
    {
        dataManager.Load();
        sharkIndex = dataManager.data.selectedSharkIndex;
        PriceOutput(sharkIndex);

        sharkOnTheScreen = Instantiate(sharkArray[sharkIndex], new Vector3(-2f, 3.5f, -0.1f), Quaternion.Euler(-5, 20, 20));

        backBtn.onClick.AddListener(TaskOnTouchBack);
        leftBtn.onClick.AddListener(TaskOnTouchLeft);
        rightBtn.onClick.AddListener(TaskOnTouchRight);
        priceBtn.onClick.AddListener(TaskOnTouchPrice);

        TotalCoin();

        BtnControl();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        }
        if (dataManager.data.buyingShark[sharkIndex] && dataManager.data.selectedSharkIndex != sharkIndex) 
        {
            priceOutput.text = "Sec";
        }
        if (!dataManager.data.buyingShark[sharkIndex])
        {
            priceOutput.text = dataManager.data.sharkPrice[sharkIndex] + " ALTIN";
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
                noLimitPanel.gameObject.SetActive(true);
            }
        }
    }
}
