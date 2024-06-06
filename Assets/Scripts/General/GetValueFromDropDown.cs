using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] public List<AudioClip> sourceList = SoundController.Instance.Sources;

    public void GetDropdownValue()
    {
        int PickedEntryIndex = dropdown.value;
        string selectionOption = dropdown.options[PickedEntryIndex].text;
        Debug.Log(PickedEntryIndex);
        SoundController.Instance.PlayMusic(sourceList[PickedEntryIndex]);
    }
}
