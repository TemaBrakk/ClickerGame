using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuModel
{
    public bool IsSavesWindowActive { get; private set; }

    public void Initialize()
    {
        IsSavesWindowActive = false;
    }

    public void ChangeSavesWindowMode()
    {
        IsSavesWindowActive = !IsSavesWindowActive;
    }
}
