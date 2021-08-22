using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float directionx = Input.GetAxisRaw("Horizontal");
        rigid.velocity = new Vector2(directionx * 7f, rigid.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rigid.velocity = new Vector2(rigid.velocity.x, 7f);
        }
    }
}
