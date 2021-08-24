using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_movement : MonoBehaviour
{
    public float movementSpeed;
    public float speedTimer;
    public bool activateSpeed;

    public Rigidbody2D rb;
    public Collectable collectableMeter;//Access the collectable script

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movementSpeed = 5;
        speedTimer = 0;
        activateSpeed = false;
        //collectableMeter.UpdateCoins();//Reset the Ability meter
    }

    // Update is called once per frame
    void Update()
    {
  
        var moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * movementSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 7f);
        }
        
        
        if (Input.GetButtonDown("Fire2"))
        {
            activateSpeed = collectableMeter.SetSpeed();//Call set speed to activate boost
            if(activateSpeed)
                SpeedAbility();
        }
        //If true start the time limit of the ability
        if (activateSpeed)
        {
            speedTimer += Time.deltaTime;
            if (speedTimer >= 3)
            {
                movementSpeed = 1;
                speedTimer = 0;
                activateSpeed = false;
            }
        }
    }
    //Change the speed of the character
    public void SpeedAbility()
    {
        collectableMeter.UpdateCoins();
        movementSpeed = 10;
    }

}
