using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class vbButtonScript : MonoBehaviour, IVirtualButtonEventHandler {

	private GameObject vbButtonsObject;

	// Use this for initialization
	void Start () {

		vbButtonsObject = GameObject.Find ("cmdAnswer1");
		vbButtonsObject.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb){
	
		Debug.Log ("BUTTON DOWN!!!");
	
	}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb){



	}
}
