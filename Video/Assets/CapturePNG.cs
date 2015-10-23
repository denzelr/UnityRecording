using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Diagnostics;

public class CapturePNG : MonoBehaviour {

	private bool record = false;
	private int counter = 0;
	private readonly string outPath = "Output/";
	private int vidCount = 0;
	private readonly float frameRate = 24.0f;
	private float recordStep;

	void Start(){
		recordStep = 1 / frameRate;
		if (!Directory.Exists (outPath)) {
			Directory.CreateDirectory(outPath);
		}
	}

	IEnumerator Screenshot() {
		while (record) {
			counter++;
			Application.CaptureScreenshot (outPath + counter.ToString ("D8") + ".png");
			UnityEngine.Debug.Log ("PNG Created " + counter);
			yield return new WaitForSeconds(recordStep);
		}
		MakeAvi ();
		yield return null;
	}

	public void invoke(){
		record = !record;
		if (record) {
			StartCoroutine ("Screenshot");
		}
	}
	private void MakeAvi(){
		//this does not work yet
		UnityEngine.Debug.Log ("making avi");
		Process p = new Process();
		p.StartInfo.UseShellExecute = false;
		p.StartInfo.RedirectStandardOutput = true;
		p.StartInfo
		p.StartInfo.FileName = "ffmpeg -framerate 24 -i Output/%08d.png -pix_fmt yuv420p out.mp4";
		p.Start();
		p.WaitForExit ();
		System.Diagnostics.Process.Start ("rm Output/*");
	}
}
