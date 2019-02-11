using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
using UnityEngine.SceneManagement;

public class vbButtonScript : MonoBehaviour, IVirtualButtonEventHandler {

	int RightAnswer;
	int finishedCount;
	//startSound
	public AudioClip winSound;
	public AudioClip loseSound;
	private AudioSource winAudioSrc { get {return GetComponent<AudioSource> ();}}
	private AudioSource loseAudioSrc { get {return GetComponent<AudioSource> ();}}
	//endSound
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

		gameObject.AddComponent<AudioSource> ();
		winAudioSrc.clip = winSound;
		winAudioSrc.playOnAwake = false;
		loseAudioSrc.clip = winSound;
		loseAudioSrc.playOnAwake = false;

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
			GameWrongAnswer ();
		}
	
	}

	void playWinSound(){
		winAudioSrc.PlayOneShot (winSound);
	}

	void playLoseSound(){
		loseAudioSrc.PlayOneShot (loseSound);
	}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb){


			
	}

	void GameWrongAnswer(){
		disableVB ();
		playLoseSound ();
		StartCoroutine (waitLoseAudio ());
	}

	void GameScoreCounting(){
		disableVB ();
		playWinSound ();
		ScoreCount += 1;
		scoreCounter ();
		StartCoroutine (waitWinAudio ());
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

	private IEnumerator waitWinAudio ()
	{
		yield return new WaitForSeconds (winAudioSrc.clip.length);
		reload ();
	}

	private IEnumerator waitLoseAudio ()
	{
		yield return new WaitForSeconds (loseAudioSrc.clip.length);
		reload ();
	}

	private void disableVB(){
		vbButtonsObject1.GetComponent<VirtualButtonBehaviour>().enabled = false;
		vbButtonsObject2.GetComponent<VirtualButtonBehaviour>().enabled = false;
		vbButtonsObject3.GetComponent<VirtualButtonBehaviour>().enabled = false;

	}
}
