using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamNateMouseClick : MonoBehaviour
{
    public GridScript gridScript;
    public AStarScript aStar;
    
    public Vector3 selectedMat;

    private void Start()
    {
        //assings grid and a star script by finding the grid and princess object.
        gridScript = GameObject.Find("Grid").GetComponent<CamNateFirstGrid>();
        aStar = GameObject.Find("Princess").GetComponent<AStarScript>();
    }

    private void OnMouseDown()
    {
        Debug.Log(selectedMat);
        gridScript.goal = selectedMat;
        Debug.Log(gridScript.goal);
        aStar.InitAstar();
    }
}
