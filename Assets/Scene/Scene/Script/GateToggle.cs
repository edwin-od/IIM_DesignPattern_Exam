using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateToggle : Gate
{
    [SerializeField] List<Toggle> toggles = new List<Toggle>();

    public void CheckGate()
    {
        int ons = 0;
        foreach (var toggle in toggles) { if (toggle.IsActive) ons++; }

        if(ons == toggles.Count) OpenGate();
    }
}
