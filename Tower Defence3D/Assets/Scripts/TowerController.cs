using UnityEngine;

public class TowerController : MonoBehaviour
{
    public float range = 10f;              
    public float fireRate = 1f;  
    public float rotationSpeed = 2f;           

    public GameObject bulletPrefab;    
    public GameObject rotatePlatform;    
    public GameObject gun;   
    public Transform firePoint;             
    
    private Transform currentTarget;
    private float fireCooldown = 0f;
    
    void Update()
    {
        if (currentTarget == null)
        {
            FindTarget();
        }
        
        if (currentTarget != null)
        {
            float distance = Vector3.Distance(transform.position, currentTarget.position);
            if (distance >= range)
            {
                currentTarget = null;
                return;
            }

            RotatePlatform(currentTarget);
            RotateGun(currentTarget);
            
            if (fireCooldown <= 0f)
            {
                Shoot();
                fireCooldown = 1f / fireRate;
            }
        }
        
        if (fireCooldown > 0) fireCooldown -= Time.deltaTime;
    }
    
    void FindTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < shortestDistance && distance <= range)
            {
                shortestDistance = distance;
                currentTarget = enemy.transform;
            }
        }
    }
    
    void Shoot()
    {
        if (bulletPrefab != null && firePoint != null && currentTarget != null)
        {
            GameObject cannonball = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            BulletController ball = cannonball.GetComponent<BulletController>();
            if (ball != null)
            {
                ball.SetTarget(currentTarget);
            }
        }
    }
    
    // Показать радиус в редакторе
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void RotatePlatform(Transform target)
    {
        Vector3 direction = (target.position - rotatePlatform.transform.position).normalized;
            direction.x = 0; // Если не нужен поворот по вертикали
            direction.z = 0;

            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);

                rotatePlatform.transform.rotation = Quaternion.Slerp( rotatePlatform.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
    }
    void RotateGun(Transform target)
    {
        Vector3 direction = (target.position - gun.transform.position).normalized;
            direction.y = 0; // Если не нужен поворот по вертикали
            
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);

                gun.transform.rotation = Quaternion.Slerp(gun.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
    }
}