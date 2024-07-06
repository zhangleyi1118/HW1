using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FootprintTrigger : MonoBehaviour
{
    public GameObject Ground;
    public ParticleSystem footprintParticles; // Drag your footprint particle system here in the Inspector
    private List<ParticleSystem> particleSystems;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject==Ground)
        {
            ContactPoint contact = collision.contacts[0]; // Get the first contact point

            // Instantiate footprint particles at the contact point
            ParticleSystem newFootprint = Instantiate(footprintParticles, contact.point, Quaternion.identity);

            // Optionally, parent the footprint particles to the ground or other suitable parent object
            newFootprint.transform.parent = collision.transform;
            particleSystems.Add(newFootprint);
            foreach(ParticleSystem Footprint in particleSystems)
            {
                Footprint.Play();
            }
            
            // Play the footprint particles
        }
    }
}