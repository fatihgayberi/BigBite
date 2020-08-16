using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

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
    float barrelTime;
    float endedGameTimer; // oyunun ne zaman bietecegini saklar
    float finishPosiztionZ;
    int fishCounter;

    public GameObject barrelParticle;
    public GameObject mineParticle;
    public GameObject gamaParticle;
    public GameObject dizzyParticle;
    public GameObject coinParticle;
    public GameObject fishParticle;
    public GameObject[] otherParticle;
    public GameObject respawnParticle;
    public GameObject manaParticle;

    public GameObject[] seaPrefab; // sea prefablarını tutan array unity uzerinden duzenlenir
    public GameObject finishPrefab; // bitis prefabı unity uzerinden atamasi yapilir
    GameObject finishSea;
    GameObject gamaCreatedParticle;
    GameObject dizzyCreatedParticle;
    GameObject manaCreatedParticle;

    public List<GameObject> allObject = new List<GameObject>();

    bool gameFinish; // oyunun bitisini saglar
    bool powerUp; // ozel guc durumunu saklar
    bool barrelPower;
    bool gameOver; // gameover ise false dondurur

    public Action OnDamage;
    void Start()
    {
        anim = GetComponent<Animation>();
        menuControl = FindObjectOfType<MenuControl>();
        sharkCreate = FindObjectOfType<SharkCreate>();
        health = sharkCreate.getSelectHealth();
        speed = sharkCreate.getSelectSpeed();
        mana = 0;
        PrefsReset();
        speedModifier = 0.01f; // 0.005f degeri ideal deger
        seaPositionZ = 5f;
        seconds = 0;
        powerTime = 0;
        barrelTime = 0;
        endedGameTimer = 30f;
        finishPosiztionZ = 0;
        fishCounter = 0;
        barrelPower = false;
        powerUp = false;
        gameFinish = false;
        gameOver = true;
        StartedSea();
        RespawnParticle();
    }

    void FixedUpdate()
    {
        MoveSpeed();
        Move();
    }

    void Update()
    {
        SmoothDirection();
        ParticlePositionUpdate();
        SpecialPower();
        BarrelPower();
        GameFinish();
        SecondCounter();
        GameOver();
    }

    // sag sol yapmasini saglar
    void Move()
    {
        if (Input.touchCount > 0 && sharkCreate.getPlayBool() && gameOver)
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

    void SmoothDirection()
    {
        float x = transform.position.x;
        x = Mathf.Clamp(x, -2.30f, 2.30f);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    // objelere degdiginde yapilmasi gereken islemleri yapar
    void OnTriggerEnter(Collider other)
    {
        sea = FindObjectOfType<Sea>();

        BackColliderControl(other);

        DamageColliderControl(other);

        BarrelColliderControl(other);

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
            Vibrator();
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
        SeaCreate();
    }

    // back colliderine degdiginde yeni bir sea olusturur
    void BackColliderControl(Collider collider)
    {
        if (collider.gameObject.name.Contains("Back"))
        {
            SeaCreate();
        }
    }

    // damage objelerine degdiginde yapilmasi gerekenleri yapar
    void DamageColliderControl(Collider collider)
    {
        for (int i = 0; i < sea.seaDamageObject.Count; i++)
        {
            if (collider.transform.name.Contains(sea.seaDamageObject[i].getSeaGameObject().name))
            {
                Vibrator();
                DamageParticle(collider);
                // ozel guc baslamadigi surece ve varile degmedigi surece canin azalmasini saglar
                if (!barrelPower && !powerUp)
                {
                    health -= sea.seaDamageObject[i].getPoweOfObject();
                }

                if (barrelPower)
                {
                    sharkCreate.BarrierCoinPlus();
                }
                //Çarpıştığı zaman event yayınlar
                OnDamage?.Invoke();
                StartCoroutine(Dizzy());
                
                break;
            }
        }
    }
    
    void DamageParticle(Collider collider)
    {
        if (collider.transform.name.Contains("Mine"))
        {
            Instantiate(mineParticle, collider.transform.position, Quaternion.identity);
        }
        else
        {
            for (int i = 0; i < otherParticle.Length; i++)
            {
                Instantiate(otherParticle[i], collider.transform.position, Quaternion.identity);
            }
        }
        Destroy(collider.transform.gameObject);
    }

    IEnumerator Dizzy()
    {
        if (!barrelPower)
        {
            dizzyCreatedParticle = Instantiate(dizzyParticle, GetComponent<Collider>().transform.position, Quaternion.identity);
            speedModifier = 0.001f;
            speed = 1;
            yield return new WaitForSeconds(2f);
            Destroy(dizzyCreatedParticle);
            speedModifier = 0.01f;
            speed = sharkCreate.getSelectSpeed();
        }
    }

    void ParticlePositionUpdate()
    {
        if (dizzyCreatedParticle != null)
        {
            dizzyCreatedParticle.transform.position = transform.position;
        }

        if (gamaCreatedParticle != null)
        {
            gamaCreatedParticle.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1f);
        }

        if (powerUp)
        {
            manaCreatedParticle.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1f);
        }
    }


    // advantage objelerine degdiginde yapilmasi gerekenleri yapar
    IEnumerator AdvantageColliderControl(Collider collider)
    {
        if (mana < 100)
        {
            for (int i = 0; i < sea.seaAdvantageObject.Count; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (collider != null)
                    {
                        if (collider.transform.name.Contains(sea.seaAdvantageObject[i].getSeaGameObject().transform.GetChild(j).gameObject.name))
                        {
                            Instantiate(fishParticle, collider.transform.position, Quaternion.identity);

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
                                manaCreatedParticle = Instantiate(manaParticle, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1f), Quaternion.Euler(0, 180, 0));
                            }

                            if (mana + sea.seaAdvantageObject[i].getPowerOfObjectMana() < 100f)
                            {
                                mana += sea.seaAdvantageObject[i].getPowerOfObjectMana();
                            }
                            Destroy(collider.transform.gameObject);
                            AnimStop("Swim");
                            AnimPlay("Eat");
                            fishCounter++;
                            PlayerPrefs.SetInt("fish", fishCounter);
                            yield return new WaitForSeconds(1f);
                            AnimPlay("Swim");
                            break;
                        }
                    }                    
                }
            }
        }
    }

    void BarrelColliderControl(Collider collider)
    {
        if (collider.transform.gameObject.name.Contains(sea.barrel.gameObject.name))
        {
            barrelPower = true;
            Instantiate(barrelParticle, collider.transform.position, Quaternion.identity);
            gamaCreatedParticle = Instantiate(gamaParticle, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1f), Quaternion.Euler(0, 180, 0));
            Destroy(collider.transform.gameObject);
        }
    }

    void BarrelPower()
    {
        if (barrelPower)
        {
 
            barrelTime += Time.deltaTime;

            if (barrelTime <= sharkCreate.getSelectManaTime())
            {
                speed = sharkCreate.getSelectManaPower();
            }
            else
            {
                barrelPower = false;
                barrelTime = 0f;
                Destroy(gamaCreatedParticle);
                speed = sharkCreate.getSelectSpeed();
            }
        }
    }

    void RespawnParticle()
    {
        Instantiate(respawnParticle, transform.position, Quaternion.identity);

    }

    // coine degdiginde yapilmasi gerekenleri yapar
    IEnumerator CoinWin(Collider collider)
    {
        if (collider.transform.gameObject.name.Contains(sea.coin.gameObject.name))
        {
            Instantiate(coinParticle, collider.transform.position, Quaternion.identity);
            Destroy(collider.transform.gameObject);
            AnimStop("Swim");
            AnimPlay("Eat"); 
            sharkCreate.CoinCounterPlus();
            Debug.Log("Coin: " + sharkCreate.getCoinCounter());
            yield return new WaitForSeconds(1f);
            AnimPlay("Swim");
        }
    }

    void Vibrator()
    {
        if (PlayerPrefs.GetInt("Vibrate") == 1)
        {
            Handheld.Vibrate();
        }
    }

    // finish e geldiginde yapilmasi gerekenleri yapar
    void FinishTable(Collider collider)
    {
        if (collider.transform.gameObject.name.Contains(finishPrefab.gameObject.name))
        {
            AnimStop("Swim");
            sharkCreate.setPlayBool(false);
            menuControl.GamePlayMenu(false);
            health = sharkCreate.getSelectHealth();
            speed = sharkCreate.getSelectSpeed();
            mana = 0;
            powerUp = false;
            SceneManager.LoadScene("FinishScene");
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

    void SeaCreate()
    {
        GameObject seaObject = seaPrefab[Random.Range(0, seaPrefab.Length)];
        Instantiate(seaObject, new Vector3(0, 0, seaPositionZ), Quaternion.Euler(new Vector3(0, 90, 0)));
        seaPositionZ += 15;
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
            finishPosiztionZ = seaPositionZ;
            finishSea = Instantiate(finishPrefab, new Vector3(0, 0, seaPositionZ), Quaternion.Euler(new Vector3(0, 90, 0)));
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
        PlayerPrefs.SetInt("fish", fishCounter);
    }

    public void ResetSpeed()
    {
        speed = sharkCreate.getSelectSpeed();
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

    public void GameOver()
    {
        if (health <= 0 && gameOver)
        {
            gameOver = false;
            gameFinish = true;
            menuControl.GameOverMenu(true);
            menuControl.GamePlayMenu(false);

            if (allObject != null)
            {
                for (int i = 0; i < allObject.Count; i++)
                {
                    Destroy(allObject[i]);
                }
                allObject.Clear();
            }

            Destroy(finishSea);
            GameObject seaObject = seaPrefab[Random.Range(0, seaPrefab.Length)];
            Instantiate(seaObject, new Vector3(0, 0, finishPosiztionZ), Quaternion.Euler(new Vector3(0, 90, 0)));
        }
    }

    public void ResetHealth()
    {
        health = sharkCreate.getSelectHealth();
    }

    public void ResetMana()
    {
        mana = 0;
        powerUp = false;
    }

    public void ResetBarrelPower()
    {
        barrelPower = false;
    }

    void PrefsReset()
    {
        PlayerPrefs.SetInt("Coin", 0);
        PlayerPrefs.SetInt("fish", 0);
        PlayerPrefs.SetInt("CoinBarrel", 0);

    }

    public void ResetGameOver()
    {
        gameOver = true;
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

    public bool getGameOver()
    {
        return gameOver;
    }

    public float getHealth()
    {
        return health;
    }

    public float getMana()
    {
        return mana;
    }
}
