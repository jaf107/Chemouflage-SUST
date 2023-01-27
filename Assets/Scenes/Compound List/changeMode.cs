using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeMode : MonoBehaviour
{
    public void view()
    {
        SceneManager.LoadScene("Predefined List");
    }
    public void build()
    {
        SceneManager.LoadScene("MakeCompound");
    }
}
