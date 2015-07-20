using UnityEngine;
using System.Collections;

public class InspectorVoice : MonoBehaviour {
	
	int voicetimer;
	public AudioClip[] soundBytes;
	
	// Use this for initialization
	void Start () {
		voicetimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(voicetimer >0)
		{
			voicetimer--;
		}
	}
	
	public void speak()
	{
		if(voicetimer <= 0)
		{
			voicetimer = 100;
			int randomNumber = (int)Random.Range(0, 100);
			if(randomNumber <5)
			{
				audio.clip = soundBytes[0];
				audio.Play();
			}
			else
			{
				randomNumber = (int)Random.Range(1, soundBytes.Length);
				audio.clip = soundBytes[randomNumber];
				audio.Play ();
			}
		}
	}
}
