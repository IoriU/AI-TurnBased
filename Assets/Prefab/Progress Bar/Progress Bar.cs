using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    public Slider bar;

    public void InitValue(float maxVal)
    {
        bar.maxValue = maxVal;
        bar.value = maxVal;
    }

    public void UpdateVal(float val)
    {
        bar.value = val;
    }
}
