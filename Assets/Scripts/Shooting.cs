using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float damage = 10f;
    public float range = 10f;
    public float impactForce = 30f;
    public float fireRate = 15f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    private float nextTimeToFire = 0f;

    private AudioSource m_AudioSourceGun;
    private AudioSource m_AudioSourceSpace;
 

    // Start is called before the first frame update
    void Start()
    {
        m_AudioSourceGun = GetComponent<AudioSource>();
        m_AudioSourceSpace = GetComponent<AudioSource>();

        PlaySoundSpace();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
            PlaySoundGun();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            DaughterDie DaughterDie = hit.transform.GetComponent<DaughterDie>();
            if (DaughterDie != null)
            {
                DaughterDie.TakeDamage(damage);
            }

            EnemyDie EnemyDie = hit.transform.GetComponent<EnemyDie>();
            if (EnemyDie != null)
            {
                EnemyDie.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }

    private void PlaySoundSpace()
    {
        m_AudioSourceSpace.PlayOneShot(m_AudioSourceSpace.clip);
    }

    private void PlaySoundGun()
    {
        m_AudioSourceGun.PlayOneShot(m_AudioSourceGun.clip);
    }
}
