using UnityEngine;
using System.Collections;

public class FrameRateFixer : MonoBehaviour
{

    float deltaTime = 0.0f;
    public bool ShowFPS;
    public bool LimitFPS;

    // Use this for initialization
    void Start()
    {
        if (LimitFPS)
        {
            Application.targetFrameRate = 75;
        }
        

    }

    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
    }

    void OnGUI()
    {
        if (ShowFPS)
        {
            int w = Screen.width, h = Screen.height;

            GUIStyle style = new GUIStyle();

            Rect rect = new Rect(0, 0, w, h * 2 / 100);
            style.alignment = TextAnchor.UpperRight;
            style.fontSize = h * 2 / 100;
            style.normal.textColor = Color.white;
            float msec = deltaTime * 1000.0f;
            float fps = 1.0f / deltaTime;
            string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
            GUI.Label(rect, text, style);
        }
    }
}
