using System;
using System.Collections;
using UnityEngine;

public static class Utility
{
    public static IEnumerator DoCoroutine(Action action, float delayTime)
    {
        yield return new WaitForSecondsRealtime(delayTime);

        action();
    }
}
