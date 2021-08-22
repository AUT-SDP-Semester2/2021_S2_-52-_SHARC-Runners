using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
public float MovementSpeed = 1; // Movement speed of game object
    public float JumpForce = 4; // Jump height of game object
    public Rigidbody2D _rigidbody; // instance of Rigidbody2D
 

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

    }

    //Method for applying the movement inputs
    private void Update()
    {
        //movement for horizontal plane
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement,0,0) * Time.deltaTime * MovementSpeed;

        //movement for jump or vertical plane
        if(Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
      
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "PowerUp")
        {
            Destroy(collision.gameObject);
            JumpForce = 20;
            MovementSpeed = 10;
        }
    } */

}
