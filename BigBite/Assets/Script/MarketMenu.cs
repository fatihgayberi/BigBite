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

    public GameObject[] sharkArray;
    GameObject sharkOnTheScreen;

    public Text totalCoin;

    public DataManager dataManager;

    public Sprite btnInActive;
    public Sprite btnActive;

    int sharkIndex;

    // Start is called before the first frame update
    void Start()
    {
        sharkOnTheScreen = Instantiate(sharkArray[sharkIndex], new Vector3(-2f, 3.5f, -0.1f), Quaternion.Euler(-5, 20, 20));

        backBtn.onClick.AddListener(TaskOnTouchBack);
        leftBtn.onClick.AddListener(TaskOnTouchLeft);
        rightBtn.onClick.AddListener(TaskOnTouchRight);

        dataManager.Load();
        TotalCoin(dataManager.data.totalCoin);

        sharkIndex = 0;
        BtnControl();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnTouchBack()
    {
        SceneManager.LoadScene("GameScene");
    }

    void TotalCoin(int totalCoin)
    {
        this.totalCoin.text = totalCoin + " Altın";
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
}
