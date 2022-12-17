using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// In this example, we have a Particle System emitting green particles; we then emit and override some properties every 2 seconds.
public class BulletBehaviour : MonoBehaviour
{
    public ParticleSystem system;

    public float columns;

    public float fireRate;

    public Material _material;
    private float angle;
    public float bulletLifeTime;
    public Color color;
    public Sprite texture;
    public float speed;
    public float size;
    public float spin_speed;
    private float time;
    //private List<ParticleCollisionEvent> colEvents = new List<ParticleCollisionEvent>();
    private int events;


    private void Awake()
    {
        Summon();
    }

    private void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        transform.rotation = Quaternion.Euler(0, 0, time*spin_speed);
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
            //var bounds = this.GetComponent<BoxCollider>().bounds;
            go.transform.parent = transform;
            go.transform.position = transform.position;
            system = go.AddComponent<ParticleSystem>();
            go.AddComponent<BulletCollision>();
            go.GetComponent<ParticleSystemRenderer>().material = _material;
            var mainModule = system.main;
            mainModule.startColor = Color.green;
            mainModule.startSize = 0.5f;
            mainModule.startSpeed = speed;
            mainModule.simulationSpace = ParticleSystemSimulationSpace.World;
            mainModule.maxParticles = 10000;

            var emission = system.emission;
            emission.enabled = false;

            var forma = system.shape;
            forma.enabled = true;
            forma.shapeType = ParticleSystemShapeType.Cone;
            forma.angle = 0f;
            forma.radius = 0;
            forma.sprite = null;
            var text = system.textureSheetAnimation;
            text.enabled = true;
            text.mode = ParticleSystemAnimationMode.Sprites;
            text.AddSprite(texture);
            var col = system.collision;
            col.enabled = true;
            col.type = ParticleSystemCollisionType.World;
            col.mode = ParticleSystemCollisionMode.Collision2D;
            col.bounce = 0;
            col.lifetimeLoss = 1;
            col.sendCollisionMessages= true;
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
