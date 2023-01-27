using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Profile : MonoBehaviour
{

    public Text DisplayName;
    public Text Name;
    public Text Email;

    private void Start()
    {
        DisplayName.text = userLoginInfo.name;
        Name.text = userLoginInfo.name;
        Email.text = userLoginInfo.email;

        Debug.Log("Email is " + userLoginInfo.email);
    }

    public void Signout()
    {
        User logoutUser = new User("", "", "");
        userLoginInfo.saveInfo(logoutUser);
        SceneManager.LoadScene("Menu");
    }
}
