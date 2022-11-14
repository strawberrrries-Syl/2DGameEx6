using TMPro;
using UnityEngine;

/// <summary>
/// Displays the score in whatever text component is store in the same game object as this
/// </summary>
[RequireComponent(typeof(TMP_Text))]
public class MissedTracker : MonoBehaviour
{
    public static MissedTracker Singleton;

    public static void MissedPoint(int points)
    {
        Singleton.MissedInternal(points);
    }

    public static void ResetPoint()
    {
        Singleton.resetInternal();
    }

    public static int missed;
    private TMP_Text missedDisplay;

    void Start()
    {
        Singleton = this;
        missedDisplay = GetComponent<TMP_Text>();
        // Initialize the display
        MissedInternal(0);
    }

    public static int GetMissedNum() {
        return missed;
    }

    private void resetInternal()
    {
        missed = 0;
        missedDisplay.text = $"Missed: {missed}";
    }

    private void MissedInternal(int delta)
    {
        // DONE
        missed += delta;
        /*scoreDisplay.text = Score.ToString();*/
        missedDisplay.text = $"Missed: {missed}";
    }


}