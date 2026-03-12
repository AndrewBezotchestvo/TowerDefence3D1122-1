using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public List<GameObject> wayPoints;
    public float moveSpeed = 5f;
    public float reachDistance = 0.5f;
    public float health = 100;

    private Rigidbody rb;
    private Animator animator;
    private int curentPointIndex = 0;
    private bool isMoving;

    private Vector3 direction;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, wayPoints[curentPointIndex].transform.position) < reachDistance)
        {
            curentPointIndex += 1;
        }
    }

    void FixedUpdate()
    {
        Transform currentPoint = wayPoints[curentPointIndex].transform;
        direction = (currentPoint.position - transform.position).normalized;
        rb.MovePosition(direction * moveSpeed *Time.fixedDeltaTime + transform.position);
    }

}
