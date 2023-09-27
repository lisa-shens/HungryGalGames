using UnityEngine;

public class PlayerSwing : MonoBehaviour
{
    public GameObject arrowPrefab, spearPrefab, starPrefab;
    public Transform spawnPoint;
    public float speed = 10.0f;
    public float shootAngle = 330.0f;
    public float horizontalOffset = 1.0f;
    public Sprite toSwing;
    private float lastTimeFired = 0;
    public float rateOfFire = 1;
    private Animator animator;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q) && (lastTimeFired + 1 / rateOfFire) < Time.time)
        {
            Shoot(spearPrefab);
        }
        if (Input.GetKeyDown(KeyCode.W) && (lastTimeFired + 1 / rateOfFire) < Time.time)
        {
            Shoot(arrowPrefab);
        }
        if (Input.GetKeyDown(KeyCode.E) && (lastTimeFired + 1 / rateOfFire) < Time.time)
        {
            Shoot(starPrefab);
        }


        animator.SetTrigger("PlayerSwinging");

        animator = GetComponent<Animator>();
    }

    private void Shoot(GameObject projectilePrefab)
    {
        GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
        Vector2 direction = Quaternion.Euler(0, 0, shootAngle) * transform.right;
        Vector3 spawnPosition = spawnPoint.position + Vector3.right * horizontalOffset;
        projectile.GetComponent<Rigidbody2D>().velocity = direction.normalized * speed;
        projectile.transform.position = spawnPosition;
    }
}
