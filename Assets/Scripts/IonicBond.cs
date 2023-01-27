using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IonicBond : MonoBehaviour
{

    Vector3 originalPos;
    Vector3 newPosition;
    public GameObject objectToFind;
    GameObject objectToFind2;
    GameObject objectToFind3;
   // GameObject objectToFind4;
    GameObject objectToFind5;
    public GameObject saltModel;

    GameObject imageTargetToFind;
    public GameObject firstTarget;
    public GameObject secondTarget;
    public GameObject cam;

    public GameObject firstObject;
    public string firstObjectName;
    public float distance;
    public float distance2;


    public GameObject otherobj;//your other object

    bool isCollision;
   
    void Start()
    {
        isCollision= false;

        otherobj = GameObject.FindGameObjectWithTag("sodium");
      
        objectToFind2 = GameObject.FindGameObjectWithTag("NEW");
        cam = GameObject.FindGameObjectWithTag("Finish");

        saltModel = GameObject.FindGameObjectWithTag("salt");

        if (objectToFind != null)
        {
            Renderer[] rs = objectToFind.GetComponentsInChildren<Renderer>();

            foreach (Renderer r in rs)
                r.enabled = false;
        }

        if (objectToFind2 != null)
        {
            Renderer[] rs3 = objectToFind2.GetComponentsInChildren<Renderer>();

            foreach (Renderer r in rs3)
                r.enabled = false;
        }


        if (saltModel != null)
        {
            Renderer[] rs6 = saltModel.GetComponentsInChildren<Renderer>();

            foreach (Renderer r in rs6)
                r.enabled = false;
        }


        firstObjectName = firstObject.name;

        if (gameObject.name!=null)
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

       // distance = firstTarget.transform.position.x, secondTarget.transform.position
        if (distance > 70 )
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
            }

            if (saltModel != null)
            {
                saltModel.SetActive(false);
             
            }

        }

        // Collision er distance update korete hobe

        newPosition = objectToFind.transform.position;
        distance2 = Vector3.Distance(cam.transform.position, newPosition);

        if (saltModel != null)
        {
            saltModel.transform.position = newPosition; 

        }

        if ( objectToFind != null)
        {
            if (distance2>250 && saltModel!=null)
            {
                Debug.Log("salt load hbar kotha");
  

                Renderer[] rsObjectSalt = saltModel.GetComponentsInChildren<Renderer>();
                foreach (Renderer r in rsObjectSalt)
                    r.enabled = true;


                saltModel.GetComponent<AudioSource>().enabled = true;

                saltModel.SetActive(true);



                Renderer[] rsObject = objectToFind.GetComponentsInChildren<Renderer>();
                foreach (Renderer r in rsObject)
                    r.enabled = false;
           //     objectToFind.SetActive(false);

            }




            if (distance2 < 250 && objectToFind != null && saltModel!=null)
        {
                //    saltModel.SetActive(false);
                //     objectToFind.SetActive(true);



                Renderer[] rsObjectSalt = saltModel.GetComponentsInChildren<Renderer>();
                foreach (Renderer r in rsObjectSalt)
                    r.enabled = false;



                Renderer[] rsObject = objectToFind.GetComponentsInChildren<Renderer>();
                foreach (Renderer r in rsObject)
                    r.enabled = true;


            }
        }


   

        Debug.Log("Nacl er updated position: " + distance2);


    }
    private void OnTriggerEnter(Collider other)
    {
       Debug.Log("Collision Detected with : "+ other.name);

            originalPos = firstTarget.transform.position;

            if (gameObject.name!=null)
            {
                Renderer[] rs = GetComponentsInChildren<Renderer>();
                foreach (Renderer r in rs)
                    r.enabled = false;
                Debug.Log("Render and set active off hoye gese : " + gameObject.name);
            }
     
            if (other.name!=null)
            {
                Debug.Log("Collision Detected with : " + firstObjectName);
                Renderer[] rs21 = firstObject.GetComponentsInChildren<Renderer>();
                foreach (Renderer r in rs21)
                    r.enabled = false;

            
            }

            if (objectToFind != null)
            {
                objectToFind.SetActive(true);

                Renderer[] rsObject = objectToFind.GetComponentsInChildren<Renderer>();
                foreach (Renderer r in rsObject)
                    r.enabled = true;

                objectToFind.transform.position = originalPos;
                objectToFind.GetComponent<AudioSource>().enabled = true;


      //      Renderer[] rsObjectSalt = saltModel.GetComponentsInChildren<Renderer>();
        //    foreach (Renderer r in rsObjectSalt)
        //        r.enabled = true;

            saltModel.transform.position = objectToFind.transform.position;
            saltModel.GetComponent<AudioSource>().enabled = true;


            isCollision = true;

            newPosition = objectToFind.transform.position;

            Debug.Log("Baccha Hbe na" + objectToFind.transform.localPosition.x + objectToFind.transform.localPosition.y + objectToFind.transform.localPosition.z);

            }
            
  //      }

    }
}
