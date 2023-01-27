using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickPop : MonoBehaviour
{
    public void popInstructions()
    {
        popInstructions pop = GameObject.Find("EventSystem").GetComponent<popInstructions>();
        pop.popUp();
    }
}
