using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

using Firebase.Database;
using System.Threading.Tasks;

public class QuizHome : MonoBehaviour
{

    public static int points;

    public Button bAtom;
    public Button pTable;
    public Button cBond;

    public Button quizStart;


    public Sprite lockedPTable;
    public Sprite lockedCBond;

    public Sprite unlockedPTable;
    public Sprite unlockedCBond;

    static DatabaseReference reference;
    static DataSnapshot snapshot;

    public TextMeshProUGUI pointsEarned;
    public TextMeshProUGUI pointsReq;
    public TextMeshProUGUI unlocked;

    private int requiredPoint2ndLevel = 60;
    private int requiredPoint3rdLevel = 120;

    void Start()
    {
        pointsEarned.text = points.ToString();

        if (points > requiredPoint3rdLevel)
        {
            pointsReq.gameObject.SetActive(false);
            unlocked.text = "All chapters are unlocked!";
        }

        if (points < requiredPoint3rdLevel)
        {
            cBond.interactable = false;
            cBond.GetComponent<Image>().sprite = lockedCBond;
            pointsReq.text = (requiredPoint3rdLevel-points).ToString();
        }
        if (points < requiredPoint2ndLevel)
        {
            pTable.interactable = false;
            pTable.GetComponent<Image>().sprite = lockedPTable;
            pointsReq.text = (requiredPoint2ndLevel-points).ToString();
        }
    }

    private void Update()
    {
        pointsEarned.text = points.ToString();
    }



    public void buildAtom()
    {
        QuesManager.chapterName = "BuildingAnAtom";
    }

    public void startQuiz()
    {
        quizStart.gameObject.SetActive(false);
        load();
    }

    public async void load()
    {

        reference = FirebaseDatabase.DefaultInstance.RootReference;

        Debug.Log("Firebase connected");

        await Task.Run(() =>
        {
            var dbTask = reference.Child(QuesManager.chapterName).GetValueAsync();

            //yield return new WaitUntil(predicate: () => dbTask.IsCompleted);


            if (dbTask.Result != null)
            {
                Debug.Log("Successful in Quizhomee");
                snapshot = dbTask.Result;      // 1, 2, 3 evabe shob question

                int i = 0;
                //List<Question> unanswered = new List<Question>();

                string[] testing = new string[10];

                foreach (DataSnapshot s in snapshot.Children)
                {
                    Debug.Log("WHILEE " + s.Child("question").Value.ToString());

                    QuesManager.unansweredQuestions.Add(new Question
                    {
                        question = s.Child("question").Value.ToString(),
                        optionA = s.Child("optionA").Value.ToString(),
                        optionB = s.Child("optionB").Value.ToString(),
                        optionC = s.Child("optionC").Value.ToString(),
                        optionD = s.Child("optionD").Value.ToString(),
                        correctAns = s.Child("correct").Value.ToString()
                    });

                    i++;
                }

            }

        });

        SceneManager.LoadScene("Questions");
    }
}
