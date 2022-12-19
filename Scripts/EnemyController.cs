using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject enemy;
    public float attackRadius;
    public int damagePerAttack;

    private float movementSpeed;
    private float changeDirectionTime;

    void Start()
    {
        movementSpeed = Random.Range(1.0f, 3.0f);
        changeDirectionTime = Random.Range(1.0f, 3.0f);

        enemy = gameObject;
    }

    void Update()
    {
        if (Time.time >= changeDirectionTime)
        {
            changeDirectionTime = Time.time + Random.Range(1.0f, 3.0f);
            Vector2 movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
            transform.Translate(movementDirection * movementSpeed * Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, enemy.transform.position) <= attackRadius)
        {
            enemy.GetComponent<PlayerController>().TakeDamage(damagePerAttack);  // Call the TakeDamage function on the player character
        }
    }
}
