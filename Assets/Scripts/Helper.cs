using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helper {

    public static void Switch(CanvasGroup cg1, CanvasGroup cg2)
    {
        HideCanvasGroup(cg1);
        ShowCanvasGroup(cg2);
    }

    public static void HideCanvasGroup(CanvasGroup cg)
    {
        cg.alpha = 0f; //this makes everything transparent
        cg.blocksRaycasts = false; //this prevents the UI element to receive input events
    }

    public static void ShowCanvasGroup(CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.blocksRaycasts = true;
    }
}
