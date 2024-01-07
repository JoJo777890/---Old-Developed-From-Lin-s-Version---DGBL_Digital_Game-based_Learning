using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalPresenter : MonoBehaviour
{
    public GameObject catModel;
    public GameObject catModelShadow;
    public GameObject antModel;
    public GameObject antModelShadow;

    public Scan scan;

    private string wordCat = "cat";
    private string wordAnt = "ant";

    void Start()
    {
        Scan.onFullScan += CheckCatSameLetters;
        Scan.onFullScan += CheckAntSameLetters;

        catModelShadow.SetActive(false);
        catModel.SetActive(false);
        antModelShadow.SetActive(false);
        antModel.SetActive(false);
    }

    void CheckCatSameLetters()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                // Make this an another function
                if (scan.displayText[i] == wordCat[j])
                {
                    catModelShadow.SetActive(true);
                }
            }
        }

        if (string.Equals(scan.displayText, wordCat) == true)
        {
            catModelShadow.SetActive(false);
            catModel.SetActive(true);
        }
    }

    void CheckAntSameLetters()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (scan.displayText[i] == wordAnt[j])
                {
                    antModelShadow.SetActive(true);
                }
            }
        }

        if (string.Equals(scan.displayText, wordAnt) == true)
        {
            antModelShadow.SetActive(false);
            antModel.SetActive(true);
        }
    }
}
