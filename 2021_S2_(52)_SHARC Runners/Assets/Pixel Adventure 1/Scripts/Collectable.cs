using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Collectable : MonoBehaviour
{
    private int coins = 0;

    [SerializeField] private Text Counter;//Access the text 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            Destroy(collision.gameObject);
            coins++;
            Counter.text = coins + "/8";
        }
    }
}
