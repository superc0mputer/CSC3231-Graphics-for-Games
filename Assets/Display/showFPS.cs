using UnityEngine;
using System.Collections;
using TMPro;

 
public class showFPS : MonoBehaviour {
    public TMP_Text fpsText;
    public float deltaTime;
 
    void Update () {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = "Framerate: " + Mathf.Ceil (fps).ToString();
    }
}

