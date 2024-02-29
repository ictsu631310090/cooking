using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditScpit : MonoBehaviour
{
    [SerializeField] private Sprite[] image = { };
    private int numimage;
    [SerializeField] private RawImage imageShow;
    [SerializeField] private float imageAlive;
    private float imageAliveMax;
    [SerializeField] private float speedSlide;
    private bool fading;
    private void Fade(bool i)
    {
        float fade;
        if (i)
        {
            fade = imageShow.color.a - (speedSlide * Time.deltaTime);
        }
        else
        {
            fade = imageShow.color.a + (speedSlide * Time.deltaTime);
        }
        Color newColor = new Color(imageShow.color.r, imageShow.color.g, imageShow.color.b, fade);
        imageShow.color = newColor;
        if (fade <= 0)
        {
            imageAlive = imageAliveMax;
            if (numimage != image.Length - 1)
            {
                numimage++;
            }
            imageShow.texture = image[numimage].texture;
            fading = true;
        }
        else if (imageShow.color.a >= 1)
        {
            fading = false;
        }
    }
    private void Start()
    {
        imageAliveMax = imageAlive;
        numimage = 0;
        imageShow.texture = image[numimage].texture;
        imageShow.color = new Color(1, 1, 1, 1);
        fading = false;
    }
    private void Update()
    {
        if (!fading && numimage != image.Length - 1)
        {
            imageAlive -= Time.deltaTime;
            if (imageAlive <= 0)
            {
                Fade(true);
            }
        }
        else if (fading)
        {
            Fade(false);
        }
    }
}
