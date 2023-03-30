using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxScript : MonoBehaviour
{
    [SerializeField] public Material skyMat;

    void Start()
    {
        RenderSettings.skybox = skyMat;
    }

}
