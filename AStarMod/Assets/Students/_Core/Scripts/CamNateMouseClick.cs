using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamNateMouseClick : MonoBehaviour
{
    public GridScript gridScript;
    public AStarScript aStar;
    public FollowAStarScript followAStarScript;
    
    public Vector3 selectedMat;

    private void Start()
    {
        //assings grid and a star script by finding the grid and princess object.
        gridScript = GameObject.Find("Grid").GetComponent<CamNateFirstGrid>();
        aStar = GameObject.Find("Princess").GetComponent<AStarScript>();
        followAStarScript = GameObject.Find("Princess").GetComponent<FollowAStarScript>();
    }

    private void OnMouseDown()
    {
        Debug.Log(selectedMat);
        gridScript.goal = selectedMat;
        if (followAStarScript.path == null)
        {
            
        }
        else
        {
            gridScript.start = followAStarScript.path.Get(followAStarScript.currentStep).gridPos;
        }

        aStar.InitAstar();
        followAStarScript.WaitToMove();
    }
}
