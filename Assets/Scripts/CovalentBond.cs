using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CovalentBond : MonoBehaviour
{
    Vector3 originalPos;
    GameObject objectToFind;
    GameObject objectToFind2;
    GameObject objectToFind3;
    GameObject objectToFind4;
    GameObject imageTargetToFind;
    GameObject carbonTarget;
    GameObject hydrogenTarget;
    GameObject firstObject;
    GameObject secondTarget;

    public MeshRenderer newMesh;
    public float distance;

    void Start()
    {
        objectToFind = GameObject.FindGameObjectWithTag("CO2");
        objectToFind2 = GameObject.FindGameObjectWithTag("NEW");
        objectToFind3 = GameObject.FindGameObjectWithTag("NAF");
        objectToFind4 = GameObject.FindGameObjectWithTag("salt");


        carbonTarget = GameObject.FindGameObjectWithTag("CTARGET");
        hydrogenTarget = GameObject.FindGameObjectWithTag("HTARGET");
        secondTarget = GameObject.FindGameObjectWithTag("OTARGET");
        firstObject = GameObject.FindGameObjectWithTag("OXYGENCOLLIDER");

        if (objectToFind)
        {
            Renderer[] rs2 = objectToFind.GetComponentsInChildren<Renderer>();
            foreach (Renderer r in rs2)
                r.enabled = true;

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

            if (objectToFind4 != null)
            {
                Renderer[] rs5 = objectToFind4.GetComponentsInChildren<Renderer>();
                foreach (Renderer r in rs5)
                    r.enabled = false;
            }
        }

    }

  
    void Update()
    {

        distance = Vector3.Distance(carbonTarget.transform.position, secondTarget.transform.position);
    
        Debug.Log("2 ta image target er distance " + distance);


        if (distance > 70)
        {

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

            if(objectToFind!=null)
            objectToFind.SetActive(false);
           

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("OXYGENCOLLIDER"))
        {

            Debug.Log("Collision hoise");
            imageTargetToFind = GameObject.FindGameObjectWithTag("OTARGET");
            originalPos = imageTargetToFind.transform.localPosition;

            if (gameObject.name == "Carbon")
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
            if (objectToFind != null)
            {
                objectToFind.SetActive(true);
                Renderer[] rsC02 = objectToFind.GetComponentsInChildren<Renderer>();
                foreach (Renderer r in rsC02)
                    r.enabled = true;

                objectToFind.transform.localPosition = originalPos;
                Debug.Log("Baccha hbe na" + objectToFind.transform.localPosition.x + objectToFind.transform.localPosition.y + objectToFind.transform.localPosition.z);
            }
        }


    }




}