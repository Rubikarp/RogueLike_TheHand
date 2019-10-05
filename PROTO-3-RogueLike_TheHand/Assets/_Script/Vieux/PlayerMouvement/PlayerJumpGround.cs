using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpGround : MonoBehaviour
{
    //pour mettre de la physique dessus
    [SerializeField] private Rigidbody2D body;

    //qu'est ce qui est considéré comme environnement ?
    public LayerMask isEnvironnement;

    //pour animer
    public Animator animator;

    //pour voir l'input
    [SerializeField] protected float jumpInput = 0;

    //Paramètre du saut
    [SerializeField] private float jumpForce = 1.8f;
    [SerializeField] private bool isJumping = false;
    [SerializeField] private float jumpTimer = 0.3f;
    [SerializeField] private float jumpTime = 0.0f;

    //En contacte avec le sol ?
    public bool isOnGround = false;
    //pour vérifier s'il touche le sol 
    [SerializeField] private Transform posDetectGround;
    private float verifRadiusGround = 0.3f;

    void Update()
    {
        jumpInput = Input.GetAxisRaw("Saut");

        //verif si perso touche le sol
        isOnGround = Physics2D.OverlapCircle(posDetectGround.position, verifRadiusGround, isEnvironnement);

        animator.SetFloat("VelocityY", body.velocity.y);
    }

    private void FixedUpdate()
    {
        characterJumpGround();
    }

    
    void characterJumpGround()
    {
        //saut complet (condition : touche le sol, input , n'est pas en saut)
        if (isOnGround == true && jumpInput > 0 && isJumping == false)
        {
            isJumping = true;
            body.velocity = new Vector2(0, 10 * jumpForce);
            jumpTime = jumpTimer;
        }

        if(isJumping == true)
        {
            jumpTime -= Time.deltaTime;


        }
        
        //s'il retouche le sol, il peut sauter à nouveau
        if (isOnGround == true )
        {
            isJumping = false;
        }

    }
}
