using TMPro;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Displays the score in whatever text component is store in the same game object as this
/// </summary>
[RequireComponent(typeof(TMP_Text))]
public class Status : MonoBehaviour
{
    public static bool Running;
    public static Status Singleton;

    void Start()
    {
        Running = true;
        Singleton = this;
    }

    public static bool GetStatus()
    {
        return Running;
    }

    public static void ResetStatus() {
        Singleton.ResetStatusInternal();
    }

    public static void FreezeStatus() {
        Singleton.FreezeInternal();
    }


    private void FreezeInternal() { 
       Running = false;
    }

    private void ResetStatusInternal()
    {
        Running = true;
    }


}