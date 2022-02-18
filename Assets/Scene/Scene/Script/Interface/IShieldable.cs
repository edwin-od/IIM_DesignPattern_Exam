using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShieldable
{
    bool IsShielding { get; }

    void SetIsShielding(bool _isShielding);
}
