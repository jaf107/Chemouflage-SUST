using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Firebase.Database;
using System.Threading.Tasks;

public class QuizComplete : MonoBehaviour
{
    public Text XP;
    public Text time;
    public Text Perf;

    static DatabaseReference reference;
    static DataSnapshot snapshot;
    void Start()
    {
        XP.text = QuesManager.XP.ToString();

        float minutes = Mathf.FloorToInt(QuesManager.Time / 60);
        float seconds = Mathf.FloorToInt(QuesManager.Time % 60);

        time.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        Perf.text = QuesManager.accuracy.ToString() + "%";
    }

    public void gotoQuiz()
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
