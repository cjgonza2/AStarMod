using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//assign to every quad when set up tiles
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
    
    //when player clicks on the quad mesh collider
    private void OnMouseDown()
    {
        //set goal to the quad clicked
        gridScript.goal = selectedMat;
        //find the path
        aStar.InitAstar();
        //move the princess
        followAStarScript.StartMove();
    }
}
