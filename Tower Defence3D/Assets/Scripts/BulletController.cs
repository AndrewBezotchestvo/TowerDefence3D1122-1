using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 20;
    
    private Transform target;
    
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        

        Vector3 direction = (target.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
        
    }
    
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyController>().GiveDamage(damage);
        }
        Destroy(gameObject);
    }
}