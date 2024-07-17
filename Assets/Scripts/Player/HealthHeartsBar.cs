using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHeartsBar : MonoBehaviour
{
    public GameObject heartPrefab;
    public Health playerHealth;
    List<HealthHeartsManager> hearts = new List<HealthHeartsManager>();

    private void OnEnable()
    {
        Health.OnPlayerDamaged += DrawHearts;
    }

    private void OnDisable()
    {
        Health.OnPlayerDamaged -= DrawHearts;
    }

    private void Start()
    {
        playerHealth.currentHealth = playerHealth.maxHealth;
        DrawHearts();
    }

    public void DrawHearts()
    {
        ClearHeart();

        float maxHealthRemainer = playerHealth.maxHealth % 2;
        int heartsToMake = (int)((playerHealth.maxHealth / 2) + maxHealthRemainer);
        for(int i = 0; i < heartsToMake; i++)
        {
            CreateEmptyHeart();
        }

        for(int i = 0; i < hearts.Count; i++)
        {
            int heartStatusRemainder = (int)Mathf.Clamp(playerHealth.currentHealth - (i * 2), 0, 2);
            hearts[i].SetHeartImage((HeartStatus)heartStatusRemainder);
        }
    }

    public void CreateEmptyHeart()
    {
        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);

        HealthHeartsManager heartComponent = newHeart.GetComponent<HealthHeartsManager>();
        heartComponent.SetHeartImage(HeartStatus.Empty);
        hearts.Add(heartComponent);
    }

    public void ClearHeart()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts = new List<HealthHeartsManager> ();
    }
}
