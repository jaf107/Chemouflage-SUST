using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateSpheres : MonoBehaviour
{

    Vector3 movement;
    public int xi, yi, zi;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
            movement = new Vector3(xi, yi, zi);
        transform.Rotate(Vector3.up * 50 * Time.deltaTime, Space.Self);

      //  transform.Rotate(movement*Time.deltaTime);
    }
}
