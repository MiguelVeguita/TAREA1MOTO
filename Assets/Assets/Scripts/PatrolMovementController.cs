using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class PatrolMovementController : MonoBehaviour
{
    [SerializeField] private Transform[] checkpointsPatrol;
    [SerializeField] private Rigidbody2D myRBD2;
    [SerializeField] private AnimatorController animatorController;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float velocityModifier = 5f;
    [SerializeField] public float vida = 100;
    [SerializeField] private HealthBarController heal;

    public gamemanager gam;
    private Transform currentPositionTarget;
    private int patrolPos = 0;
    public bool detector;
    public LayerMask condi;
    public float raydistancia;

    private void Start() {
        currentPositionTarget = checkpointsPatrol[patrolPos];
        transform.position = currentPositionTarget.position;
    }

    private void Update() 
    {
        CheckNewPoint();

        animatorController.SetVelocity(velocityCharacter: myRBD2.velocity.magnitude);
        detector = Physics2D.Raycast(transform.position, new Vector2(0, -1), raydistancia, condi);
        Debug.DrawRay(transform.position, new Vector2(0, -1) * raydistancia, Color.yellow);
    }

    private void CheckNewPoint(){
        if(Mathf.Abs((transform.position - currentPositionTarget.position).magnitude) < 0.25){
            patrolPos = patrolPos + 1 == checkpointsPatrol.Length? 0: patrolPos+1;
            currentPositionTarget = checkpointsPatrol[patrolPos];
            myRBD2.velocity = (currentPositionTarget.position - transform.position).normalized*velocityModifier;
            CheckFlip(myRBD2.velocity.x);
        }

        
    }

    private void CheckFlip(float x_Position){
        spriteRenderer.flipX = (x_Position - transform.position.x) < 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "balita")
        {
            heal.UpdateHealth(-10);
            vida = vida - 10;
            if (vida <= 0)
            {
                gam.cc();
                Destroy(gameObject);
            }
        }
    }
    private void daño(int amount)
    {
       
    }
}
