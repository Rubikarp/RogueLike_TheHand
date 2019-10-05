using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpWall : MonoBehaviour
{
    //pour mettre de la physique dessus
    [SerializeField] private Rigidbody2D body;

    //qu'est ce qui est considéré comme environnement ?
    public LayerMask isEnvironnement;

    //pour voir l'input
    [SerializeField] protected float direction = 0;
    [SerializeField] protected float jumpInput = 0;

    //Paramètre du saut
    [SerializeField] private float jumpForce = 1.8f;
    [SerializeField] private bool isJumping = false;
    [SerializeField] private float jumpWallTimer = 0.3f;
    [SerializeField] private float jumpWallTime = 0.0f;

    //En contacte avec le sol ?
    public bool isOnWall = false;
    //pour vérifier s'il touche le sol 
    [SerializeField] private Transform posDetectWall;
    private float verifRadiusWall = 0.1f;


    void Update()
    {
        jumpInput = Input.GetAxisRaw("jump");
        direction = Input.GetAxis("Horizontal");

        //verif si perso touche le sol
        isOnWall = Physics2D.OverlapCircle(posDetectWall.position, verifRadiusWall, isEnvironnement);
    }

    private void FixedUpdate()
    {
        characterJumpWall();
    }


    void characterJumpWall()
    {
        //saut complet (condition : touche le sol, input , n'est pas en saut)
        if (isOnWall == true && jumpInput > 0 && isJumping == false)
        {
            isJumping = true;
            body.velocity = new Vector2 (-direction * 50 , 10 * jumpForce);
            jumpWallTime = jumpWallTimer;
        }

        if (isJumping == true)
        {
            jumpWallTime -= Time.deltaTime;
        }

        //s'il retouche le sol, il peut sauter à nouveau
        if (isOnWall == true)
        {
            isJumping = false;
        }

    }
}
