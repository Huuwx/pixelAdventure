using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsData : MonoBehaviour
{
    private static PlayerPrefsData instance;

    public static PlayerPrefsData Instance { get { return instance; } }

    private int HealthC1 = 10;
    private int damageC1 = 1;

    public int getHealthC1()
    {
        return HealthC1;
    }

    public int getDamageC1()
    {
        return damageC1;
    }


    private int HealthC2 = 15;
    private int damageC2 = 1;

    public int getHealthC2()
    {
        return HealthC2;
    }

    public int getDamageC2()
    {
        return damageC2;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveIndexCharacter(int index)
    {
        PlayerPrefs.SetInt("IndexCharacter", index);
    }

    public int LoadIndexCharacter()
    {
        return PlayerPrefs.GetInt("IndexCharacter");
    }

    public void SaveLastPoint(int Point)
    {
        PlayerPrefs.SetInt("LPoint", Point);
    }

    public int LoadLastPoint()
    {
        return PlayerPrefs.GetInt("LPoint");
    }
}
