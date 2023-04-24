using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPushScript : MonoBehaviour
{

    [SerializeField]
    public ParticleSystem particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        this.particleSystem.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
