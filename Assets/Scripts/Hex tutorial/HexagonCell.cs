using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonCell : MonoBehaviour
{

    public HexCoordinates coordinates;
    public static class HexMetrics
    {

        public const float outerRadius = 10f;
        //uitgerenkend met wiskunde die ik een soort van begrijp
        public const float innerRadius = outerRadius * 0.866025404f;

        //plaatst de 6 hoeken met de eerste hoek in het centrum boven
        public static Vector3[] corners = {
        new Vector3(0f, 0f, outerRadius),
        new Vector3(innerRadius, 0f, 0.5f * outerRadius),
        new Vector3(innerRadius, 0f, -0.5f * outerRadius),
        new Vector3(0f, 0f, -outerRadius),
        new Vector3(-innerRadius, 0f, -0.5f * outerRadius),
        new Vector3(-innerRadius, 0f, 0.5f * outerRadius),
        new Vector3(0f, 0f, outerRadius)
    };
    }
    
}
