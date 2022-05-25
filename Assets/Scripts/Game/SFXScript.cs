using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXScript : MonoBehaviour
{
    //declares audio clips by name (clip file must be exactly named and a proper file type, such as .wav)
    //declares audiosource (must be attached to object with audiosource)
    
	public static AudioClip example;
	static AudioSource audioSrc;

	//on Awake loads audio clip by name from the Resources folder (is there a better method?)
	//gets Audio Source from this.gameObject
	//starts function Pump It plays a song... (improve later)
	void Awake()
	{
		example = Resources.Load<AudioClip>("example");

		audioSrc = this.GetComponent<AudioSource>();

		//PumpIt();
	}

	//public static function PlaySound
	//this public function can be accessed globally from any script
	//accepts input string to play clip
	//SFXScript.PlaySound("example");
	//string is usually exactly the same as clip name for simplicity's sake
	public static void PlaySound(string clip)
	{
		switch (clip)
		{
			case "axe_hit":
				audioSrc.PlayOneShot(example);
				break;
			
		}
	}

	//Pump It
	//pump the music
	//private void PumpIt()
	//{
	//	if (tribal_drums)
	//		PlaySound("tribal_drums");
	//}




}
