using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerL2 : MonoBehaviour
{
    
     // == fields ==
    [SerializeField]    // adds this field to the Unity editor
    private float playerSpeed = 5.0f;
    public int health =100;
    public GameObject deathEffect;
    public Transform enemy;
    private Rigidbody2D rbg;

    // Start is called before the first frame update
    void Start()    // initialisation
    {
        rbg = this.GetComponent<Rigidbody2D>();
    }

    // == private methods ==
    private void Update()
    {
        Move();
        Vector3 direction = enemy.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x)* Mathf.Rad2Deg;
        rbg.rotation = angle;
        direction.Normalize(); 
    }

    private void Move()
    {
        // need to ensure that deltaX is frame rate independent
        // use Time.deltaTime as a multiplier
        // also add a speed multiplier for the player to get a good feel
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed;
        // add the delta to the current position
        var newXPos = transform.position.x + deltaX;
        var newYPos = transform.position.y + deltaY;
        // update the current position
        transform.position = new Vector2(newXPos, newYPos);
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
         //  Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   
}
