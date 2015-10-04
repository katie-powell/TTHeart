
using UnityEngine;
using System.Collections;

public class HeartContainerScript : MonoBehaviour {
   

	float inspectDistance = 4;	//edit later to make public

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
		if(Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2") || Input.GetButtonDown("Fire3") || Input.GetButtonDown("Jump"))
			OnMouseDown();
       
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
   
    void OnMouseDown()
    {
		float distanceToObject = Vector3.Distance (inspector.transform.position, gameObject.transform.position);
		Debug.Log (Vector3.Distance(inspector.transform.position, gameObject.transform.position));
		Debug.Log (this.name);

		if(isHeart && distanceToObject<inspectDistance)
        {
            setPhase(4);
            Debug.Log("Found it");
           
            //change phase of game to 4
            //wingame
        }
		else if (distanceToObject<inspectDistance)
        {
            inspector.GetComponent<InspectorVoice>().speak();
			//tell player to stop moving for a sec
        }
    }
   
}