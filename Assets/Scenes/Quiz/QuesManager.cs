using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using TMPro;
using Firebase;
using Firebase.Database;
using System.Threading.Tasks;

public class QuesManager : MonoBehaviour
{
    string[] quesAll;

    public static List<Question> unansweredQuestions = new List<Question>();

    private Question currentQuestion;

    public static string chapterName;

    [SerializeField]
    private TextMeshProUGUI questionText;
    [SerializeField]
    private TextMeshProUGUI AText;
    [SerializeField]
    private TextMeshProUGUI BText;
    [SerializeField]
    private TextMeshProUGUI CText;
    [SerializeField]
    private TextMeshProUGUI DText;

    [SerializeField]
    private Text LeftquesToAns;

    [SerializeField]
    private float delayNextQues = 0.2f;

    private static int point = 0;
    private static int quesToAns;
    private static int quesTotal;

    public Sprite options;
    public Sprite correct;
    public Sprite wrong;

    public Slider slider;

    static DatabaseReference reference;
    static DataSnapshot snapshot;

    public static bool timesUp = false;

    public static int XP;
    public static float Time;
    public static int accuracy;


    public void Start()
    {
        
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        XP = 0;
        Time = 0;
        accuracy = 100;

        //loadQuestions();

        quesToAns = unansweredQuestions.Count;
        quesTotal = unansweredQuestions.Count;
        LeftquesToAns.text = "" + quesToAns;
        Debug.Log("SIZE ISSS " + unansweredQuestions.Count);

        setCurrentQuestion();

    }

    private void Update()
    {
        if (timesUp)
        {
            userNotSelect();
        }
    }


    private void setCurrentQuestion()
    {
        int randQuesIndex = Random.Range(0, unansweredQuestions.Count-1);
        Debug.Log("Random "+ randQuesIndex);
        currentQuestion = unansweredQuestions[randQuesIndex];

        questionText.text = currentQuestion.question;
        AText.text = currentQuestion.optionA;
        BText.text = currentQuestion.optionB;
        CText.text = currentQuestion.optionC;
        DText.text = currentQuestion.optionD;


        unansweredQuestions.RemoveAt(randQuesIndex);

    }

    IEnumerator resetAll()
    {

        yield return new WaitForSeconds(delayNextQues);

        if (quesToAns == 0)
        {
            updateXP();
            SceneManager.LoadScene("QuizEnd");
        }
        else
        {
            GameObject.Find("OptionA").GetComponent<Image>().sprite = options;
            GameObject.Find("OptionB").GetComponent<Image>().sprite = options;
            GameObject.Find("OptionC").GetComponent<Image>().sprite = options;
            GameObject.Find("OptionD").GetComponent<Image>().sprite = options;

            GameObject.Find("OptionA").GetComponent<Button>().enabled = true;
            GameObject.Find("OptionB").GetComponent<Button>().enabled = true;
            GameObject.Find("OptionC").GetComponent<Button>().enabled = true;
            GameObject.Find("OptionD").GetComponent<Button>().enabled = true;

            Timer.ResetAll();

            setCurrentQuestion();
        }

    }

    public void userSelect(string option)
    {
        quesToAns--;
        LeftquesToAns.text = "" + quesToAns;
        float showLeftQuesBar = ((float)(quesTotal - quesToAns) / (float)quesTotal);
        slider.value = showLeftQuesBar;                  // memorizing e eigula correct er if er moddhe thakbe

        if (currentQuestion.correctAns == option)
        {
            XP += 5;
            Debug.Log("Correct " + XP + " "+ currentQuestion.correctAns);
            GameObject.Find("Option" + currentQuestion.correctAns).GetComponent<Image>().sprite = correct ;
            GameObject.Find("OptionC").GetComponent<AudioSource>().Play();   // C te correct sound rakhbo


        }
        else
        {
            accuracy -= (100 / quesTotal);
            Debug.Log("Wrong");
            GameObject.Find("Option" + currentQuestion.correctAns).GetComponent<Image>().sprite = correct;
            GameObject.Find("Option" + option).GetComponent<Image>().sprite = wrong;
            GameObject.Find("OptionD").GetComponent<AudioSource>().Play();   // D te wrong sound
        }

        Debug.Log("New size " + unansweredQuestions.Count);

        GameObject.Find("OptionA").GetComponent<Button>().enabled = false;
        GameObject.Find("OptionB").GetComponent<Button>().enabled = false;
        GameObject.Find("OptionC").GetComponent<Button>().enabled = false;
        GameObject.Find("OptionD").GetComponent<Button>().enabled = false;


        StartCoroutine(resetAll());
    }

    public void userNotSelect()
    {
        GameObject.Find("Option" + currentQuestion.correctAns).GetComponent<Image>().sprite = correct;
        StartCoroutine(resetAll());
    }

    public async void updateXP()
    {

        reference = FirebaseDatabase.DefaultInstance.RootReference;

        Debug.Log("HellooXP");

        await Task.Run(() =>
        {
            Debug.Log(userLoginInfo.userID);
            var dbTask = reference.Child("QuizPoints").Child(userLoginInfo.userID).GetValueAsync();

            if (dbTask.Result != null)
            {
                snapshot = dbTask.Result;
                int getPrevxp = int.Parse(snapshot.Child(chapterName + "XP").Value.ToString());
                if (XP > getPrevxp)
                {
                    var update = reference.Child("QuizPoints").Child(userLoginInfo.userID).Child(chapterName + "XP").SetValueAsync(XP);
                }

            }
        });

    }

    private void memorize()
    {
        unansweredQuestions.Insert(2, currentQuestion);
    }

}
