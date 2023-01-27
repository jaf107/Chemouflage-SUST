using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    float speed = 5.0f; //how fast it shakes
    float amount = 1.0f; //how much it shakes

    //GameObject elements = this;
    private Vector3 pos;

    int flagxy = 0;

    private void Start()
    {
        pos = transform.position;
    }

    void Update()
    {
        if (flagxy == 0)
        {
            Vector3 newPos = pos;
            newPos.x += (Mathf.Sin(Time.time * speed) * amount);
            transform.position = newPos;
            flagxy = 1;
        }
        else if (flagxy == 1)
        {
            Vector3 newPos = pos;
            newPos.y += Mathf.Sin(Time.time * speed) * amount;
            transform.position = newPos;
            flagxy = 0;
        }
        
    }
}
