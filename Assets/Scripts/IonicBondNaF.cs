using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IonicBondNaF : MonoBehaviour
{

    Vector3 originalPos;
    public GameObject objectToFind;
    GameObject objectToFind2;
    GameObject objectToFind3;
    GameObject objectToFind4;
    GameObject objectToFind5;

    GameObject imageTargetToFind;
    public GameObject firstTarget;
    public GameObject secondTarget;

    public GameObject firstObject;
    public string firstObjectName;
    public float distance;


    public GameObject otherobj;//your other object
    public string scr;// your secound script name
   

    void Start()
    {

        scr = "IonicBond";  
        otherobj = GameObject.FindGameObjectWithTag("sodium");
        objectToFind2 = GameObject.FindGameObjectWithTag("NEW");
        objectToFind4 = GameObject.FindGameObjectWithTag("salt");
        objectToFind5 = GameObject.FindGameObjectWithTag("LICL");
        objectToFind3 = GameObject.FindGameObjectWithTag("NAF");
        if (objectToFind != null)
        {
            Renderer[] rs = objectToFind2.GetComponentsInChildren<Renderer>();

            foreach (Renderer r in rs)
                r.enabled = false;
        }

        if (objectToFind2 != null)
        {
            Renderer[] rs3 = objectToFind2.GetComponentsInChildren<Renderer>();

            foreach (Renderer r in rs3)
                r.enabled = false;
        }

        if (objectToFind3 != null)
        {
            Renderer[] rs4 = objectToFind3.GetComponentsInChildren<Renderer>();

            foreach (Renderer r in rs4)
                r.enabled = false;
        }

        if (objectToFind5 != null)
        {
            Renderer[] rs5 = objectToFind5.GetComponentsInChildren<Renderer>();

            foreach (Renderer r in rs5)
                r.enabled = false;
        }
        firstObjectName = firstObject.name;
      

        if (gameObject.name != null)
        {
            Renderer[] rs = GetComponentsInChildren<Renderer>();
            foreach (Renderer r in rs)
                r.enabled = false;
            //   gameObject.SetActive(false);
            Debug.Log("initially off kora : " + gameObject.name);
        }


    }

    void Update()
    {

        distance = Vector3.Distance(firstTarget.transform.position, secondTarget.transform.position);


        if (distance > 70)
        {
            //  Debug.Log("2 ta image target er distance " + distance);
            if (gameObject.activeSelf)
            {
                Renderer[] rs = GetComponentsInChildren<Renderer>();
                foreach (Renderer r in rs)
                    r.enabled = true;
            }

            if (firstObject)
            {

                Renderer[] rs2 = firstObject.GetComponentsInChildren<Renderer>();
                foreach (Renderer r in rs2)
                    r.enabled = true;
            }
            if (objectToFind != null)
            {

                objectToFind.SetActive(false);
            //    (otherobj.GetComponent(scr) as MonoBehaviour).enabled = true;
               
            }


        }

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision Detected with : " + other.name);

        originalPos = secondTarget.transform.localPosition;

        if (gameObject.name != null)
        {
            Renderer[] rs = GetComponentsInChildren<Renderer>();
            foreach (Renderer r in rs)
                r.enabled = false;
            Debug.Log("Render and set active off hoye gese : " + gameObject.name);
        }

        if (other.name == firstObjectName)
        {
            Debug.Log("Collision Detected with : " + firstObjectName);
            Renderer[] rs21 = other.GetComponentsInChildren<Renderer>();
            foreach (Renderer r in rs21)
                r.enabled = false;

            if (firstObjectName != null)
            {
                (otherobj.GetComponent(scr) as MonoBehaviour).enabled = false;
            }
        }

        if (objectToFind != null)
        {
            objectToFind.SetActive(true);

            Renderer[] rsObject = objectToFind.GetComponentsInChildren<Renderer>();
            foreach (Renderer r in rsObject)
                r.enabled = true;

            objectToFind.transform.localPosition = originalPos;
            Debug.Log("Baccha hbe na" + objectToFind.transform.localPosition.x + objectToFind.transform.localPosition.y + objectToFind.transform.localPosition.z);


        


        }

        //      }

    }
}
