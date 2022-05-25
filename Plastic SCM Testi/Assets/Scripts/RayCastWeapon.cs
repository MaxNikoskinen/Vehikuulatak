using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastWeapon : MonoBehaviour
{
    public Transform firePoint;
    int damage;
    public GameObject impactEffect;
    public LineRenderer lineRenderer;
    public AudioSource audioSource;
    public AudioClip shootingAudioClip;
    private float shootingDelay = 0f;
    public float shootingSpeed = 0.5f;
    // Update is called once per frame
    void Update()
    {
        damage = GameManager.Instance.GetDamage();
        if (Input.GetKey(KeyCode.Z) /*&& (Time.time >= shootingDelay)*/)
        {
           StartCoroutine (Shoot());
            audioSource.PlayOneShot(shootingAudioClip);
            shootingDelay = Time.time + 1f / shootingSpeed;
        }

    }

    IEnumerator Shoot ()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

        if (hitInfo)
        {
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            Instantiate(impactEffect, hitInfo.point, Quaternion.identity);

            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);
        }  else
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
        }

        lineRenderer.enabled = true;

        yield return new WaitForSeconds(0.02f);  

        lineRenderer.enabled = false;
        
    }
}
