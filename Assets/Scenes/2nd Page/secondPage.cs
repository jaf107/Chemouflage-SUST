using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Firebase.Database;
using System.Threading.Tasks;

public class secondPage : MonoBehaviour
{
    private void Start()
    {
        if (GuestMode.GuestModeOn)
        {
            profile.gameObject.SetActive(false);

        }
    }

    public Button profile;
    public void build()
    {
        SceneManager.LoadScene("Simulate");
    }
    public void compound()
    {
        SceneManager.LoadScene("Predefined List");
    }
    public void AR()
    {
        SceneManager.LoadScene("ARoptions");
    }

    public void Profile()
    {
        SceneManager.LoadScene("Profile");
    }

}
