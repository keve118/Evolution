using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that govers the generic Buttonpress function. Children overrides to
/// implement specific menu functionality in unity.
/// </summary>
public abstract class ButtonFunc : MonoBehaviour
{
    public abstract void ButtonPress();
}
