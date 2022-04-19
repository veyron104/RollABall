using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HelperScript
{
    public static int StringLengh(this string tempString)
    {
        if (string.IsNullOrEmpty(tempString)) return 0;
        else return tempString.Length;
    }
}