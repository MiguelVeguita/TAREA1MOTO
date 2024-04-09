using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balita : MonoBehaviour
{
    public int daño;
  
    // Start is called before the first frame update
    void Start()
    {
        daño = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void dañoene()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="enemy1")
        {
          
            Destroy(this.gameObject);
        }
        if (collision.tag == "enemy2")
        {
           
            Destroy(this.gameObject);
        }
        if (collision.tag == "enemy3")
        {
          
            Destroy(this.gameObject);
        }
    }
}
