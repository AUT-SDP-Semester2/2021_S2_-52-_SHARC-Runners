using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed; //Speed of enemy
    public float stoppingDistance; //Distance where enemy stops
    public float lineOfSite;
    public float retreatDistance; //Distance where enemy will retreat if player reaches this distance
    public Transform player;
    
    void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void MoveTowardsPlayer() 
    {
        float distanceFromPLayer = Vector2.Distance(player.position, transform.position);
        if(Vector2.Distance(transform.position, player.position) > stoppingDistance && distanceFromPLayer < lineOfSite)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if(Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if(Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position,player.position, -speed * Time.deltaTime);
        }
    }
}
