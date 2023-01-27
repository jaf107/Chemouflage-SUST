using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dragUpdated : MonoBehaviour
{

    Camera cam;
    public GameObject proton;
    public GameObject neutron;
    public GameObject electron;

    private GameObject[] pNew;            //instances of proton
    private GameObject[] nNew;            //instances of neutron
    private GameObject[] eNew;            //instances of electron



    int ip = 0;
    int iN = 0;
    int ie = 0;

    int currentP = 0;
    int currentN = 0;
    int currentE = 0;

    int numPNE = 10;  // total number of how many p,n and e are created

    bool[] PcheckInNucleus;
    bool[] NcheckInNucleus;
    bool[] EcheckInNucleus;


    int currentElementNum = 0;

    public Vector3 positionofP;            // position of proton, neutron and electron initially
    public Vector3 positionofN;
    public Vector3 positionofE;

    private Vector3 userInput;

    private float firstOrbitXLeft = 1195f;
    private float firstOrbitXRight = 1280f;

    float secondOrbitXLeft = 1168f;
    float secondOrbitXRight = 1310f;
    float secondOrbitYUp = 845f;
    float secondOrbitYDown = 721f;
    

    private Vector3 pNeutron = new Vector3(1110.6f, 787f, -850.5f);
    private Vector3 pProton = new Vector3(1112.4f, 834.2f, -850.5f);
    private Vector3 pElectron = new Vector3(1110.9f, 743f, -850.5f);

    private Vector3[] secondRoundE = { new Vector3(1246, 800, -850), new Vector3(1237, 798, -850) , new Vector3( 1250, 798, -850) , new Vector3 (1247, 791, -850),
                    new Vector3(1235,792,-850),new Vector3(1243,803,-860), new Vector3(1240,788,-850), new Vector3(1250,796,-820),new Vector3(1245,786,-850), new Vector3(1250,780,-850), new Vector3(1235,790,-850), new Vector3(1236,800,-850),
                    new Vector3(1251,787,-850),new Vector3(1243,808,-860), new Vector3(1235,782,-850), new Vector3(1252,793,-820),new Vector3(1241,790,-850), new Vector3(1232,781,-850), new Vector3(1245,782,-850), new Vector3(1240,805,-850)};
    List<Vector3> sRoundList = new List<Vector3>();

    private Vector3[] electronPosSet = { new Vector3(1195, 792, -850), new Vector3(1284, 792, -850), 
                    new Vector3(1168,791,-850), new Vector3(1312, 792, -850), new Vector3(1240, 864,-850), new Vector3(1241,721,-850),
                    new Vector3(1193, 846, -850), new Vector3(1287,846, -850), new Vector3(1290, 742, -850), new Vector3(1189, 743, -850)};

    Vector3[] protonPositions = new Vector3[10];
    Vector3[] neutronPositions = new Vector3[10];
    Vector3[] electronPositions = new Vector3[10];

    int[] electronNumber = new int[10];


    private Vector3 posCenter = new Vector3(1242.9f, 795.8f, -860f);

    public Text Symbol, mass, charge, pNumber, nNumber, eNumber, stable, ion, extraLine, stableLine;

    private string[] symbolName = { "H", "He", "Li", "Be", "B", "C", "N", "O", "F", "Ne", "Na", "Mg", "Al", "Si", "P", "S", "Cl", "Ar", "K", "Ca" };

    private int[] massofElements = { 1,4,7,9,11,12,14,16,19,20};
    private int[] neutronOfElements = { 0,2,4,5,6,6,7,8,10,10 };

    static int flag = 0;

    

    Renderer rend1st;
    Renderer rend2nd;

    private void Start()
    {
        cam = GetComponent<Camera>();
        //Debug.Log(GameObject.Find("proton").transform.position);
        pNew = new GameObject[numPNE];
        nNew = new GameObject[numPNE];
        eNew = new GameObject[numPNE];

        PcheckInNucleus = new bool[numPNE];
        NcheckInNucleus = new bool[numPNE];
        EcheckInNucleus = new bool[numPNE];

        createObject();

        sRoundList.AddRange(secondRoundE);


    }

    private Vector3 screenPoint;
    private Vector3 offset;

    private static int eNum;
    
    private static string hitObject = null;


    void OnMouseDown()
    {
        hitObject = Raycast();
        eNum = findElement(hitObject);


        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }

    void OnMouseDrag()
    {
        flag = 1;

        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;

    }

    private void Update()        // goes to nucleus or stays in start place
    {
        if (Input.GetMouseButtonUp(0))
        {

            userInput = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Debug.Log(userInput.x + "   " + userInput.y + " flag: " + flag);

            if (flag == 1)
            {
                
                rend1st = GameObject.Find("1st orbit").GetComponent<Renderer>();

                Vector3 center1st = rend1st.bounds.center;
                float radius1st = rend1st.bounds.extents.magnitude;

                rend2nd = GameObject.Find("2nd orbit").GetComponent<Renderer>();

                Vector3 center2nd = rend2nd.bounds.center;
                float radius2nd = rend2nd.bounds.extents.magnitude;

                if (hitObject.Contains("electron"))
                {

                    //if(userInput.x >= secondOrbitXLeft && userInput.x <= secondOrbitXRight && userInput.y <= secondOrbitYUp && userInput.y >= secondOrbitYDown)
                    
                    if ((userInput.x >= (center2nd.x - radius2nd)) && (userInput.x <= (center2nd.x + radius2nd)) && (userInput.y >= (center2nd.y - radius2nd)) && (userInput.y <= (center2nd.y + radius2nd)))
                    {
                        if (!EcheckInNucleus[eNum])  // not in the nucleus
                        {
                            iTween.MoveTo(GameObject.Find(hitObject), electronPosSet[currentE], 1.2f);
                            electronPositions[eNum] = electronPosSet[currentE];
                            electronNumber[eNum] = currentE+1;    // the nth for every electron
                            EcheckInNucleus[eNum] = true;
                            currentE++;
                            addExtraLine("add electron");
                        }
                        else // is already in nucleus
                        {
                            iTween.MoveTo(GameObject.Find(hitObject), electronPositions[eNum], 1.2f);
                            addExtraLine("stay electron");
                        }
                        
                    }
                    else   // go back to start
                    {
                        if (electronNumber[eNum] > 2 || electronNumber[eNum] <= 2 && currentE <= 2)
                        {
                            iTween.MoveTo(GameObject.Find(hitObject), pElectron, 1.2f);
                            if (EcheckInNucleus[eNum])
                            {
                                EcheckInNucleus[eNum] = false;
                                currentE--;
                                Debug.Log("Current electron "+ currentE);
                                addExtraLine("remove electron");
                            }
                        }
                        else
                        {
                            iTween.MoveTo(GameObject.Find(hitObject), electronPositions[eNum], 1.2f);
                            addExtraLine("stay electron");
                        }

                    }
                }
                //else if (userInput.x >= firstOrbitXLeft && userInput.x <= firstOrbitXRight)  // go inside
                else if((userInput.x >= (center1st.x - radius1st)) && (userInput.x <= (center1st.x + radius1st)) && (userInput.y >= (center1st.y - radius2nd)) && (userInput.y <= (center1st.y + radius1st)))
                {
                    Debug.Log(userInput.x + "  center " + (center1st.x - radius1st));
                    if (hitObject.Contains("proton"))
                    {
                        if (!PcheckInNucleus[eNum])
                        {
                            Debug.Log("Notun baccha ashche");
                            currentP++;
                            GameObject.Find(hitObject).transform.SetParent(GameObject.Find("p&n").transform);
                            newInNucleus(hitObject);
                            addExtraLine("new np");
                        }
                        else
                        {
                            Debug.Log("Ager bacchai");
                            alreadyInNucleus(hitObject);
                        }
                    }
                    else if (hitObject.Contains("neutron"))
                    {
                        Debug.Log("Check in nucleus " + NcheckInNucleus[eNum]);
                        if (!NcheckInNucleus[eNum])
                        {
                            Debug.Log("Notun baccha ashche");
                            currentN++;
                            GameObject.Find(hitObject).transform.SetParent(GameObject.Find("p&n").transform);
                            newInNucleus(hitObject);
                            addExtraLine("new np");
                        }
                        else
                        {
                            alreadyInNucleus(hitObject);
                        }
                    }
                }
                else  // go outside
                {
                    if (hitObject.Contains("proton"))
                    {
                        //ip = findElement(hitObject);

                        if (!PcheckInNucleus[eNum])        // new one
                        {
                            Debug.Log("bhitore dhukar agei baire jacche");
                            iTween.MoveTo(pNew[eNum], pProton, 1.2f);
                        }
                        else  // nucleus to start position
                        {
                            currentP--;
                            iTween.MoveTo(pNew[eNum], pProton, 1.2f);
                            GameObject.Find(hitObject).transform.SetParent(GameObject.Find("pne").transform);

                            switchPositions(eNum, "proton");
                            addExtraLine("new np");
                            currentElementNum--;
                        }
                    }
                    else if (hitObject.Contains("neutron"))
                    {
                        //iN = findElement(hitObject);

                        if (!NcheckInNucleus[eNum])        // new one
                        {
                            iTween.MoveTo(nNew[eNum], pNeutron, 1.2f);
                            addExtraLine("new neutron");
                            addExtraLine("new np");
                        }
                        else  // nucleus to start position
                        {
                            currentN--;

                            iTween.MoveTo(nNew[eNum], pNeutron, 1.2f);
                            GameObject.Find(hitObject).transform.SetParent(GameObject.Find("pne").transform);

                            switchPositions(eNum, "neutron");
                            addExtraLine("new np");
                            currentElementNum--;
                        }
                    }
                }

                updateInfo();
                flag = 0;
            }
        }
    }


    private void newInNucleus(string hitObject)
    {
        if (currentElementNum == 0)
        {
            Debug.Log("0 te ase");
            //GameObject.Find(hitObject).transform.position = Vector3.MoveTowards(GameObject.Find(hitObject).transform.position, posCenter, 1.0f * Time.deltaTime);
            iTween.MoveTo(GameObject.Find(hitObject), posCenter, 1.2f);

            if (hitObject.Contains("proton"))
                protonPositions[findElement(hitObject)]= posCenter;
            else if (hitObject.Contains("neutron"))
                neutronPositions[findElement(hitObject)] = posCenter;
        }
        else
        {
            int count = sRoundList.Count;
            Debug.Log("New Position " + currentElementNum + " " + count);
            Vector3 newPosition = sRoundList[currentElementNum];
            iTween.MoveTo(GameObject.Find(hitObject), newPosition, 1.2f);            //  error ashee

            if (hitObject.Contains("proton"))
                protonPositions[findElement(hitObject)] = newPosition;
            else if (hitObject.Contains("neutron"))
                neutronPositions[findElement(hitObject)] = newPosition;    // add the placed position in the list

        }

        if (hitObject.Contains("proton"))
        {
            PcheckInNucleus[findElement(hitObject)] = true;
        }
        else if (hitObject.Contains("neutron"))
        {
            NcheckInNucleus[findElement(hitObject)] = true;
        }

        currentElementNum++;
    }

    private void alreadyInNucleus(string hitObject)
    {
        if (hitObject.Contains("proton"))
        {
            ip = findElement(hitObject);
            iTween.MoveTo(pNew[ip], protonPositions[ip], 1.2f);
        }
        else if (hitObject.Contains("neutron"))
        {
            iN = findElement(hitObject);
            iTween.MoveTo(nNew[iN], neutronPositions[iN], 1.2f);
        }
    }

    private string Raycast()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            hitObject = hit.transform.name;
            Debug.Log("You selected the " + hitObject);
        }
        return hitObject;
    }

    


    private void createObject()
    {
        for (int i = 0; i < numPNE; i++)
        {
            pNew[i] = Instantiate(proton, positionofP, Quaternion.identity);
            pNew[i].transform.parent = GameObject.Find("pne").transform;
            pNew[i].name = "proton " + i;
            PcheckInNucleus[i] = false;


            nNew[i] = Instantiate(neutron, positionofN, Quaternion.identity);
            nNew[i].transform.parent = GameObject.Find("pne").transform;
            nNew[i].name = "neutron " + i;
            NcheckInNucleus[i] = false;

            eNew[i] = Instantiate(electron, positionofE, Quaternion.identity);
            eNew[i].transform.parent = GameObject.Find("pne").transform;
            eNew[i].name = "electron " + i;


        }

        Destroy(proton);
        Destroy(neutron);
        Destroy(electron);
    }

    private int findElement(string type)
    {
         for(int i = 0; i < numPNE; i++)
         {
             if (type.Contains(i.ToString()))
             {
                return i;
             }
         }
        return -1;
    }

    private void switchPositions(int index, string type)
    {
        if (type == "proton")
        {
            for (int i = 0; i < numPNE; i++)
            {
                if (PcheckInNucleus[i] && i != index)
                {
                    Debug.Log("jayga bodlaooo " + index);
                    iTween.MoveTo(pNew[i], protonPositions[index], 1.2f);
                    sRoundList.Add(protonPositions[i]);
                    protonPositions[i] = protonPositions[index];
                    PcheckInNucleus[i] = true;
                    PcheckInNucleus[index] = false;
                    return;
                }
            }
            PcheckInNucleus[index] = false;
        }
        else if (type == "neutron")
        {

            for (int i = 0; i < numPNE; i++)
            {
                if (NcheckInNucleus[i] && i != index)
                {
                    Debug.Log("jayga bodlaooo " + index);
                    iTween.MoveTo(nNew[i], neutronPositions[index], 1.2f);
                    sRoundList.Add(neutronPositions[i]);
                    neutronPositions[i] = neutronPositions[index];
                    NcheckInNucleus[index] = false;
                    NcheckInNucleus[i] = true;
                    return;
                }
            }
            NcheckInNucleus[index] = false;
        }
    }

    private void updateInfo() // back e chole gele ekta error dey
    {
        if (currentP > 0)
        {
            Symbol.text = symbolName[currentP - 1];
        }
        else
        {
            Symbol.text = "-";
        }

        if (currentElementNum > 0)
        {
            if (currentP>0 && (currentP + currentN) == massofElements[currentP - 1] && currentN == neutronOfElements[currentP - 1])
            {
                GameObject.Find("p&n").GetComponent<Shake>().enabled = false;
                stable.text = "Stable\nNucleus";
                stable.color = new Color(0.06f, 0.34f, 0.06f);
                stableLine.text = "Stable nucleus have roughly equal numbers of proton and neutrons";
            }
            else
            {
                GameObject.Find("p&n").GetComponent<Shake>().enabled = true;
                stable.text = "Unstable\nNucleus";
                stable.color = Color.red;
                stableLine.text = "Add or remove proton neutrons to make the nucleus stable";
            }
        }
        else 
        {
            stable.text = " ";
            extraLine.text = " ";
            stableLine.text = " ";
        }
        mass.text = (currentP + currentN).ToString();
        pNumber.text = (currentP).ToString();
        nNumber.text = (currentN).ToString();
        eNumber.text = (currentE).ToString();

        charge.text = (currentP - currentE).ToString();
        if ((currentP - currentE) > 0)
        {
            ion.text = "+ION";
            charge.text = "+" + charge.text;
        }
        else if(((currentP - currentE) == 0) && currentP>0 )
        {
            ion.text = "Neutral";
        }
        else if(currentP>0)
        {
            ion.text = "-ION";
        }
        else
        {
            ion.text = " ";
        }

    }

    void addExtraLine(string update)
    {
        switch (update)
        {
            case "new np":
                if(currentP==0)
                {
                    extraLine.text = "Add a proton";
                }
                else if(currentN!= neutronOfElements[currentP - 1])
                {
                    extraLine.text = "It is an Isotope of " + symbolName[currentP - 1];
                }
                else
                {
                    extraLine.text = "You made a " + symbolName[currentP - 1];
                }
                break;
            case "new proton":
                if ((currentP + currentN) == massofElements[currentP - 1] && currentN == neutronOfElements[currentP - 1])
                {
                   extraLine.text =  "You made a " + symbolName[currentP - 1]; 
                }
                break;
            case "remove electron":
                if (currentE < currentP)
                {
                    extraLine.text = "The energy you used here is called Ionization Energy";
                }
                else if (currentE == currentP)
                {
                    if (currentP > 0)
                        extraLine.text = "You made a " + symbolName[currentP - 1];
                    else
                        extraLine.text = "No electron left";
                }
                else
                {
                    extraLine.text = "Keep same number of electrons as protons";
                }
                break;
            case "add electron":
                if (currentE > currentP)
                {
                    extraLine.text = "The energy you used here is called Electron Affinity";
                }
                else if (currentE == currentP)
                {
                    extraLine.text = "You made a " + symbolName[currentP - 1];
                }
                else
                {
                    extraLine.text = "Add same number of electrons as protons";
                }
                break;
            case "stay electron":
                extraLine.text = "You can only remove electron from outer orbit";
                break;

        }
    }
}
