using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _pla;
    public GameObject balita;
    [SerializeField] private float velocityModifier = 5f;
    [SerializeField] private float rayDistance = 10f;
    [SerializeField] private AnimatorController animatorController;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private HealthBarController viditabarra;
    public float vida = 100;
    public float xmo, ymo;
    public void onmomen(InputAction.CallbackContext context)
    {
        _pla = GetComponent<Rigidbody2D>();
        xmo = context.ReadValue<Vector2>().x;
        ymo = context.ReadValue<Vector2>().y;
    }
    void disparo()
    {
        GameObject bam = Instantiate(balita, transform.position, Quaternion.identity);
        Vector2 direccion = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
        bam.GetComponent<Rigidbody2D>().velocity = direccion.normalized * velocityModifier;
    }
    private void Update() {
       

        animatorController.SetVelocity(velocityCharacter: _pla.velocity.magnitude);

        Vector2 mouseInput = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        CheckFlip(mouseInput.x);
    
        Debug.DrawRay(transform.position, mouseInput.normalized * rayDistance, Color.red);

        if(Input.GetMouseButtonDown(0))
        {
            disparo();
            Debug.Log("Right Click");
        }
        else if(Input.GetMouseButtonDown(1))
        {
            Debug.Log("Left Click");
        }
    }
    private void FixedUpdate()
    {
        _pla.velocity =new Vector2(xmo*10,ymo*10);
    }

    private void CheckFlip(float x_Position){
        spriteRenderer.flipX = (x_Position - transform.position.x) < 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy1")
        {
            viditabarra.UpdateHealth(-10);
            vida = vida - 10;
            if (vida <= 0)
            {
                perder();
            }
        }
        if (collision.tag == "magia")
        {
            viditabarra.UpdateHealth(-10);
            vida = vida - 10;
            if (vida <= 0)
            {
                perder();
            }
        }
    }
    public void perder()
    {
        SceneManager.LoadScene("perder");
    }
}
