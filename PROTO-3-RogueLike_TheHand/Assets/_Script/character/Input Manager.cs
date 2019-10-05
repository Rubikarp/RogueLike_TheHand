using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //pour voir les input
    [SerializeField] protected float inputDirection = 0;
    [SerializeField] protected float inputAxisX = 0, inputAxisY = 0;
    [SerializeField] protected float inputJump = 0 ,inputMove = 0;
    [SerializeField] protected float inputAttackLight = 0, inputAttackHeavy = 0;
    //En contacte avec le sol ?
    [SerializeField] protected bool isOnGround = false, isOnWall = false;

    public void Update()
    {
        
        inputAxisX = Input.GetAxis("Horizontal");
        inputAxisY = Input.GetAxis("Vertical");


    }

}
