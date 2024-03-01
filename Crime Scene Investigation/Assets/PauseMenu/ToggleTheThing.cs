using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTheThing : MonoBehaviour
{
    public bool isActive;
    public GameObject toBeToggled;

    public void Toggle()
    {
        isActive = !isActive;
        toBeToggled.SetActive(isActive);
    }

    public void ContinueToggle()
    {
        isActive = false;
        toBeToggled.SetActive(isActive);
    }
}