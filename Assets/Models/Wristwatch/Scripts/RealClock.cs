//This script uses the system time to position the hands of a clock. You may assign as many or few hands as you wish, but I recommend you use all 3!
//And of course you can use your own watch model, should work with any as long as the hands are
//all at 12:00 when their rotation is zeroed and their local Z axis is perpendicular to the clock face

using UnityEngine;
using System.Collections;
using System;
using TMPro;

public class RealClock : MonoBehaviour {
	public Transform Hours;
	public Transform Minutes;
	public Transform Seconds;
	public TextMeshPro digital;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float hour = System.DateTime.Now.Hour;
		float minute = System.DateTime.Now.Minute;
		float second = System.DateTime.Now.Second;
		float millisecond = System.DateTime.Now.Millisecond;

		digital.text = string.Format("{0:00}:{1:00}", hour, minute);

		//we want these hands to move smoothly, not jump every time the hour/minute changes. 
		hour = hour + minute / 60f;
		minute = minute + second / 60f;

		//The second hand is fine jumping, but if you want a smooth rotation on that just uncomment this code:  
		//second = second + millisecond / 1000f;


		if(Hours)
			Hours.localRotation = Quaternion.Euler (0, 0, hour / 12 * 360);

		if(Minutes)
			Minutes.localRotation = Quaternion.Euler (0, 0, minute / 60 * 360);

		if(Seconds)
			Seconds.localRotation = Quaternion.Euler (0, 0, second / 60 * 360);


	}
}
