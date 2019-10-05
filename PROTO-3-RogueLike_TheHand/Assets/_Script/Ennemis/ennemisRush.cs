using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemisRush : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform mySelf;
    [SerializeField] private float speed;
    [SerializeField] private float detectingDistance;

    private void Update()
    {
        //Si la cible est assez proche
        if (Vector2.Distance(transform.position, target.position) < detectingDistance)
        {
            //Rush B !!! go ! go ! go !
            mySelf.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
