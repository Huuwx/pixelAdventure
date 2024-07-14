using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementController : MonoBehaviour
{
    public Text PointNB;

    // Start is called before the first frame update
    void Start()
    {
        PointNB.text = PlayerPrefsData.Instance.LoadLastPoint().ToString();
    }
}
