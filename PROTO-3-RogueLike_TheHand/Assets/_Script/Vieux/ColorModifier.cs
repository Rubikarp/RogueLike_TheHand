using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorModifier : MonoBehaviour
{
    public SpriteRenderer spriteR;

    public Slider sliderR, sliderG, sliderB, sliderA;
    private float r, g, b,a;


    public void UpdateColor()
    {
        r = sliderR.value;
        g = sliderG.value;
        b = sliderB.value;
        a = sliderA.value;

        spriteR.color = new Color(r, g, b, a);
    }


}
