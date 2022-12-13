using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

// In this example, we have a Particle System emitting green particles; we then emit and override some properties every 2 seconds.
public class BulletBehaviour : MonoBehaviour
{
    public ParticleSystem system;

    public float columns;

    public float fireRate;

    public Material material;
    private float angle;
    public float bulletLifeTime;
    public Color color;
    public Sprite texture;
    public float speed;
    public float size;
    

    private void Awake()
    {
        Summon();
    }


    void Summon()
    {
        angle = 360f / columns;
        for (int i =0; i<columns;i++)
        {
            // A simple particle material with no texture.
            Material particleMaterial = new Material(Shader.Find("Particles/Standard Unlit"));

            // Create a green Particle System.
            var go = new GameObject("Particle System");
            go.transform.Rotate(angle*i, 90, 0); // Rotate so the system emits upwards.
            go.transform.parent = this.transform;
            go.transform.position = this.transform.position;
            system = go.AddComponent<ParticleSystem>();
            go.GetComponent<ParticleSystemRenderer>().material = particleMaterial;
            var mainModule = system.main;
            mainModule.startColor = Color.green;
            mainModule.startSize = 0.5f;
            mainModule.startSpeed = speed;
            

            var emission = system.emission;
            emission.enabled = false;

            var forma = system.shape;
            forma.enabled = true;
            forma.shapeType = ParticleSystemShapeType.Sprite;
            forma.sprite = null;
            var text = system.textureSheetAnimation;
            text.enabled = true;
            text.mode = ParticleSystemAnimationMode.Sprites;
            text.AddSprite(texture);
        }
       

        // Every 2 secs we will emit.
        InvokeRepeating("DoEmit", 0f, fireRate);
    }

    void DoEmit()
    {
        foreach (Transform child in transform)
        {
            // Any parameters we assign in emitParams will override the current system's when we call Emit.
            // Here we will override the start color and size.
            system = child.GetComponent<ParticleSystem>();
            var emitParams = new ParticleSystem.EmitParams();
            emitParams.startColor = color;
            emitParams.startSize = size;
            emitParams.startLifetime = bulletLifeTime;
            system.Emit(emitParams, 10);
            //system.Play(); // Continue normal emissions
        }
        
    }
}
