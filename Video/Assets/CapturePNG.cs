using UnityEngine;
using System.Collections;

public class CapturePNG : MonoBehaviour {

	public bool record = false;
	int counter = 0;

	void FixedUpdate(){

	}

	void Screenshot() {
		counter++;
		Application.CaptureScreenshot ("Output/" + counter + ".png");
		Debug.Log ("PNG Created " + counter);
	}

	public void invoke(){
		/*if (record == false) {
			record = true;
		} else {
			record = false;
		}*/
		//if (record == true) {
		InvokeRepeating ("Screenshot", 0, 0.04F);
		//}
	}
}
