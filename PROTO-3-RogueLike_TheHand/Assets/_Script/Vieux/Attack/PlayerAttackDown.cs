using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackDown : MonoBehaviour
{
    //pour mettre de la physique dessus
    [SerializeField] private Rigidbody2D body;

    //pour voir l'input
    [SerializeField] protected float verticalInput = 0;
    [SerializeField] private float attackHeavyInput = 0;

    //Paramètre du saut
    [SerializeField] private float jumpForce = 1.4f;

    //source de l'attaque
    [SerializeField] private Transform attackFrom;
    //l'attaque en elle même
    [SerializeField] private GameObject attackSpawn;

    //paramètre de l'attaque
    [SerializeField] private bool isAttackingHeavy = false;
    [SerializeField] private float heavyDownAttackTimer = 0.3f;
    private float heavyDownAttackTime = 0.0f;

    void Update()
    {
        attackHeavyInput = Input.GetAxisRaw("attackForte");
        verticalInput = Input.GetAxisRaw("Vertical");

        attackHeavyDown();
    }

    void attackHeavyDown()
    {
        //saut complet (condition : touche le sol, input , n'est pas en saut)
        if (attackHeavyInput > 0 && verticalInput < 0 && isAttackingHeavy == false)
        {
            isAttackingHeavy = true;

            //attack
            Instantiate(attackSpawn, attackFrom);
            //jump
            body.velocity = new Vector2(0, -10 * jumpForce);

            heavyDownAttackTime = heavyDownAttackTimer;
        }

        //ne peux plus attaquer (reload)
        if (isAttackingHeavy == true)
        {
            heavyDownAttackTime -= Time.deltaTime;
        }

        //peux à nouveau dash
        if (heavyDownAttackTime <= 0)
        {
            //dash réactivable
            isAttackingHeavy = false;
        }

    }
}
