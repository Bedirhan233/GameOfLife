using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class particleScript : MonoBehaviour
{
    Vector2 direction;
    Vector3 velocity;
    public float speed = 5;
    ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        particle = GetComponent<ParticleSystem>();

        
    }

    // Update is called once per frame
    void Update()
    {
        var noise = particle.noise;
        var main = particle.main;
        noise.strengthMultiplier += 0.01f;

        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        

        velocity = direction * speed * Time.deltaTime;
        transform.position += velocity;

        
    }
}
