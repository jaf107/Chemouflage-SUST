using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class compoundInit : MonoBehaviour
{
    GameObject objectToFind;
    GameObject objectToFind2;
    GameObject objectToFind4;
    GameObject objectToFind3;
    GameObject objectToFind5;


void Start()
    {
        objectToFind = GameObject.FindGameObjectWithTag("CO2");
        objectToFind2 = GameObject.FindGameObjectWithTag("NEW");
        objectToFind4 = GameObject.FindGameObjectWithTag("salt");
        objectToFind5 = GameObject.FindGameObjectWithTag("LICL");
        objectToFind3 = GameObject.FindGameObjectWithTag("NAF");

        if (objectToFind != null)
        {
            Renderer[] rs2 = objectToFind.GetComponentsInChildren<Renderer>();
            foreach (Renderer r in rs2)
                r.enabled = false;
        }
        if (objectToFind2 != null)
        {
            Renderer[] rs3 = objectToFind2.GetComponentsInChildren<Renderer>();

            foreach (Renderer r in rs3)
                r.enabled = false;
        }

        if (objectToFind5 != null)
        {
            Renderer[] rs4 = objectToFind5.GetComponentsInChildren<Renderer>();

            foreach (Renderer r in rs4)
                r.enabled = false;
        }


        if (objectToFind3 != null)
        {
            Renderer[] rs4 = objectToFind3.GetComponentsInChildren<Renderer>();

            foreach (Renderer r in rs4)
                r.enabled = false;
        }

    }
}
