using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : MonoBehaviour
{
    [SerializeField] private Transform inicio;
    [SerializeField] private Transform player;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private LayerMask layer;
    [SerializeField] private GameObject bolamagica;
    
    [SerializeField] private float bolavelocity = 6f;
    [SerializeField] private float vida = 100;
    [SerializeField] private HealthBarController heaal;

    public gamemanager gam;
    private bool playercercano ;
    private Rigidbody2D _mago;
    private Vector2 posi;
    // Start is called before the first frame update
    void Start()
    {
        _mago = GetComponent<Rigidbody2D>();
        posi = inicio.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (playercercano == true)
        {
            irplayer();
        }
        else {
            irinicio();
        }


    }
    void irplayer()
    {
        Vector2 direction = ((Vector2)player.position - _mago.position).normalized;
        _mago.velocity = direction * moveSpeed;
    }
    void irinicio()
    {
        Vector2 direction = (posi - (Vector2)transform.position).normalized;
        _mago.velocity = direction * moveSpeed;
       if (Vector2.Distance(transform.position, posi) < 0.05f)
        {
            _mago.velocity = Vector2.zero;
        }
    }
    void dispro()
    {
        Vector2 direc =(Vector2)(player.position - (Vector3)transform.position).normalized;
        GameObject projectile = Instantiate(bolamagica, transform.position, Quaternion.identity);
        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
        projectileRb.velocity = direc * bolavelocity;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playercercano = true;
            dispro();
        }
        if (collision.tag == "balita")
        {
            heaal.UpdateHealth(-10);
            vida = vida - 10;
            if (vida <= 0)
            {
                gam.cc();
                Destroy(gameObject);
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playercercano = false;
        }
    }
}
