using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H20Bond : MonoBehaviour
{
    Vector3 originalPos;
    GameObject objectToFind;
    GameObject objectToFind2;
    GameObject objectToFind3;
    GameObject objectToFind4;
    GameObject imageTargetToFind;
    GameObject firstTarget;
    GameObject firstObject;
    GameObject secondTarget;
    bool setOn = false;


    public MeshRenderer newMesh;
    public float distance;
 
    // Start is called before the first frame update
    void Start()
    {

        objectToFind = GameObject.FindGameObjectWithTag("NEW");
         objectToFind2 = GameObject.FindGameObjectWithTag("salt");
        objectToFind3 = GameObject.FindGameObjectWithTag("NAF");
        objectToFind4 = GameObject.FindGameObjectWithTag("CO2");

        firstTarget = GameObject.FindGameObjectWithTag("HTARGET");
        secondTarget = GameObject.FindGameObjectWithTag("OTARGET");
        firstObject = GameObject.FindGameObjectWithTag("OXYGENCOLLIDER");
        Debug.Log("H target  er position " + firstTarget.transform.position);
        Debug.Log("O target  er position " + secondTarget.transform.position);

        // objectToFind.GetComponentInChildren<Renderer>().enabled = false;
        //newMesh = objectToFind.GetComponent<Renderer>();

        if (objectToFind)
        {
            Renderer[] rs2 = objectToFind.GetComponentsInChildren<Renderer>();
            foreach (Renderer r in rs2)
                r.enabled = true;

            

        }

            if (objectToFind2 != null)
            {
                Renderer[] rs3 = objectToFind2.GetComponentsInChildren<Renderer>();
                foreach (Renderer r in rs3)
                    r.enabled = false;

            }


            if (objectToFind3 != null) { 

                Renderer[] rs4 = objectToFind3.GetComponentsInChildren<Renderer>();
            foreach (Renderer r in rs4)
                r.enabled = false;
        }

            if (objectToFind4 != null)
            {
                Renderer[] rs5 = objectToFind4.GetComponentsInChildren<Renderer>();
                foreach (Renderer r in rs5)
                    r.enabled = false;
            }
        


    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("H target  er position " + firstTarget.transform.position);
        Debug.Log("O target  er position " + secondTarget.transform.position);


        firstTarget = GameObject.FindGameObjectWithTag("HTARGET");
        secondTarget = GameObject.FindGameObjectWithTag("OTARGET");

        distance = Vector3.Distance(firstTarget.transform.position, secondTarget.transform.position);
       // distance = Vector3.Distance(gameObject.transform.position, firstObject.transform.position);

        Debug.Log("2 ta image target er distance " + distance);


            if (distance > 70)
       {

            if (gameObject.activeSelf)
            {
                Renderer[] rs = GetComponentsInChildren<Renderer>();
                foreach (Renderer r in rs)
                    r.enabled = true;
                
            }
        
            if(firstObject)
            {
                Renderer[] rs2 = firstObject.GetComponentsInChildren<Renderer>();
                foreach (Renderer r in rs2)
                    r.enabled = true;
            }

            if(objectToFind!=null)
            objectToFind.SetActive(false);

        }


    }
    private void OnTriggerEnter(Collider other)
    {
       

            imageTargetToFind = GameObject.FindGameObjectWithTag("OTARGET");
            originalPos = imageTargetToFind.transform.localPosition;

            if (gameObject.name == "Hydrogen")
            {
                Renderer[] rs = GetComponentsInChildren<Renderer>();
                foreach (Renderer r in rs)
                    r.enabled = false;
            }
            if (other.name == "Oxygen")
            {

                Renderer[] rs2 = other.GetComponentsInChildren<Renderer>();
                foreach (Renderer r in rs2)
                    r.enabled = false;
            }

            Debug.Log("Second Target ta holo chlorine");

            if(objectToFind!=null)
            {
                objectToFind.SetActive(true);
             
                Renderer[] rsObject = objectToFind.GetComponentsInChildren<Renderer>();
                foreach (Renderer r in rsObject)
                    r.enabled = true;
                objectToFind.transform.localPosition = originalPos;
                objectToFind.GetComponent<AudioSource>().enabled = true;
                Debug.Log("Baccha hbe na" + objectToFind.transform.localPosition.x + objectToFind.transform.localPosition.y + objectToFind.transform.localPosition.z);

            }

      


    }



}