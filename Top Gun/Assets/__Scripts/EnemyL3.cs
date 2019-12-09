using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyL3 : MonoBehaviour
{
    private int scoreValue = 10;
    public Transform player;
    private Rigidbody2D rg;
    public int health =100;
    public GameObject deathEffect;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectile;  
   
    void Start()
    {
        rg = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }else{
            timeBtwShots -= Time.deltaTime;
        }
        
    }

    public void takeDamage(int damage )
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        Instantiate(deathEffect,  transform.position, Quaternion.identity);
        ScoreManager.score += scoreValue;
        Destroy(gameObject);
    }

}
