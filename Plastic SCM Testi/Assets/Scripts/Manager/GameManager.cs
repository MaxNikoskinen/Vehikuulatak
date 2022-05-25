using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sisältää asioita pelissä yleisesti käytettäviin asioihin esim. pelaaja ja rahamäärä

[RequireComponent(typeof(DontDestroyOnLoad))]
public class GameManager : Singleton<GameManager>
{
    [SerializeField] private bool is3d;
    
    private float carSpeed = 2;
    private int money = 300;
    private int damage = 40;
    private int currentCar = 0;

    private GameObject playerReference;



    //Poistu pelistä metodi, sulkee pelin
    public void ExitGame()
    {
        #if UNITY_EDITOR
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        #else
        {
            Application.Quit();
        }
        #endif
    }

    private bool isPaused;
    private bool canPause;
    private int randomValue;

    private void Start()
    {
        randomValue = Random.Range(0, 10000);
        carSpeed = PlayerPrefs.GetFloat("speed", carSpeed);
        UIManager.Instance.UpdateSpeedText(carSpeed);
        money = PlayerPrefs.GetInt("money", money);
        UIManager.Instance.UpdateMoneyText(money);
        damage = PlayerPrefs.GetInt("damage", damage);
        UIManager.Instance.UpdateDamageText(damage);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canPause)
        {
            //Jos peli on pysäytetty
            if (isPaused)
            {
                ResumeGame();
            }
            //Jos peliä ei ole pysäytetty
            else
            {
                PauseTheGame();
            }
        }
    }

    //Pysäytä peli
    public void PauseTheGame()
    {
        isPaused = true;
        UIManager.Instance.TogglePauseScreen(true);
        if (is3d)
        {
            ShowCursor();
        }
        Time.timeScale = 0;
        Debug.Log("pysäytetty");
    }

    //Jatka peliä
    public void ResumeGame()
    {
        isPaused = false;
        UIManager.Instance.TogglePauseScreen(false);
        UIManager.Instance.ToggleSettingsScreen(false);
        UIManager.Instance.ToggleBackToMenuScreen(false);
        UIManager.Instance.ToggleGuideScreen(false);
        if(is3d)
        {
            HideCursor();
        }
        Time.timeScale = 1;
        Debug.Log("jatkettu");
    }

    //Onko pelaaja päävalikossa vai ei
    public void ToggleCanPause(bool value)
    {
        canPause = value;
    }

    public void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public int GetRandomValue()
    {
        return randomValue;
    }

    public GameObject player
    {
        get
        {
            return playerReference;
        }
        set
        {
            playerReference = value;
            Debug.Log("Player added to gamemanager", value);
        }
    }

    public bool GetIsPaused()
    {
        return isPaused;
    }

    public bool GetIs3d()
    {
        return is3d;
    }

    public float GetSpeed()
    {
        return carSpeed;
    }

    public int GetDamage()
    {
        return damage;
    }

    public void RaiseSpeed()
    {
        if(carSpeed < 10 && money >= 50)
        {
            carSpeed += 0.5f;
            UIManager.Instance.UpdateSpeedText(carSpeed);
            PlayerPrefs.SetFloat("speed", carSpeed);
            money -= 50;
            PlayerPrefs.SetInt("money", money);
            UIManager.Instance.UpdateMoneyText(money);
        }
    }

    public void LowerSpeed()
    {
        if(carSpeed > 0.5)
        {
            carSpeed -= 0.5f;
            UIManager.Instance.UpdateSpeedText(carSpeed);
            PlayerPrefs.SetFloat("speed", carSpeed);
            money += 50;
            PlayerPrefs.SetInt("money", money);
            UIManager.Instance.UpdateMoneyText(money);
        }
    }

    public void RaiseDamage()
    {
        if (damage < 100 && money >= 50)
        {
            damage += 5;
            UIManager.Instance.UpdateDamageText(damage);
            PlayerPrefs.SetInt("damage", damage);
            money -= 50;
            PlayerPrefs.SetInt("money", money);
            UIManager.Instance.UpdateMoneyText(money);
        }
    }

    public void LowerDamage()
    {
        if (damage > 10)
        {
            damage -= 5;
            UIManager.Instance.UpdateDamageText(damage);
            PlayerPrefs.SetInt("speed", damage);
            money += 50;
            PlayerPrefs.SetInt("money", money);
            UIManager.Instance.UpdateMoneyText(money);
        }
    }

    public int Money
    {
        get
        {
            return money;
        }
        set
        {
            money = value;
        }
    }

    public int GetCurrentCar
    {
        get
        {
            return currentCar;
        }
    }

    public void changecar(int value)
    {
        currentCar = value;
    }
}
