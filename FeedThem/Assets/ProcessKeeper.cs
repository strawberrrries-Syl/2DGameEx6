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

    public int process;


    private TMP_Text processDisplay;

    void Start()
    {
        Singleton = this;
        processDisplay = GetComponent<TMP_Text>();
        // Initialize the display
        ProcessInternal(0);
    }

    private void ProcessInternal(int delta)
    {
        // DONE
        process += delta;
        /*scoreDisplay.text = Score.ToString();*/
        processDisplay.text = $"Process: {process / 30 * 100} %";
    }
}

