using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    private static CharacterSelection instance;

    public static CharacterSelection Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<CharacterSelection>();
                if(instance == null)
                {
                    GameObject obj = new GameObject("CharacterSelection");
                    instance = obj.AddComponent<CharacterSelection>();
                }
            }
            return instance;
        }
    }

    public List<GameObject> Character;

    public void SetActiveCharacter(bool active1, bool active2, bool active3)
    {
        Character[0].SetActive(active1);
        Character[1].SetActive(active2);
        Character[2].SetActive(active3);
    }

    // Start is called before the first frame update
    void Start()
    {
        SetActiveCharacter(true, false, false);
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
