/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;

namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class DefaultTrackableEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
    {

		public Transform gameChar;
		public Animation gameAnim;
		public GameObject gamePlane;

        //------------Begin Sound----------
        public AudioSource soundTarget;
        public AudioClip clipTarget;
        private AudioSource[] allAudioSources;

        //function to stop all sounds
        void StopAllAudio()
        {
            allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
            foreach (AudioSource audioS in allAudioSources)
            {
                audioS.Stop();
            }
        }

        //function to play sound
        void playSound(string ss)
        {
            clipTarget = (AudioClip)Resources.Load(ss);
            soundTarget.clip = clipTarget;
            soundTarget.loop = false;
            soundTarget.playOnAwake = false;
            soundTarget.Play();
        }

        //-----------End Sound------------


        #region PRIVATE_MEMBER_VARIABLES

        private TrackableBehaviour mTrackableBehaviour;
    
        #endregion // PRIVATE_MEMBER_VARIABLES



        #region UNTIY_MONOBEHAVIOUR_METHODS
    
        void Start()
        {
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }

            soundTarget = (AudioSource)gameObject.AddComponent<AudioSource>();
        }

        #endregion // UNTIY_MONOBEHAVIOUR_METHODS



        #region PUBLIC_METHODS

        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>
        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();
            }
            else
            {
                OnTrackingLost();
            }
        }

        #endregion // PUBLIC_METHODS



        #region PRIVATE_METHODS


        private void OnTrackingFound()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Enable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = true;
            }

            // Enable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = true;
            }

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");

			//Play Sound, IF detect an target

			//numbers
			if (mTrackableBehaviour.TrackableName == "Number0")
			{
				playSound("sounds/number0");
			}

			if (mTrackableBehaviour.TrackableName == "Number1")
			{
				playSound("sounds/number1");
			}

			if (mTrackableBehaviour.TrackableName == "Number2")
			{
				playSound("sounds/number2");
			}

			if (mTrackableBehaviour.TrackableName == "Number3")
			{
				playSound("sounds/number3");
			}

			if (mTrackableBehaviour.TrackableName == "Number4")
			{
				playSound("sounds/number4");
			}

			if (mTrackableBehaviour.TrackableName == "Number5")
			{
				playSound("sounds/number5");
			}

			if (mTrackableBehaviour.TrackableName == "Number6")
			{
				playSound("sounds/number6");
			}

			if (mTrackableBehaviour.TrackableName == "Number7")
			{
				playSound("sounds/number7");
			}

			if (mTrackableBehaviour.TrackableName == "Number8")
			{
				playSound("sounds/number8");
			}

			if (mTrackableBehaviour.TrackableName == "Number9")
			{
				playSound("sounds/number9");
			}


			//letters
			if (mTrackableBehaviour.TrackableName == "letter_A")
			{
				playSound("sounds/letterA");

			}

			if (mTrackableBehaviour.TrackableName == "letter_B")
			{
				playSound("sounds/letterB");
			}

			if (mTrackableBehaviour.TrackableName == "letter_C")
			{
				playSound("sounds/letterC");
			}

			if (mTrackableBehaviour.TrackableName == "letter_D")
			{
				playSound("sounds/letterD");
			}

			if (mTrackableBehaviour.TrackableName == "letter_E")
			{
				playSound("sounds/letterE");
			}

			if (mTrackableBehaviour.TrackableName == "letter_F")
			{
				playSound("sounds/letterF");
			}

			if (mTrackableBehaviour.TrackableName == "letter_G")
			{
				playSound("sounds/letterG");
			}

			if (mTrackableBehaviour.TrackableName == "letter_H")
			{
				playSound("sounds/letterH");
			}

			if (mTrackableBehaviour.TrackableName == "letter_I")
			{
				playSound("sounds/letterI");
			}

			if (mTrackableBehaviour.TrackableName == "letter_J")
			{
				playSound("sounds/letterJ");
			}

			if (mTrackableBehaviour.TrackableName == "letter_K")
			{
				playSound("sounds/letterK");
			}

			if (mTrackableBehaviour.TrackableName == "letter_L")
			{
				playSound("sounds/letterL");
			}

			if (mTrackableBehaviour.TrackableName == "letter_M")
			{
				playSound("sounds/letterM");
			}

			if (mTrackableBehaviour.TrackableName == "letter_N")
			{
				playSound("sounds/letterN");
			}

			if (mTrackableBehaviour.TrackableName == "letter_O")
			{
				playSound("sounds/letterO");
			}

			if (mTrackableBehaviour.TrackableName == "letter_P")
			{
				playSound("sounds/letterP");
			}

			if (mTrackableBehaviour.TrackableName == "letter_Q")
			{
				playSound("sounds/letterQ");
			}

			if (mTrackableBehaviour.TrackableName == "letter_R")
			{
				playSound("sounds/letterR");
			}

			if (mTrackableBehaviour.TrackableName == "letter_S")
			{
				playSound("sounds/letterS");
			}

			if (mTrackableBehaviour.TrackableName == "letter_T")
			{
				playSound("sounds/letterT");
			}

			if (mTrackableBehaviour.TrackableName == "letter_U")
			{
				playSound("sounds/letterU");
			}

			if (mTrackableBehaviour.TrackableName == "letter_V")
			{
				playSound("sounds/letterV");
			}

			if (mTrackableBehaviour.TrackableName == "letter_W")
			{
				playSound("sounds/letterW");
			}

			if (mTrackableBehaviour.TrackableName == "letter_X")
			{
				playSound("sounds/letterX");
			}

			if (mTrackableBehaviour.TrackableName == "letter_Y")
			{
				playSound("sounds/letterY");
			}

			if (mTrackableBehaviour.TrackableName == "letter_Z")
			{
				playSound("sounds/letterZ");
			}
		
        }


        private void OnTrackingLost()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Disable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = false;
            }

            // Disable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = false;
            }

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
        }

        #endregion // PRIVATE_METHODS
    }
}
