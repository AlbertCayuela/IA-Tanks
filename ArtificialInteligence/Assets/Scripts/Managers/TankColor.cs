using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankColor : MonoBehaviour
{
    public Color wander_color;
    public Color patrol_color;

    public GameObject wander_tank;
    public GameObject patrol_tank;

    // Start is called before the first frame update
    void Awake()
    {
        MeshRenderer[] wander_renderers = wander_tank.GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < wander_renderers.Length; i++)
        {
            wander_renderers[i].material.color = wander_color;
        }

        MeshRenderer[] patrol_renderers = patrol_tank.GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < patrol_renderers.Length; i++)
        {
            patrol_renderers[i].material.color = patrol_color;
        }
    }
}