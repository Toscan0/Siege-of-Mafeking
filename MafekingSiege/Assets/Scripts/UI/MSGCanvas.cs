using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class MSGCanvas : MonoBehaviour
{
    private Image image;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    internal void UpdateImageVisibility(bool newVisibility)
    {
        image.enabled = newVisibility;
    }
}
