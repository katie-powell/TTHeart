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
				GetComponent<AudioSource>().clip = soundBytes[0];
				GetComponent<AudioSource>().Play();
			}
			else
			{
				randomNumber = (int)Random.Range(1, soundBytes.Length);
				GetComponent<AudioSource>().clip = soundBytes[randomNumber];
				GetComponent<AudioSource>().Play ();
			}
		}
	}
}
