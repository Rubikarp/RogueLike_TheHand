using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvRun : MonoBehaviour
{
    //pour mettre de la physique dessus
    [SerializeField] private Rigidbody2D body;

    //pour animer
    public Animator animator;

    //qu'est ce qui est considéré comme le sol ?
    public LayerMask isEnvironnement;

    //pour voir les input
    [SerializeField] protected float moveInput = 0;

    //Paramètre de course
    [SerializeField] private float speed = 10f;
    [SerializeField] private float airControl = 0.5f;
    [SerializeField] private float groundControl = 1f;

    //En contacte avec le sol ?
    public bool isOnGround = false;
    //pour vérifier s'il touche le sol 
    [SerializeField] private Transform posDetectGround;
    private float verifRadiusGround = 0.3f;


    private void Update()
    {
        //valeur de -1 à 1 sur Project/setting/input/horizontal
        moveInput = Input.GetAxis("Horizontal");

        //verif si perso touche le sol
        isOnGround = Physics2D.OverlapCircle(posDetectGround.position, verifRadiusGround, isEnvironnement);

        animator.SetFloat("running", Mathf.Abs(moveInput));
    }

    private void FixedUpdate()
    {
        characterRun();
    }

    void characterRun()
    {
        if (Mathf.Abs(moveInput) >= 0.3)
        {
            //la course
            if (isOnGround == true)
            {
                //valeur traduite en force sur l'objet qui a le script
                body.velocity = new Vector2(groundControl * speed * moveInput, body.velocity.y);
            }
            else
            {
                //valeur traduite en force sur l'objet qui a le script
                body.velocity = new Vector2(airControl * speed * moveInput, body.velocity.y);
            }
        }
    }
    
}
