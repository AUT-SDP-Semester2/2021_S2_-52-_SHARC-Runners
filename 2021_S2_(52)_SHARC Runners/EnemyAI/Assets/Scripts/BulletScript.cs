using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
   GameObject target; // Target variable for bullet
   public float speed; //speed of bullet
   Rigidbody2D bulletRB; //RigidBody applied for bullet 
   
   //Method for bullet shooting at player
    public void Shoot()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 2);
    }

}
