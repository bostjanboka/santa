﻿using UnityEngine;
using System.Collections;

public class hiseGenerator : MonoBehaviour {

    // Use this for initialization
    public GameObject[] Hise;
    GameObject[] seznamHis;
    int stevec = 0;
    Vector3 zacetnaPos;
    public float speed = 0;
    public static float speedP = 0;
    RectTransform parentC;

    float posTime = 0;

    int idHis = 0;
    public static bool dodajHis = false;
    Transform trZadnja;
    int iDzadnja = 0;
   

	void Start () {
        parentC = transform.parent.GetComponent<RectTransform>();
        
        
        seznamHis = new GameObject[100];
        
        for (int i=0; i < seznamHis.Length; i++)
        {
            seznamHis[i] = Instantiate(Hise[Random.Range(0, Hise.Length)], new Vector3(70000, 40000 + Random.value * 2000), Quaternion.Euler(0, 0, 0)) as GameObject;
            seznamHis[i].transform.SetParent(transform,false);
            seznamHis[i].GetComponent<RectTransform>().position = new Vector3(20000, 20000, 1);

        }
        zacetnaPos = transform.position;
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.right * -speed * speedP* Time.deltaTime;
        if (dodajHis)
        {
            
            dodajHiso(trZadnja);
            dodajHis = false;
        }
	}

    public void dodajHiso(Transform t)
    {
        if(santaSkripta.igranje)
        {
            GameObject zac = seznamHis[stevec % seznamHis.Length];
            Vector3 pos = t.GetComponent<RectTransform>().localPosition;
            pos.x += (t.GetComponent<RectTransform>().sizeDelta.x / 2 + zac.GetComponent<RectTransform>().sizeDelta.x / 2);
            t.GetComponent<RectTransform>();
            zac.GetComponent<RectTransform>().localPosition = pos;
            zac.SetActive(true);
            zac.GetComponent<hisaSkripta>().IdHisa = iDzadnja;
            stevec++;
            
            Debug.Log(posTime + "time");
            //zac.GetComponent<Collider2D>().enabled = true;
            trZadnja = zac.transform;
            posTime = Time.time;
        }

        
    }

    public void dodajPrvoHiso()
    {

        speedP = 1;
        idHis++;
        
        
        GameObject zac = seznamHis[stevec % seznamHis.Length];
        zac.SetActive(true);
            
        RectTransform rt = zac.GetComponent<RectTransform>();
        Vector3 pos = new Vector3(parentC.sizeDelta.x / 2 + rt.sizeDelta.x / 2, -parentC.sizeDelta.y / 2 + rt.sizeDelta.y / 2);
        pos.x += (parentC.localPosition - transform.localPosition).x;
        rt.localPosition = pos;
            
        zac.GetComponent<hisaSkripta>().IdHisa = idHis;
        //zac.GetComponent<Collider2D>().enabled = true;
        trZadnja = zac.transform;
        posTime = Time.time;
        
        
        iDzadnja = idHis;
        stevec++;
        

    }
}
