﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    public float lifeDuration = 2f;
    float lifeTimer;
    public int attack = 10;

    public bool shooByPlayer;
    private void OnEnable()
    {
        lifeTimer = lifeDuration;
    }
    private void Update()
    {
        lifeTimer -=Time.deltaTime;
        if(lifeTimer <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bullet choca = " + other.name);

        IDamage damage = other.GetComponent<IDamage>();
        bool remove = true;
        if(damage != null)
        {
           remove = damage.DoDamage(attack, shooByPlayer);
        }
       if(remove == true) gameObject.SetActive(false);
    }
}
