using Unity.VisualScripting;
using UnityEngine;

public class Biome_Transion : MonoBehaviour
{
    public ParticleSystem ParticlesLeave;
    public ParticleSystem ParticlesFirefly;

    private void Start()
    {
        ParticlesFirefly.Stop();
    }
}
