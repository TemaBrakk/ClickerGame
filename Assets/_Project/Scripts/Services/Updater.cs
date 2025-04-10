using System.Collections.Generic;
using UnityEngine;

public class Updater : MonoBehaviour
{
    private List<IUpdatable> _updatables;

    public void Initialize()
    {
        _updatables = new List<IUpdatable>();
    }

    public void AddUpdatable(IUpdatable updatable)
    {
        _updatables.Add(updatable);
    }

    private void Update()
    {
        foreach(IUpdatable updatable in _updatables)
        {
            updatable?.Update();
        }
    }
}
