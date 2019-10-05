using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackForward : MonoBehaviour
{
    //source de l'attaque
    [SerializeField] private Transform attackFrom;
    //l'attaque en elle même
    [SerializeField] private GameObject attackSpawn1, attackSpawn2, attackSpawn3;


    //l'input
    [SerializeField] protected float verticalInput = 0;
    [SerializeField] private float attackLightInput = 0;
    
    //paramètre de l'attaque
    [SerializeField] private bool isAttacking1 = false, isAttacking2 = false, isAttacking3 = false;

    [SerializeField] private float frontAttackTimer1 = 0.2f, frontAttackTime1 = 0.0f;
    [SerializeField] private float frontAttackTimer2 = 0.2f, frontAttackTime2 = 0.0f;
    [SerializeField] private float frontAttackTimer3 = 0.3f, frontAttackTime3 = 0.0f;

    //pour animer
    public Animator animator;

    void Update()
    {
        attackLightInput = Input.GetAxisRaw("attackFaible");
        verticalInput = Input.GetAxisRaw("Vertical");

        attackApparition();
    }

    void attackApparition()
    {
        if ( verticalInput < 0.5 && verticalInput > -0.5 && attackLightInput > 0 && isAttacking1 == false)
        {
            Instantiate(attackSpawn1, attackFrom);

            frontAttackTime1 = frontAttackTimer1;
            frontAttackTime2 = frontAttackTimer2;
            frontAttackTime3 = frontAttackTimer3;

            isAttacking1 = true;
        }
        //ne peux plus attaquer (reload)
        if (isAttacking1 == true)
        {
            frontAttackTime1 -= Time.deltaTime;
        }
        //peux à nouveau attack1
        if (frontAttackTime1 <= 0)
        {
            //dash réactivable
            isAttacking1 = false;
        }

    }
}
