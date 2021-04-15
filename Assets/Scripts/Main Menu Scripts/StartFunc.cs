using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Governs the methodcall attached to the start button in start menu
/// </summary>
public class StartFunc : ButtonFunc
{
    public override void ButtonPress()
    {
        Debug.Log("Start function was called");
    }
}