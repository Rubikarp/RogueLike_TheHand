using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemisRush : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform mySelf;
    [SerializeField] private float speed;
    [SerializeField] private float detectingDistance, tropProche;

    private void Update()
    {
        //Si la cible est assez proche pour etre detect mais pas tropProche non plus 
        if (detectingDistance > Vector2.Distance(transform.position, target.position) && tropProche < Vector2.Distance(transform.position, target.position))
        {
            //Rush B !!! go ! go ! go !
            mySelf.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }


        if(tropProche < Vector2.Distance(transform.position, target.position))
        {
            //attaque
        }
    }
}
