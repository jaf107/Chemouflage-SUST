using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showCards : MonoBehaviour
{

    public void CO2()
    {
        GameObject.Find("Hold Card Image").GetComponent<Image>().color = new Color32(255,255,255,192);
        GameObject.Find("Hold Card").GetComponent<Text>().text = "Place the C and O cards in front of the camera";
        StartCoroutine(remove());
    }
    public void H2O()
    {
        GameObject.Find("Hold Card Image").GetComponent<Image>().color = new Color32(255, 255, 255, 192);
        GameObject.Find("Hold Card").GetComponent<Text>().text = "Place the H and O cards in front of the camera";
        StartCoroutine(remove());
    }
    public void NaCl()
    {
        GameObject.Find("Hold Card Image").GetComponent<Image>().color = new Color32(255, 255, 255, 192);
        GameObject.Find("Hold Card").GetComponent<Text>().text = "Place the Na and Cl cards in front of the camera";
        StartCoroutine(remove());
    }
    public void LiCl()
    {
        GameObject.Find("Hold Card Image").GetComponent<Image>().color = new Color32(255, 255, 255, 192);
        GameObject.Find("Hold Card").GetComponent<Text>().text = "Place the Li and Cl cards in front of the camera";
        StartCoroutine(remove());
    }

    IEnumerator remove()
    {
        yield return new WaitForSeconds(3);
        GameObject.Find("Hold Card Image").GetComponent<Image>().color = new Color32(255, 255, 255, 0);
        GameObject.Find("Hold Card").GetComponent<Text>().text = "";
    }
}
