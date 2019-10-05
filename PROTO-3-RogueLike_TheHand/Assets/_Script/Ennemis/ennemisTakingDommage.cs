using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemisTakingDommage : MonoBehaviour
{

    //fonction est-ce que je me suis fait touché ?
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("damage"))
        {
            Debug.LogWarning("ouuille");

            //prend des dégats (en vrai il se fait insta-kill mais chuut
            Destroy(this.gameObject);
        }
    }
}
