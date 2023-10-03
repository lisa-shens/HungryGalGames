using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwing : MonoBehaviour
{
    public GameObject arrowPrefab, spearPrefab, starPrefab;
    public Transform spawnPoint;
    public float speed = 10.0f;
    public float shootAngle = 330.0f;
    public float horizontalOffset = 1.0f;
    public float rateOfFire = 1.0f; // Shots per second
    public Animator animator;
    private float lastTimeFired = 0.0f;
    private bool canShoot = true; // Indicates if the player can shoot
    public AudioClip spearSound;
    public AudioClip arrowSound;
    public AudioClip starSound;



    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (canShoot && Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetTrigger("PlayerSwinging"); 
            Shoot(spearPrefab);
            AudioSource.PlayClipAtPoint(spearSound, transform.position);
        }
        else if (canShoot && Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("PlayerSwinging"); 
            Shoot(arrowPrefab);
            AudioSource.PlayClipAtPoint(arrowSound, transform.position);
        }
        else if (canShoot && Input.GetKeyDown(KeyCode.E))
        { 
            animator.SetTrigger("PlayerSwinging"); 
            Shoot(starPrefab);
            AudioSource.PlayClipAtPoint(starSound, transform.position);
        }
    }

    private void Shoot(GameObject projectilePrefab)
    {
        if (Time.time > lastTimeFired + 1 / rateOfFire)
        {
            lastTimeFired = Time.time;

            GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
            Vector2 direction = Quaternion.Euler(0, 0, shootAngle) * transform.right;
            Vector3 spawnPosition = spawnPoint.position + Vector3.right * horizontalOffset;
            projectile.GetComponent<Rigidbody2D>().velocity = direction.normalized * speed;
            projectile.transform.position = spawnPosition;

            // Start the cooldown
            canShoot = false;
            StartCoroutine(ResetCooldown());
        }
    }

    private IEnumerator ResetCooldown()
    {
        yield return new WaitForSeconds(1);
        canShoot = true; // Allow shooting again after the cooldown period
    }
}
