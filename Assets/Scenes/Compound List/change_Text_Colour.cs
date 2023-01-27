using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class change_Text_Colour : MonoBehaviour
{

    TextMeshProUGUI ComName;

    string compound;
    public void changeButtonTextColour(string moleculeName)
    {
        foreach (Transform child in transform)
        {
            compound = child.GetChild(0).gameObject.name.ToString();
            Debug.Log("Text name: "+ compound + " " + moleculeName);
            if (compound == moleculeName)
            {
                ComName = child.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
                ComName.color = Color.white;
            }
            else
            {
                ComName = child.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
                ComName.color = Color.black;
            }
        }
    }
}
