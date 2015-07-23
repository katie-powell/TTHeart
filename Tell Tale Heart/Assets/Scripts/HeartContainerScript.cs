
using UnityEngine;
using System.Collections;

public class HeartContainerScript : MonoBehaviour {
   
    bool isHeart = false;
    int phase = 0;
	GameObject inspector;
   
    // Use this for initialization
    void Start ()
    {
   		inspector = GameObject.Find ("Inspector");
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