using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackRepet : MonoBehaviour
{
    public float speed = 0.1f;
    public Renderer backgroundRenderer;

    void Update()
    {

        backgroundRenderer.material.mainTextureOffset += new Vector2(1f * Time.deltaTime * speed, 0);   //renderuje texturu do nekonečna

    }
}
