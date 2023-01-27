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

    public Button Quiz;
    public Button profile;
    public TextMeshProUGUI quizLine;

    static DatabaseReference reference;
    static DataSnapshot snapshot;

    private void Start()
    {
        if (GuestMode.GuestModeOn)
        {
            profile.gameObject.SetActive(false);

        }
    }
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

    public void quiz()
    {
        loadPoint();
    }

    public async void loadPoint()
    {

        reference = FirebaseDatabase.DefaultInstance.RootReference;

        Debug.Log("Fetching XP");

        await Task.Run(() =>
        {
            Debug.Log(userLoginInfo.userID);
            var dbTask = reference.Child("QuizPoints").Child(userLoginInfo.userID).GetValueAsync();

            if (dbTask.Result != null)
            {
                snapshot = dbTask.Result;
                int buildAtomxp = int.Parse(snapshot.Child("BuildingAnAtomXP").Value.ToString());
                int periodictablexp = int.Parse(snapshot.Child("PeriodicTableXP").Value.ToString());
                int compformxp = int.Parse(snapshot.Child("CompoundFormingXP").Value.ToString());
                QuizHome.points = buildAtomxp + periodictablexp + compformxp;
            }
        });

        SceneManager.LoadScene("QuizHome");

    }

}
