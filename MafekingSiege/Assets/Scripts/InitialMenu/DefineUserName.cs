using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefineUserName : MonoBehaviour
{
    public static Action<string> OnUserNameChoosen;

    [SerializeField]
    private Text label;
    [SerializeField]
    private Color mandatoryFieldColor;
    [SerializeField]
    private Color defaultColor;

    private string selectedUserName = "";
    private string selectedTeamName = "";
    private string[] userNames = { };

    private string[] Bathing_Towell = 
    {
        "None",
        "Diogo",
        "Teresa",
        "Beatriz",
        "Henrique",
        "Francisco",
        "Leonor",
        "Gonçalo",
        "Diogo_Pereira",
        "Catarina",
        "Rita",
        "Ângelo",
    };
    private string[] Baking_Powder =
    {
        "None",
        "Rodrigo",
        "Francisco",
        "Tiago",
        "Gonçalo_Contente",
        "Sara",
        "Gonçalo_Costa",
        "Tomás",
        "Soraia",
        "Ivo",
        "Madalena",
        "António"
    };
    private string[] M_Hala_Panzi =
    {
        "None",
        "Constanca",
        "Carlota",
        "Beatriz",
        "Anamar",
        "Maria",
        "Samuel",
        "Rafael",
        "Pedro_Neves",
        "David",
        "Sara",
        "Pedro_Queirós"
    };
    private string[] Impisa =
    {
        "None",
        "Simão",
        "João",
        "Leonor_Pereira",
        "Rita",
        "Santiango",
        "Leonor_Marques",
        "Nuno",
        "Maria",
        "Lara",
        "Inês",
        "Ângelo",
        "Francisco",
    };
    private string[] Katankye =
    {
        "None",
        "Afonso",
        "Henrique",
        "Ricardo",
        "Pedro",
        "Gabriela",
        "Sara",
        "Diogo",
        "João",
        "Marta",
        "Beatriz",
        "Luísa",
        "André",
        "Mariana"
    };
    private string[] Chief_Lone_Pine_On_Skyline =
    {
        "None",
        "Leonor",
        "David",
        "Carolina",
        "Carlota",
        "Henrique",
        "Francisco",
        "Vasco",
        "Gonçalo",
        "Zé",
        "Joana",
        "Beatriz",
        "André",
        "Bernardo"
    };
    private string[] Dirigente =
    {
        "None",
        "Franco",
        "Claudia",
        "Bernardo",
        "Tiago",
        "Inês_Mata",
        "Carla",
        "Lituxa",
        "Ricardo",
        "Marcelo",
        "Sérgio",
        "Zé",
        "Inês_Bom",
        "Ayala",
        "Fred",
    };

    private Dropdown dropdown;

    private void Awake()
    {
        dropdown = GetComponent<Dropdown>();
        DefineTeamName.OnTeamNameChoosen += TeamNameChoosen;
    }

    private void Start()
    {
        PopulateList();
        Dropdown_IndexChanged(0);
    }


    private void PopulateList()
    {
        dropdown.ClearOptions();
        string[] enumNames = userNames;
        List<string> names = new List<string>(enumNames);
        dropdown.AddOptions(names);
    }

    public void Dropdown_IndexChanged(int newIndex)
    {
        string playerName = "";

        if (userNames.Length > 0)
        {
            playerName = userNames[newIndex];
            selectedUserName = playerName;
        }

        if (newIndex == 0)
        {
            label.color = mandatoryFieldColor;
            OnUserNameChoosen?.Invoke("");
        }
        else
        {
            label.color = defaultColor;

            OnUserNameChoosen?.Invoke(playerName);
        }
    }

    private void TeamNameChoosen(string teamName)
    {
        selectedTeamName = teamName;
        if (teamName == "None" || teamName == "" || teamName == null)
        {
            userNames = new string[] { };
            dropdown.interactable = false;
        }
        if (teamName == "Bathing_Towell")
        {
            userNames = Bathing_Towell;
            dropdown.interactable = true;
        }
        else if (teamName == "Baking_Powder")
        {
            userNames = Baking_Powder;
            dropdown.interactable = true;
        }
        else if (teamName == "M_Hala_Panzi")
        {
            userNames = M_Hala_Panzi;
            dropdown.interactable = true;
        }
        else if (teamName == "Impisa")
        {
            userNames = Impisa;
            dropdown.interactable = true;
        }
        else if (teamName == "Katankye")
        {
            userNames = Katankye;
            dropdown.interactable = true;
        }
        else if (teamName == "Chief_Lone_Pine_On_Skyline")
        {
            userNames = Chief_Lone_Pine_On_Skyline;
            dropdown.interactable = true;
        }
        else if (teamName == "Dirigente")
        {
            userNames = Dirigente;
            dropdown.interactable = true;
        }

        PopulateList();
    }

    private void OnDestroy()
    {
        DefineTeamName.OnTeamNameChoosen -= TeamNameChoosen;
    }
}
