using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Diagnostics;

public class CapturePNG : MonoBehaviour
{

    private bool record = false;
    private int counter = 0;
    private readonly string outPath = "Output/";
    private int vidCount = 0;
    private readonly float frameRate = 24.0f;
    private float recordStep;
    private int resWidth = 750;
    private int resHeight = 360;
    private Camera camera;
    void Start()
    {
        record = false;
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        recordStep = (1 / frameRate);
        if (!Directory.Exists(outPath))
        {
            Directory.CreateDirectory(outPath);
        }
    }

    IEnumerator Screenshot()
    {
        if (!Directory.Exists(outPath))
        {
            Directory.CreateDirectory(outPath);
        }
        while (record)
        {
            /*counter++;
            Application.CaptureScreenshot(outPath + counter.ToString("D8") + ".png", 0);
            UnityEngine.Debug.Log("PNG Created " + counter);
            yield return new WaitForSeconds(recordStep);*/
            counter++;
            RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
            camera.targetTexture = rt;
            Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
            camera.Render();
            RenderTexture.active = rt;
            screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
            camera.targetTexture = null;
            RenderTexture.active = null; // JC: added to avoid errors
            Destroy(rt);
            byte[] bytes = screenShot.EncodeToPNG();
            string filename = outPath + counter.ToString("D8") + ".png";//8 didget naming scheme limits us to videos roughly 28.9 days long
            System.IO.File.WriteAllBytes(filename, bytes);
            UnityEngine.Debug.Log(string.Format("Took screenshot to: {0}", filename));
            yield return new WaitForSeconds(recordStep);
            }
        yield break;
    }

    public void ToggleRecord()
    {
        record = !record;
        if (record)
        {
            StartCoroutine("Screenshot");
        }
        else
        {
            MakeAvi();
            Clean();
            counter = 0;
        }
    }
    private void MakeAvi()
    {
        string cmdTxt = "-framerate 24 -i Output/%08d.png out" + vidCount + ".mp4";
        var process = Process.Start("FFMPEG\\bin\\ffmpeg.exe", cmdTxt);
        process.WaitForExit();
        vidCount++;
    }
    private void Clean()
    {
        string cmdTxt = "/c rmdir Output /s /q";
        var process = Process.Start("C:\\Windows\\System32\\cmd.exe", cmdTxt);
        process.WaitForExit();
    }
}
