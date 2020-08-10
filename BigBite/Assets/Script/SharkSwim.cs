using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SharkSwim : MonoBehaviour
{
    Sea sea;
    SharkCreate sharkCreate;
    MenuControl menuControl;

    Animation anim;

    float health; // oyuncunun canini saklar
    float mana; // oyuncunun mana seviyesini tutar
    public float speed; // oyuncunun hizini saklar
    float speedModifier; // ekranda kaydırma islemi hassasiyetini saglar
    static float seaPositionZ; // sea prefabının ilerleyecek bi sekilde olusmasi icin Z duzleminin pozisyonunu saklar
    float seconds; // oyunun icindeki gecen zamani saklar 
    float powerTime; // ozel guc icin zaman tutar
    float endedGameTimer; // oyunun ne zaman bietecegini saklar
    int fishCounter;

    public GameObject[] seaPrefab; // sea prefablarını tutan array unity uzerinden duzenlenir
    public GameObject finishPrefab; // bitis prefabı unity uzerinden atamasi yapilir

    bool gameFinish; // oyunun bitisini saglar
    bool powerUp; // ozel guc durumunu saklar

    void Start()
    {
        anim = GetComponent<Animation>();
        menuControl = FindObjectOfType<MenuControl>();
        sharkCreate = FindObjectOfType<SharkCreate>();
        health = sharkCreate.getSelectHealth();
        speed = sharkCreate.getSelectSpeed();
        mana = 0;
        speedModifier = 0.01f; // 0.005f degeri ideal deger
        seaPositionZ = 5f;
        seconds = 0;
        powerTime = 0;
        endedGameTimer = 3f;
        fishCounter = 0;
        powerUp = false;
        gameFinish = false;
        StartedSea();
    }

    void FixedUpdate()
    {
        MoveSpeed();
        Move();
    }

    void Update()
    {
        SpecialPower();
        GameFinish();
        SecondCounter();
    }

    // sag sol yapmasini saglar
    void Move()
    {
        if (Input.touchCount > 0 && sharkCreate.getPlayBool())
        {
            Touch touch;

            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speedModifier, transform.position.y, transform.position.z);
            }
        }
    }

    // surekli olarak z ekseninde ilerlemesini saglar
    void MoveSpeed()
    {
        sharkCreate.getSharkPlayer().transform.position =  new Vector3(sharkCreate.getSharkPlayer().transform.position.x, sharkCreate.getSharkPlayer().transform.position.y, sharkCreate.getSharkPlayer().transform.position.z + speed * Time.deltaTime);
    }

    // objelere degdiginde yapilmasi gereken islemleri yapar
    void OnTriggerEnter(Collider other)
    {
        sea = FindObjectOfType<Sea>();

        BackColliderControl(other);

        DamageColliderControl(other);

        StartCoroutine(AdvantageColliderControl(other));

        StartCoroutine(CoinWin(other));

        FinishTable(other);

        Debug.Log("health: " + health + " mana: " + mana);
    }

    // kenarlara degdigi surece hızını dusurur
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name.Contains("Edge"))
        {
            speed = 1;
        }
    }

    // kenarlara degmeyi bitirdigini kontrol eder
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name.Contains("Edge"))
        {
            speed = sharkCreate.getSelectSpeed();
        }
    }

    // baslangic icin bir sea prefabı baslatir
    void StartedSea()
    {
        GameObject seaObject = seaPrefab[Random.Range(0, seaPrefab.Length)];
        Instantiate(seaObject, new Vector3(0, 0, seaPositionZ), Quaternion.Euler(new Vector3(0, 90, 0)));
        seaPositionZ += 15;
    }

    // back colliderine degdiginde yeni bir sea olusturur
    void BackColliderControl(Collider collider)
    {
        if (collider.gameObject.name.Contains("Back"))
        {
            GameObject seaObject = seaPrefab[Random.Range(0, seaPrefab.Length)];
            Instantiate(seaObject, new Vector3(0, 0, seaPositionZ), Quaternion.Euler(new Vector3(0, 90, 0)));
            seaPositionZ += 15;
        }
    }

    // damage objelerine degdiginde yapilmasi gerekenleri yapar
    void DamageColliderControl(Collider collider)
    {
        // ozel guc baslamadigi surece calismasini saglar
        if (!powerUp)
        {
            for (int i = 0; i < sea.seaDamageObject.Count; i++)
            {
                if (collider.transform.name.Contains(sea.seaDamageObject[i].getSeaGameObject().name))
                {
                    health -= sea.seaDamageObject[i].getPoweOfObject();
                    break;
                }
            }
        }
    }

    // advantage objelerine degdiginde yapilmasi gerekenleri yapar
    IEnumerator AdvantageColliderControl(Collider collider)
    {
        if (mana < 100)
        {
            for (int i = 0; i < sea.seaAdvantageObject.Count; i++)
            {
                if (collider.transform.name.Contains(sea.seaAdvantageObject[i].getSeaGameObject().name))
                {
                    if (health + sea.seaAdvantageObject[i].getPowerOfObjectHP() > sharkCreate.getSelectHealth())
                    {
                        health = sharkCreate.getSelectHealth();
                    }

                    if (health + sea.seaAdvantageObject[i].getPowerOfObjectHP() <= sharkCreate.getSelectHealth())
                    {
                        health += sea.seaAdvantageObject[i].getPowerOfObjectHP();
                    }

                    if (mana + sea.seaAdvantageObject[i].getPowerOfObjectMana() >= 100f)
                    {
                        mana = 100f;
                        powerUp = true;
                    }

                    if (mana + sea.seaAdvantageObject[i].getPowerOfObjectMana() < 100f)
                    {
                        mana += sea.seaAdvantageObject[i].getPowerOfObjectMana();
                    }
                    //AnimStop("Swim");
                    //AnimPlay("Eat");
                    fishCounter++;
                    yield return new WaitForSeconds(0);
                    //AnimPlay("Swim");                    
                    break;
                }
            }
        }
    }

    // coine degdiginde yapilmasi gerekenleri yapar
    IEnumerator CoinWin(Collider collider)
    {
        if (collider.transform.gameObject.name.Contains(sea.coin.gameObject.name))
        {
            AnimStop("Swim");
            AnimPlay("Eat"); 
            sharkCreate.CoinCounterPlus();
            Debug.Log("Coin: " + sharkCreate.getCoinCounter());
            yield return new WaitForSeconds(1f);
            AnimPlay("Swim");
        }
    }

    // finish e geldiginde yapilmasi gerekenleri yapar
    void FinishTable(Collider collider)
    {
        if (collider.transform.gameObject.name.Contains(finishPrefab.gameObject.name))
        {
            sharkCreate.CoinGameSave();
            AnimStop("Swim");
            AnimPlay("Finish");
            sharkCreate.setPlayBool(false);
            menuControl.GamePlayMenu(false);
            menuControl.FinishMenu(true);
            health = sharkCreate.getSelectHealth();
            speed = sharkCreate.getSelectSpeed();
            mana = 0;
            powerUp = false;
        }
    }

    // ozel gucu gercekler
    void SpecialPower()
    {
        if (powerUp)
        {
            powerTime += Time.deltaTime;

            if (powerTime <= sharkCreate.getSelectManaTime())
            {
                speed = sharkCreate.getSelectManaPower();
            }
            else
            {
                powerUp = false;
                mana = 0;
                powerTime = 0f;
                speed = sharkCreate.getSelectSpeed();
            }
        }
    }

    // oyunun suresini tutar
    void SecondCounter()
    {
        if (sharkCreate.getPlayBool())
        {
            seconds += Time.deltaTime;
        }
    }

    // oyunu bitirir
    void GameFinish()
    {
        if (seconds > endedGameTimer && !gameFinish)
        {
            Instantiate(finishPrefab, new Vector3(0, 0, seaPositionZ), Quaternion.Euler(new Vector3(0, 90, 0)));
            seaPositionZ += 15;
            gameFinish = true;
        }
    }

    // yenen balık sayisini return eder
    public int getFishCounter()
    {
        return fishCounter;
    }

    public void ResetFishCounter()
    {
        fishCounter = 0;
    }

    // son oluşturulan sea objesinin Z position unu return eder
    public float getSeaPositionZ()
    {
        return seaPositionZ - 7.5f;
    }

    // oyunun suresinin dolup dolmadıgını return eder
    public bool getEndedGameTimer()
    {
        if (seconds > endedGameTimer)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void ResetSecond()
    {
        seconds = 0f;
    }

    public void setGameFinish(bool mode)
    {
        gameFinish = mode;
    }

    public void AnimPlay(string clip)
    {
        anim.Play(clip);
    }

    public void AnimStop(string clip)
    {
        anim.Stop(clip);
    }
}
