/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyL2 : MonoBehaviour
{
    private int scoreValue = 10;
    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rg;
    private Vector2 movement;
    public int health =100;
    public GameObject deathEffect;
    public float speed;
    public float stoppingDistance;
    public float reatreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;  


    // Start is called before the first frame update
    void Start()
    {
        rg = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        //float angle = Mathf.Atan2(direction.y, direction.x)* Mathf.Rad2Deg;
        //rg.rotation = angle;
        direction.Normalize(); 
        movement = direction;
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > reatreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);

        }

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

    private void FixedUpdate(){
        moveChar(movement);
    }

    void moveChar(Vector2 direction){
        rg.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
} */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyL2 : MonoBehaviour
{
    // use later for other stuff
    // add the collider stuff, to detect if a bullet hits
    // detect the collisiion
    // destroy the bullet prefab, then this prefab
    private int scoreValue = 10;
    public int health =100;
    public GameObject deathEffect;

    //enemy movement variables
    public float speed;
    public float stoppingDistance;
    public float reatreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;  
    public Transform player;

    void Start(){
        player = GameObject.FindGameObjectWithTag("PlayerL2").transform;
        timeBtwShots = startTimeBtwShots;
    } 

    void Update(){
        
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > reatreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);

        }

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
