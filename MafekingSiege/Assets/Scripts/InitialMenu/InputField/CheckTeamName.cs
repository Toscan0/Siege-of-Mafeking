using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Dropdown))]
public class CheckTeamName : MonoBehaviour
{
    public static Action<string> OnTeamNameChoosen;

    // Dropdown text
    [SerializeField]
    private Text label;
    [SerializeField]
    private Color mandatoryFieldColor;
    [SerializeField]
    private Color defaultColor;

    private enum teamNames {
        None,
        Bathing_Towell,
        Baking_Powder,
        M_Hala_Panzi,
        Impisa,
        Katankye,
        Chief_Lone_Pine_On_Skyline
    }
    private string selectedTeamName = "";
    private Dropdown dropdown;

    private void Awake()
    {
        dropdown = GetComponent<Dropdown>();
    }

    private void Start()
    {
        PopulateList();
        Dropdown_IndexChanged(0);
    }

    private void PopulateList()
    {
        string[] enumNames = Enum.GetNames(typeof(teamNames));
        List<string> names = new List<string>(enumNames);
        dropdown.AddOptions(names);
    }

    public void Dropdown_IndexChanged(int newIndex)
    {
        string name = ((teamNames)newIndex).ToString();
        selectedTeamName = name;

        if(newIndex == 0)
        {
            label.color = mandatoryFieldColor;
            OnTeamNameChoosen?.Invoke("");
        }
        else
        {
            label.color = defaultColor;

            OnTeamNameChoosen?.Invoke(name);
        }
    }
}
