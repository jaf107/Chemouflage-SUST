using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class play_animation : MonoBehaviour
{

    GameObject compoundBS;

    GameObject compoundStruct;

    public GameObject playStructureButton;
    public GameObject playBSButton;
    public Sprite play;
    public Sprite pause;

    static bool pause_play_BS = true;        // true means playing, false means paused
    static bool pause_play_Structure = true;

    string compoundSelected;

    public void playAnimation()
    {
        playStructureButton.GetComponent<Image>().sprite = pause;
        compoundSelected = Show_compound.compoundSelectedName;
        compoundStruct = GameObject.Find(compoundSelected + "/Structural");

        compoundStruct.GetComponent<Animator>().Play("structure"+compoundSelected);
        
        StartCoroutine(changeButton());
    }

    IEnumerator changeButton()
    {
        yield return new WaitForSeconds(3);
        playStructureButton.GetComponent<Image>().sprite = play;
        Debug.Log("Wait done");
    }


    public void playpauseBS()
    {
        compoundSelected = Show_compound.compoundSelectedName;
        Debug.Log(compoundSelected);
        if (pause_play_BS)
        {
            GameObject.Find(compoundSelected+"/BS").GetComponent<Animator>().enabled = false;
            pause_play_BS = false;
            playBSButton.GetComponent<Image>().sprite = play;
        }
        else
        {
            GameObject.Find(compoundSelected + "/BS").GetComponent<Animator>().enabled = true;
            pause_play_BS = true;
            playBSButton.GetComponent<Image>().sprite = pause;
        }
        
        
    }
}
