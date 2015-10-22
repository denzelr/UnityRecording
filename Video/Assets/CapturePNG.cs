using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class CapturePNG : MonoBehaviour {

	private bool record = false;
	private int counter = 0;
	private readonly string outPath = "Output/";

	void Start(){
		if (!Directory.Exists (outPath)) {
			Directory.CreateDirectory(outPath);
		}
	}

	void Screenshot() {
		counter++;
		Application.CaptureScreenshot (outPath + counter + ".png");
		Debug.Log ("PNG Created " + counter);
	}

	public void invoke(){
		record = !record;
		if (record == true) {
			InvokeRepeating ("Screenshot", 0, 0.04F);
		} else {
			Debug.Log ("stopping");
			CancelInvoke ("Screenshot");
		}
	}
}
