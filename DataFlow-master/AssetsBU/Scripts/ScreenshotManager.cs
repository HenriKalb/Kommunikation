using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class ScreenshotManager : MonoBehaviour {

    public GameObject Flash;
    private int screenshotCounter;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void TakeScreenshot()
    {
        StartCoroutine(Screenshot());
    }

    private IEnumerator Screenshot()
    {
        yield return new WaitForSeconds(2);
        yield return new WaitForEndOfFrame(); // wait for end of frame to include GUI

        Texture2D screenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenshot.Apply(false);

        if (Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.WindowsPlayer && Application.platform != RuntimePlatform.LinuxPlayer || Application.isEditor)
        {
            byte[] bytes = screenshot.EncodeToPNG();
            FileStream fs = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\MUST\\Screenshots\\" + "Screenshot_" + screenshotCounter + ".png", FileMode.OpenOrCreate);
            BinaryWriter w = new BinaryWriter(fs);
            w.Write(bytes);
            w.Close();
            fs.Close();
        }
        screenshotCounter++;

        Flash.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        Flash.SetActive(false);

        print("Screenshot taken");

    }
    
}
