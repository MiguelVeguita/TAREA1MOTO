using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balita : MonoBehaviour
{
    public int da�o;
  
    // Start is called before the first frame update
    void Start()
    {
        da�o = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void da�oene()
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
