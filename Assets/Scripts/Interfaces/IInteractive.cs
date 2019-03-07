using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Interface for when the player interacts with objects using the interact button
/// </summary>
public interface IInteractive
{
    string DisplayText { get; }
    void InteractWith();
}

