using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class I_Wanna_Shoot_Stuff : MonoBehaviour
{
    #region Variables
    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    #endregion

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) //This is a default Unity Map. Doesn't need to be set in inputs.
        {
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            // this is essentially a "hitscan" shooting system in which the center player casts a target and sends damage upon interaction with the "Target"

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.takeDamage(damage);
            }

            Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }
}
