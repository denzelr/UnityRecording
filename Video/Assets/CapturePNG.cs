using UnityEngine;
using System.Collections;

public class CapturePNG : MonoBehaviour {

	public bool record = false;
	int counter = 0;

	void FixedUpdate(){
		if (record == true) {
			InvokeRepeating ("Screenshot", 1, 0.04F);
		}
	}

	void Screenshot() {
		counter++;
		Application.CaptureScreenshot ("Output/" + counter + ".png");
	}

	public void invoke(){
		if (record == false) {
			record = true;
		} else {
			record = false;
		}
	}
}
