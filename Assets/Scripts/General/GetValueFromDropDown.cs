using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] public List<AudioClip> sourceList;
    //public List<TMP_Dropdown.OptionData> options;

    // = SoundController.Instance.Sources

    //private void Awake()
    //{
    //    dropdown.AddOptions(options);
    //}

    public void GetDropdownValue()
    {
        int PickedEntryIndex = dropdown.value;
        //var selectionOption = dropdown.options[PickedEntryIndex];
        SoundController.Instance.PlayMusic(sourceList[PickedEntryIndex]);
        //options[PickedEntryIndex] = options[0];
        //options[0] = selectionOption;
        //var music0 = sourceList[0];
        //sourceList[0] = sourceList[PickedEntryIndex];
        //sourceList[PickedEntryIndex] = music0;
    }
}
