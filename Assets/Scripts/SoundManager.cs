using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public AudioClip soundNoHP, soundBtnClick, soundBeep, soundGoal;
	AudioSource myAudio;
	public static SoundManager instance;
	void Awake()
	{
		if (SoundManager.instance == null)
			SoundManager.instance = this;
	}
	void Start()
	{
		myAudio = GetComponent<AudioSource>();
	}
	public void BtnClickSound()
	{
		myAudio.PlayOneShot(soundBtnClick);
	}
	public void BeepSound()
	{
		myAudio.PlayOneShot(soundBeep);
	}
	public void GoalSound()
	{
		myAudio.PlayOneShot(soundGoal);
	}
}
