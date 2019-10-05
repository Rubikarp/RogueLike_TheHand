using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomDecor : MonoBehaviour
{
    //liste des éléments qui peuvent apparraitre
    public GameObject[] objects;
    public Transform me;

    void Start()
    {
        //je prends un chiffre random pour décider quel object va apparaitre
        int rand = Random.Range(0, objects.Length);

        //invocations de l'object
        Instantiate(objects[rand], me);
    }
}
