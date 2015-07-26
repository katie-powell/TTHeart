
using UnityEngine;
using System.Collections;

public class HeartContainerScript : MonoBehaviour {
   
    bool isHeart = false;
    int phase = 0;
	GameObject inspector;
	AudioSource myAudio;
   
    // Use this for initialization
    void Start ()
    {
		inspector = GameObject.Find ("Inspector");

		myAudio = gameObject.GetComponent<AudioSource> ();
		myAudio.bypassEffects = true;
		myAudio.loop = true;
		myAudio.priority = 185;
		myAudio.volume = 1;
		myAudio.pitch = 1;
		myAudio.spatialBlend = 1;
		myAudio.reverbZoneMix = 1;
		myAudio.dopplerLevel = 1;
		myAudio.rolloffMode = AudioRolloffMode.Logarithmic;
		myAudio.minDistance = 1;
		myAudio.maxDistance = 500;
		myAudio.spread = 175;


    }
   
    // Update is called once per frame
    void Update ()
    {

       
    }
   
    public void setAsHeart()
    {
        isHeart = true;
        //Debug.Log("heart is in " + this.name);
    }
   
    public void setPhase(int n)
    {
        phase = n;
        if(isHeart)
        {
            if(phase == 2)
            {
                GetComponent<AudioSource>().Play();
                //start heart beating, on loop
            }
            if(phase == 4)
            {
                GetComponent<AudioSource>().Stop();
				inspector.GetComponent<MouseLook>().freeCursor();
				Application.LoadLevel("Win");
                //stop heart beating
            }
        }
    }
   
    void OnMouseUp()
    {
        
        if(isHeart)
        {
            setPhase(4);
            Debug.Log("Found it");
           
            //change phase of game to 4
            //wingame
        }
        else
        {
            inspector.GetComponent<InspectorVoice>().speak();
			//tell player to stop moving for a sec
        }
    }
   
}