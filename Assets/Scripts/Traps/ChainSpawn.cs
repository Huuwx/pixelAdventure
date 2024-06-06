using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainSpawn : MonoBehaviour
{
    public GameObject chainLinkPrefab;
    public int numberofLinks = 10;
    public float distanceBetweenLinks = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnChainTrap();
    }

    public void SpawnChainTrap()
    {
        Vector3 spawnPos = transform.position;

        for(int i = 0; i < numberofLinks; i++)
        {
            GameObject link = Instantiate(chainLinkPrefab, spawnPos, Quaternion.identity);
            link.transform.parent = transform;

            // Cập nhật vị trí spawn cho mắt xích tiếp theo
            spawnPos.y -= distanceBetweenLinks;
        }
    }
}
