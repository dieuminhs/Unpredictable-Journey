using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLauncher : MonoBehaviour
{
    public ParticleSystem particleLauncher;
    public Collider2D trigger;
    private float skillTimeout = 0f;

    void Awake()
    {
        trigger.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(skillTimeout>0)
        {
            skillTimeout -= Time.deltaTime;
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            skillTimeout = 5.0f;
            particleLauncher.Emit(1);
        }
    }

    void OnParticleTrigger()
    {
        trigger.enabled = true;
    }

    public void OnParticleSystemStopped()
    {
        trigger.enabled = false;
    }
}
