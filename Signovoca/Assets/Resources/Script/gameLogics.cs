using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gameLogics : MonoBehaviour {

	int[] RandomNumber;


	public GameObject[] planePlaces;
	//Transform
	public Transform[] modelPrefabs;
	Transform X;
	Transform Z;
	public static int GameAnswer = 0;
	int AnswerNumber;

	public Transform[] imgTarget;
	
	public GameObject imgPlanePlace;

	List<int> usedValues = new List<int>();
	List<int> usedValues2 = new List<int>();
	
 	void UniqueRandomInt()
	{
		for(int i = 0; i < 3; i++){
			int val = Random.Range(0, 5);
			while(usedValues.Contains(val))
			{
				val = Random.Range(0, 5);
			}
			usedValues.Add(val);
		}
	}

	void UniqueRandomIntCount()
	{
		for(int i = 0; i < 3; i++){
			int val = Random.Range(0, 3);
			while(usedValues2.Contains(val))
			{
				val = Random.Range(0, 3);
			}
			usedValues2.Add(val);
		}
	}
	
	void ImageShows() {


	}

	void Models() {
		for(int i = 0; i < 3; i++) {
			if (i == 0) {
				//For the Image Target
				AnswerNumber = usedValues [i];
				Z = Instantiate (imgTarget[usedValues[i]], imgPlanePlace.transform.position, imgPlanePlace.transform.rotation) as Transform;
				Z.transform.parent = GameObject.Find ("ImageTarget").transform;
				Z.name = "x" + i;
				Vector3 pos1 = Z.transform.position;    
				Z.transform.position = new Vector3 (pos1.x, pos1.y + 5f, pos1.z);
				Z.transform.rotation = Quaternion.Euler (0, 180, 0);


			}
			//for the Model Prefabs
			X = Instantiate (modelPrefabs [usedValues[i]], planePlaces [usedValues2[i]].transform.position, planePlaces [i].transform.rotation) as Transform;
			X.transform.parent = GameObject.Find ("ImageTarget").transform;
			X.name = "x" + i;
			Vector3 pos = X.transform.position;    
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
			X.transform.position = new Vector3 (pos.x, pos.y + 5f, pos.z + 10f);
=======
			X.transform.position = new Vector3 (pos.x, pos.y, pos.z);
>>>>>>> parent of 50b2d73a... Game(Done so far)
=======
			X.transform.position = new Vector3 (pos.x, pos.y + 5f, pos.z + 10f);
>>>>>>> parent of 4453e779... Medyo may error
			X.transform.rotation = Quaternion.Euler (0, 180, 0);
=======
			X.transform.position = new Vector3 (pos.x, pos.y + 5f, pos.z + 10f);
			X.transform.rotation = Quaternion.Euler (0, 180, 0);
			X.transform.localScale = new Vector3 (0.4f, 0.4f, 0.4f);
>>>>>>> parent of 4453e779... Medyo may error
			if (AnswerNumber == usedValues [i]) {
				GameAnswer = usedValues2 [i];
			}
		}
			
	}

	// Use this for initialization
	void Start () {
		ReloadGameLogics ();


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ReloadGameLogics(){
		UniqueRandomIntCount();
		UniqueRandomInt();
		Models();
	}
}
