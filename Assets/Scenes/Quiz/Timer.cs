using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    Image circle;

    [SerializeField]
    [Range(0, 1)] static float time = 1f;

    public static float timeValue = 61f;
    public static float timeCompleted = 0;
    public Text timer;

    void Update()
    {
        time = (timeValue / 60);
        circle.fillAmount = time;

        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }
        timeCompleted = (61f - timeValue);
        displayTime(timeValue);
    }

    void displayTime(float time)
    {
        if (time > 0)
        {
            float minutes = Mathf.FloorToInt(time / 60);
            float seconds = Mathf.FloorToInt(time % 60);

            timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            if (time <= 11)
            {
                timer.color = Color.red;
            }
            else
            {
                timer.color = Color.black;
            }
        }
        else
        {
            time = 0;
            QuesManager.timesUp = true;
            timer.text = "Times Up";
            timer.color = Color.red;
        }


    }

    public static void ResetAll()
    {
        QuesManager.Time += timeCompleted;
        QuesManager.timesUp = false;

        time = 1f;

        timeValue = 61f;
    }

}
