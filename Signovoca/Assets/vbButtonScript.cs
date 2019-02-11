using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
using UnityEngine.SceneManagement;

public class vbButtonScript : MonoBehaviour, IVirtualButtonEventHandler {

	int RightAnswer;

	public Text txtScoreCount;

	public GameObject shitHead;

	public GameObject CorrectWrong;
	public Transform[] CorWro;

	public static int ScoreCount = 0;

	Transform TransCorWro;

	private GameObject vbButtonsObject1;
	private GameObject vbButtonsObject2;
	private GameObject vbButtonsObject3;

	// Use this for initialization
	void Start () {
		shitHead = GameObject.Find ("Directional Light");

		vbButtonsObject1 = GameObject.Find ("cmdAnswer1");
		vbButtonsObject2 = GameObject.Find ("cmdAnswer2");
		vbButtonsObject3 = GameObject.Find ("cmdAnswer3");
		vbButtonsObject1.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		vbButtonsObject2.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		vbButtonsObject3.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);

		scoreCounter ();
	}
	
	// Update is called once per frame
	void Update () {
		TestFunction ();
	}

	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb){
		if ((vb.name == vbButtonsObject1.name) && (RightAnswer == 2)) {
			Debug.Log (vb.name + "RON" + RightAnswer);
			GameScoreCounting ();
		} else if ((vb.name == vbButtonsObject2.name) && (RightAnswer == 0)) {
			Debug.Log (vb.name + "MICA" + RightAnswer);
			GameScoreCounting ();
		} else if ((vb.name == vbButtonsObject3.name) && (RightAnswer == 1)) {
			Debug.Log (vb.name + "ANJ" + RightAnswer);
			GameScoreCounting ();
		} else {
			Debug.Log ("Wrong answer");
		}
	
	}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb){



	}

	void GameScoreCounting(){
		ScoreCount += 1;
		scoreCounter ();
		reload ();
	}

	void TestFunction()
	{
		RightAnswer = gameLogics.GameAnswer;
	}


	void scoreCounter(){
		txtScoreCount.text = "Score: "+ ScoreCount.ToString();
	}

	void reload(){
		SceneManager.LoadScene ("GameScene");
		DontDestroyOnLoad (shitHead);
	}

}
