using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed =20f;
    public Rigidbody2D rb;
    public int damage = 25;
    Player target;
Vector2 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        rb.velocity = transform.right * speed;
        target = GameObject.FindObjectOfType<Player>();
        moveDirection = (target.transform.position - transform.position).normalized * speed;
         rb.velocity = new Vector2 (moveDirection.x, moveDirection.y);
         Destroy (gameObject, 3f);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
    Debug.Log (hitInfo.name);
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.takeDamage(damage);
        }

      Destroy (gameObject);
      
    }
}
