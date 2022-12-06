using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using  Unity.Profiling;

public class showMemory : MonoBehaviour
{
    private ProfilerRecorder totalUsedMemory;
    public TMP_Text memoryText;
    void Start()
    {
        totalUsedMemory = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Total Used Memory");
    }

    // Update is called once per frame
    void Update()
    {
        memoryText.text = "Total Used Memory: " + totalUsedMemory.LastValue.ToString();

    }
}
