using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackLightUp : MonoBehaviour
{
    //source de l'attaque
    [SerializeField] private Transform attackFrom;
    //l'attaque en elle même
    [SerializeField] private GameObject attackSpawn;
    //l'input
    [SerializeField] protected float verticalInput = 0;
    [SerializeField] private float attackLightInput = 0;

    //paramètre de l'attaque
    [SerializeField] private bool isAttacking = false;
    [SerializeField] private float frontAttackTimer = 0.3f;
    private float frontAttackTime = 0.0f;

    void Update()
    {
        attackLightInput = Input.GetAxisRaw("attackFaible");
        verticalInput = Input.GetAxisRaw("Vertical");

        attackApparition();
    }

    void attackApparition()
    {
        if (verticalInput > 0.3  && attackLightInput > 0 && isAttacking == false)
        {
            Instantiate(attackSpawn, attackFrom);

            frontAttackTime = frontAttackTimer;

            isAttacking = true;
        }

        //ne peux plus attaquer (reload)
        if (isAttacking == true)
        {
            frontAttackTime -= Time.deltaTime;
        }

        //peux à nouveau dash
        if (frontAttackTime <= 0)
        {
            //dash réactivable
            isAttacking = false;
        }

    }
}
