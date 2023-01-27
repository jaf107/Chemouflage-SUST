using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject canvasbg;

    public GameObject signIn;
    public GameObject guest;
    public GameObject create;
    public GameObject play;

    private User userload;
    public void Start()
    {
        userload = userLoginInfo.loadInfo();
        if (userload.ID != "")
        {
            userLoginInfo.userID = userload.ID;
            userLoginInfo.name = userload.Name;
            userLoginInfo.email = userload.Email;
            Debug.Log(userload);
            addPlay();
        }
    }

    private void addPlay()
    {
        signIn.SetActive(false);
        guest.SetActive(false);
        create.SetActive(false);
        play.SetActive(true);
    }
    public void playasGuest()
    {
        GuestMode.GuestModeOn = true;
        SceneManager.LoadScene("2nd Page");
    }

    public void playSignedIn()
    {
        GuestMode.GuestModeOn = false;
        SceneManager.LoadScene("2nd Page");
    }

    public void Login()
    {
        UIManager.loginorsignup = "login";
        SceneManager.LoadScene("FirebaseLogin");
        ;
    }

    public void Register()
    {
        UIManager.loginorsignup = "signup";
        SceneManager.LoadScene("FirebaseLogin");
        ;
    }
    public void quitGame()
    {
        Debug.Log("I Quit");
        Application.Quit();
    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("I Quit");
            canvasbg.GetComponent<Image>().color = new Color32(200, 200, 200, 255);

            PopUpSystem pop = GameObject.Find("EventSystem").GetComponent<PopUpSystem>();
            pop.popUp();

            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
        }
    }

}
