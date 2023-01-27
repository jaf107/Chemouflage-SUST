using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Show_compound : MonoBehaviour
{

    public GameObject compounds;

    GameObject compoundSelected;

    string[] molecules = { "H2O", "CO2", "NaCl"};

    Dictionary<string, GameObject> allCompounds = new Dictionary<string, GameObject>();

    Dictionary<string, string> fullName = new Dictionary<string, string>() { { "H2O", "Water" }, { "NaCl", "Sodium Chloride" }, { "CO2", "Carbon dioxide" }};

    Dictionary<string, int> ionic_covalent = new Dictionary<string, int>() { { "H2O", 2 }, { "NaCl", 1 }, { "CO2", 2 }};  // 1 for ionic, 2 for covalent

    public TextMeshProUGUI Name;
    public Text BS_crystalModel;

    public static string compoundSelectedName;


    void Start()
    {
        for(int i = 0; i < molecules.Length; i++)
        {
            compounds = GameObject.Find("Compounds/" + molecules[i]);
            allCompounds.Add(molecules[i], compounds);
            if (molecules[i] != "CO2")      // show co2 at first
            {
                allCompounds[molecules[i]].SetActive(false);
            }
        }

        compoundSelectedName = "CO2";
        Name.SetText(fullName["CO2"]);
        if (ionic_covalent["CO2"] == 1)
        {
            BS_crystalModel.text = "Lattice Structure";
        }
        else
        {
            BS_crystalModel.text = "Ball and Stick Model";
        }

    }


    public void show(string moleculeName)
    {
        compoundSelectedName = moleculeName;
        resetOthers(moleculeName);
        //Debug.Log(moleculeName);
        allCompounds[moleculeName].SetActive(true);
        Name.SetText(fullName[moleculeName]);

        if (ionic_covalent[moleculeName] == 1)
        {
            BS_crystalModel.text = "Lattice Structure";
        }
        else
        {
            BS_crystalModel.text = "Ball and Stick Model";
        }
    }

    public void resetOthers(string name)
    {
        for(int i = 0; i < molecules.Length; i++)
        {
            if (molecules[i] != name)
            {
                if (allCompounds[molecules[i]].active)
                {
                    allCompounds[molecules[i]].SetActive(false);
                }
            }
        }
    }


}
