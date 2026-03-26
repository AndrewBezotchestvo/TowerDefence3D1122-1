using UnityEngine;

public class CastleController : MonoBehaviour
{
    public float castleHP;

    void Start()
    {
        castleHP = 100;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            castleHP -= 10;
            other.gameObject.GetComponent<EnemyController>().GiveDamage(100);
        }
    }

}
