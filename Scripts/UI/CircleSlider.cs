using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleSlider : MonoBehaviour {

    [SerializeField]
    private float minValue = 0F;
    [SerializeField]
    private float maxValue = 1F;

    private Image fill;

    public float min
    {
        get { return minValue; }
    }

    public float max
    {
        get { return maxValue; }
    }

    public float amount
    {
        get { return fill.fillAmount; }
        set { fill.fillAmount = value; }
    }

    private void Awake() {
        fill = transform.GetChild(1).GetComponent<Image>();
    }
}
