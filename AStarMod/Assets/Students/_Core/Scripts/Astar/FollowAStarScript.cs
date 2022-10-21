using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowAStarScript : MonoBehaviour {

	protected bool move = false;

	public Path path;
	public AStarScript astar;
	public Step startPos;
	public Step destPos;

	public int currentStep = 1;

	protected float lerpPer = 0;
	
	protected float startTime;
	protected float travelStartTime;

	// Use this for initialization
	protected virtual void Start () {
		
		startTime = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	protected virtual void Update () {

		if(move){
			lerpPer += Time.deltaTime/destPos.moveCost;

			transform.position = Vector3.Lerp(startPos.gameObject.transform.position, 
			                                  destPos.gameObject.transform.position, 
			                                  lerpPer);

			if(lerpPer >= 1){
				lerpPer = 0;

				currentStep++;
				Debug.Log("Next Step: " + currentStep);

				if(currentStep >= path.steps){
					currentStep = 0;
					move = false;
					Debug.Log(path.pathName + " got to the goal in: " + (Time.realtimeSinceStartup - startTime));
					Debug.Log(path.pathName + " travel time: " + (Time.realtimeSinceStartup - travelStartTime));
				} 

				startPos = destPos;
				destPos = path.Get(currentStep);
			}
		}
	}
	
	//Move the princess to the goal
	public virtual void StartMove(){
		//Init variables
		path = astar.path;
		currentStep = 1;
		startPos = path.Get(0);
		destPos  = path.Get(currentStep);
		move = true;
		travelStartTime = Time.realtimeSinceStartup;
	}
}

