using TMPro;
using UnityEngine;

/// <summary>
/// Displays the score in whatever text component is store in the same game object as this
/// </summary>
[RequireComponent(typeof(TMP_Text))]
public class ProcessKeeper : MonoBehaviour
{
    public static ProcessKeeper Singleton;

    public static void Process(int points)
    {
        Singleton.ProcessInternal(points);
    }

    public static int GetProcessNum()
    {
        return Singleton.GetProcessNumInternal();
    }

    public static void ResetProcess() {
        Singleton.ResetProcessInternal();
    }

    public static int process;


    private TMP_Text processDisplay;

    void Start()
    {
        Singleton = this;
        processDisplay = GetComponent<TMP_Text>();
        // Initialize the display
        ProcessInternal(0);
    }

    private int sum = 10;
    private void ProcessInternal(int delta)
    {
        process += delta;
        processDisplay.text = $"Process: {process* 100 / sum } %";
    }

    private int GetProcessNumInternal()
    {
        return process / sum * 100;
    }

    private void ResetProcessInternal()
    {
        process = 0;
        processDisplay.text = $"Process: 0 %";
    }
}

