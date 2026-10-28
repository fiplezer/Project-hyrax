using Unity.VisualScripting;
using UnityEngine;

public class Biome_Transion : MonoBehaviour
{
    public ParticleSystem ParticlesLeave;
    public ParticleSystem ParticlesFirefly;

    private bool Leaves = true;
    private bool Fireflies = false;

    private void Start()
    {
        ParticlesFirefly.Stop();
    }
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "BiomeWater")
        {
            if (Leaves == true && Fireflies == false)
            {
                ParticlesLeave.Stop();
                ParticlesFirefly.Play();
                Leaves = false;
                Fireflies = true;
            }
            else if (Fireflies == true && Leaves == false)
            {
                ParticlesLeave.Play();
                ParticlesFirefly.Stop();
                Fireflies = false;
                Leaves = true;
            }
            
        }
        else
        {
            Debug.Log("woringTrigger");
        }
    }
}
