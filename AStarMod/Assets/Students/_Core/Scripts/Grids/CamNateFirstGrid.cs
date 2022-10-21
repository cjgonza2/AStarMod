using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamNateFirstGrid : GridScript
{
	//Level Loader String
	string[] gridString = new string[]{
		"wwwwwwwwwwwww",
		"w|----|----|w",
		"w|----|----|w",
		"w|----|----|w",
		"w|----|----|w",
		"w|----|----|w",
		"w|----|----|w",
		"w|----|----|w",
		"w|----|----|w",
		"wwwwwwwwwwwww",
	};

	// Use this for initialization
	void Start () {
		gridWidth = gridString[0].Length;
		gridHeight = gridString.Length;
		aStar = GameObject.Find("Princess").GetComponent<AStarScript>();
		followAStarScript = GameObject.Find("Princess").GetComponent<FollowAStarScript>();
		//aStar.current = start;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override float GetMovementCost(GameObject go){
		return base.GetMovementCost(go);
	}
	
	protected override Material GetMaterial(int x, int y){

		char c = gridString[y].ToCharArray()[x];

		Material mat;

		switch(c){
		case 'd': 
			mat = mats[1];
			break;
		case 'w': 
			mat = mats[2];
			break;
		case 'r': 
			mat = mats[3];
			break;
		default: 
			mat = mats[0];
			break;
		}
	
		return mat;
	}
}

