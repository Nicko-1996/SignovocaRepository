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

	public AudioClip rightSound;
	private AudioSource rightAudioSrc{get{return GetComponent<AudioSource> (); }}
	public AudioClip wrongSound;
	private AudioSource wrongAudioSrc{get{return GetComponent<AudioSource> (); }}

	public static int ScoreCount = 0;

	Transform TransCorWro;

	private GameObject vbButtonsObject1;
	private GameObject vbButtonsObject2;
	private GameObject vbButtonsObject3;

	// Use this for initialization
	void Start () {

		vbButtonsObject1 = GameObject.Find ("cmdAnswer1");
		vbButtonsObject2 = GameObject.Find ("cmdAnswer");
		vbButtonsObject3 = GameObject.Find ("cmdAnswer3");
		vbButtonsObject1.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		vbButtonsObject2.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		vbButtonsObject3.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);

		gameObject.AddComponent<AudioSource> ();
		rightAudioSrc.clip = rightSound;
		rightAudioSrc.playOnAwake = false;
		wrongAudioSrc.clip = rightSound;
		wrongAudioSrc.playOnAwake = false;

		scoreCounter ();
	}
	
	// Update is called once per frame
	void Update () {
		TestFunction ();
	}

	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb){
		if ((vb.name == vbButtonsObject1.name) && (RightAnswer == 2)) {
			rightAnwer ();
		} else if ((vb.name == vbButtonsObject2.name) && (RightAnswer == 0)) {
			rightAnwer ();
		} else if ((vb.name == vbButtonsObject3.name) && (RightAnswer == 1)) {
			rightAnwer ();
		} else {
			wrongAnswer ();
		}
	
	}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb){



	}

	void rightAnwer(){
		disableButtons ();
		playRightSound ();
		ScoreCount += 1;
		scoreCounter ();
		StartCoroutine(soundRightDelay());
	}

	void wrongAnswer(){
		disableButtons ();
		playWrongSound ();
		StartCoroutine(soundWrongDelay());
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
		DontDestroyOnLoad (txtScoreCount);
	}

	void playRightSound(){
		rightAudioSrc.PlayOneShot (rightSound);
	}

	void playWrongSound(){
		wrongAudioSrc.PlayOneShot (wrongSound);
	}
	IEnumerator soundRightDelay(){
		yield return new WaitForSeconds(rightAudioSrc.clip.length);
		reload ();
	}
	IEnumerator soundWrongDelay(){
		yield return new WaitForSeconds(wrongAudioSrc.clip.length);
		reload ();
	}

	private void disableButtons(){
		vbButtonsObject1.GetComponent<VirtualButtonBehaviour>().enabled = false;
		vbButtonsObject2.GetComponent<VirtualButtonBehaviour>().enabled = false;
		vbButtonsObject3.GetComponent<VirtualButtonBehaviour>().enabled = false;
	}
}
