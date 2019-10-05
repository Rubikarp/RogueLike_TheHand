using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    //l'élément que je déplace
    [SerializeField] protected Rigidbody2D body;

    //Vitesse du personnage
    public float speed = 5f;
    public float airControl = 0.5f;
    public float groundControl = 1f;

    //puissance du dash
    public float dashPower = 12f;
    //La durée du dash
    public float dashTime = 0.1f;
    private float dashTimer = 0f;
    //la période durant laquelle on ne peut plus dash
    public bool isDashing = false;
    public float dashInputTimer = 2f;
    public float dashInputTime = 0f;

    //pour voir l'input horizontal
    [SerializeField] protected float moveInput = 0;


    void FixedUpdate()
    {
        characterLookAhead();
        characterRun();
        characterDash();
    }

    void characterRun()
    {
        //valeur de -1 à 1 sur Project/setting/input/horizontal
        moveInput = Input.GetAxis("course");
        
        //valeur traduite en force sur l'élément qui a le script
        body.velocity = new Vector2(speed * moveInput * groundControl, body.velocity.y);

    }

    void characterDash()
    {
        //reçois l'input et dash
        if (Input.GetKeyDown(KeyCode.E) && isDashing == false)
        {
            dashTime = dashTimer;
            body.velocity = new Vector2 (body.velocity.x + dashPower, body.velocity.y);
            isDashing = true;
        }
        //est ce que je dash ?
        if(isDashing == true)
        {
            //durée du dash
            dashTime -= Time.deltaTime;
            //l'heure de reset
            if (dashTime < 0)
            {
                body.velocity = Vector2.zero;
                isDashing = false;

            }
        }
    }

    void characterLookAhead()
    {
        //regarder devant quand je vais vers la droite
        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        //regarder devant quand je vais vers la gauche
        else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }
}