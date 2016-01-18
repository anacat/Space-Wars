﻿using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    public GameObject laser;
    AudioSource shoot;
    public float nextFire = 0;
    public float fireRate = 0.5f;
    Light flash;

    void Awake()
    {
        shoot = GetComponent<AudioSource>();
        flash = GetComponent<Light>();
        flash.intensity = 0;
    }
	
	// Update is called once per frame
	void Update () {

        nextFire += Time.deltaTime;

        if (Input.GetButton("Fire1") && fireRate < nextFire)
        {
            Instantiate(laser, transform.position, transform.rotation);
            shoot.Play();
            nextFire = 0;

            flash.intensity = 3.0f;
        }

        flash.intensity = Mathf.Lerp(flash.intensity, 0, Time.deltaTime*2);
    }
}
