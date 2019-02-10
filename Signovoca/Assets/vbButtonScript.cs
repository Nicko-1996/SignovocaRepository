using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class vbButtonScript : MonoBehaviour, IVirtualButtonEventHandler {

	private int RightAnswer;

	private GameObject vbButtonsObject1;
	private GameObject vbButtonsObject2;
	private GameObject vbButtonsObject3;
	private gameLogics gLogics;
	// Use this for initialization
	void Start () {

		vbButtonsObject1 = GameObject.Find ("cmdAnswer1");
		vbButtonsObject2 = GameObject.Find ("cmdAnswer2");
		vbButtonsObject3 = GameObject.Find ("cmdAnswer3");
		vbButtonsObject1.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		vbButtonsObject2.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		vbButtonsObject3.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		gLogics = GetComponent<gameLogics> ();
		RightAnswer = gLogics.GameAnswer;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb){
		if ((vb.name == vbButtonsObject1.name) && (RightAnswer == 1)) {
			Debug.Log (vb.name + "RON");
		} else if ((vb.name == vbButtonsObject2.name) && (RightAnswer == 2)) {
			Debug.Log (vb.name + "MICA");
		} else if ((vb.name == vbButtonsObject3.name) && (RightAnswer == 3)) {
			Debug.Log (vb.name + "ANJ");
		}
	
	}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb){



	}
}
