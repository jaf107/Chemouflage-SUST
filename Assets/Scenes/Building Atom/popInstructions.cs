using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popInstructions : MonoBehaviour
{
    public GameObject popupbox;
    public Animator animator;
    public GameObject canvasbg;

    
    public void popUp()
    {
        canvasbg.GetComponent<Image>().color = new Color32(192, 192, 192, 255);
        animator.SetBool("isOpen", true);
    }

    public void close()
    {
        canvasbg.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        animator.SetBool("isOpen", false);
    }
}
