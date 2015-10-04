using UnityEngine;
using System.Collections;

public class ReplayButton : MonoBehaviour {
	
	AudioSource myAudio;

	// Use this for initialization
	void Start () {
		myAudio = GameObject.Find("Audio").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2") || Input.GetButtonDown("Fire3") || Input.GetButtonDown("Jump"))
			OnMouseDown();
	}
	
	void OnMouseDown()
	{
		myAudio.Stop();
		Application.LoadLevel("Opening");
	}
}
