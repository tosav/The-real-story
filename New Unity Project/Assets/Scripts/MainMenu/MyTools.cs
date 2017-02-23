using UnityEditor;
using UnityEngine;
using System.Collections;

public class MyTools
{

    [MenuItem("My Tools/UI Anchor Fit To Size")]
    static public void SetUIAnchorFitToSize()
    {
        Transform activeTransform = Selection.activeTransform;

        if (activeTransform != null)
        {
            RectTransform rectTr = activeTransform.GetComponent<RectTransform>();

            // Reset anchors
            rectTr.anchorMin = Vector2.zero;
            rectTr.anchorMax = new Vector2(1f, 1f);

            float offsetMinX = rectTr.offsetMin.x;   // +left
            float offsetMinY = rectTr.offsetMin.y;   // +bottom

            RectTransform parenRectTr = rectTr.parent.GetComponent<RectTransform>();

            float anchorMinX = offsetMinX / parenRectTr.rect.width;
            float anchorMinY = offsetMinY / parenRectTr.rect.height;

            rectTr.anchorMin = new Vector2(anchorMinX, anchorMinY);

            float offsetMaxX = rectTr.offsetMax.x;   // -right
            float offsetMaxY = rectTr.offsetMax.y;   // -top

            float anchorMaxX = offsetMaxX / parenRectTr.rect.width;
            float anchorMaxY = offsetMaxY / parenRectTr.rect.height;
            anchorMaxX += 1f;
            anchorMaxY += 1f;

            rectTr.anchorMax = new Vector2(anchorMaxX, anchorMaxY);

            rectTr.offsetMin = Vector2.zero;
            rectTr.offsetMax = Vector2.zero;
        }
    }

    [MenuItem("My Tools/UI Size Fit To Parent")]
    static public void SetUISizeFitToParent()
    {
        Transform activeTransform = Selection.activeTransform;

        if (activeTransform != null)
        {
            RectTransform rectTr = activeTransform.GetComponent<RectTransform>();
            if (rectTr.anchorMin.x != 0f || rectTr.anchorMin.y != 0f)
                rectTr.anchorMin = Vector2.zero;
            if (rectTr.anchorMax.x != 1f || rectTr.anchorMax.y != 1f)
                rectTr.anchorMax = new Vector2(1f, 1f);
            rectTr.offsetMin = Vector2.zero;
            rectTr.offsetMax = Vector2.zero;
        }
    }


}
