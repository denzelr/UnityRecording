using UnityEngine;
using System.Collections;

public class CapturePNG : MonoBehaviour {

	int counter = 0;

	void Screenshot() {
		Application.CaptureScreenshot ("Output/" + counter + ".png");
		counter++;
	}

	public void invoke(){
		InvokeRepeating ("Screenshot", 2, 0.04F);
	}
}
