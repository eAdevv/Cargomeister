using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class EventManager
{
    public static event EventHandler eDrop;

    public static void OnDrop()
    {
        eDrop?.Invoke(null, EventArgs.Empty);
    }


}
