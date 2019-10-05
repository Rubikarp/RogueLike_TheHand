using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvDash : MonoBehaviour
{
    //pour mettre de la physique dessus
    [SerializeField] private Rigidbody2D body;

    //qu'est ce qui est considéré comme environnement ?
    public LayerMask isEnvironnement;

    //pour voir l'input horizontal
    [SerializeField] protected float direction = 0;
    [SerializeField] protected float dashInput = 0;


    //Paramètre du dash
    [SerializeField] private float dashForce = 10f;
    [SerializeField] private bool isDashing = false;
    [SerializeField] private float dashTimer = 0.3f;
    private float dashTime = 0.0f;

    //En contacte avec le sol ?
    public bool isOnGround = false;
    //pour vérifier s'il touche le sol 
    [SerializeField] private Transform posDetectGround;
    private float verifRadiusGround = 0.3f;


    void Update()
    {
        direction = Input.GetAxisRaw("Horizontal");
        dashInput = Input.GetAxisRaw("dash");
    }

    private void FixedUpdate()
    {
        characterDash();
    }

    void characterDash()
    {
        //Activation du dash
        if (Input.GetAxisRaw("dash") > 0 && isDashing == false)
        {
            isDashing = true;

            //droite
            if(direction > 0)
            {
                body.MovePosition((Vector2)transform.position + new Vector2(100, 0) * dashForce * 1 * Time.deltaTime);
            }
            //gauche
            else if(direction < 0)
            {
                body.MovePosition((Vector2)transform.position + new Vector2(100, 0) * dashForce * -1 * Time.deltaTime);
            }

            dashTime = dashTimer;
        }

        //ne peux plus dash (reload)
        if (isDashing == true)
        {
            dashTime -= Time.deltaTime;
        }

        //peux à nouveau dash
        if (dashTime <= 0)
        {
            //dash réactivable
            isDashing = false;
        }

    }
}
