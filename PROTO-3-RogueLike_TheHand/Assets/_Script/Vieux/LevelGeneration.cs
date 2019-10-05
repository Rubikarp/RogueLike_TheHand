using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    //pour avoir la position où l'on génère les salles
    [SerializeField] private Transform roomGenerator;
    //liste des salles qui peuvent apparaitre
    [SerializeField] private Transform roomsContainer;
    //liste des points de départ de la génération procedural
    [SerializeField] private Transform[] startingPos;
    //liste des salles qui peuvent apparaitre 
    [SerializeField] private GameObject staringRoom;
    [SerializeField] private GameObject[] roomsGbDb;
    [SerializeField] private GameObject[] roomsHcBc;
    [SerializeField] private GameObject[] roomsHcGc;
    [SerializeField] private GameObject[] roomsHcDc;
    [SerializeField] private GameObject[] roomsBcGb;
    [SerializeField] private GameObject[] roomsBcDb;

    //direction du générateur pour ce déplacer
    [SerializeField] private int direction;

    //nombre de salles générées
    private int roomCounter = 1;
    //nombre de salles que je veux générer 
    public int roomCounterLimite = 10;

    //écart entre les salles (dépend de la taille des salles)
    [SerializeField] private float moveIncrementHorizontal;
    [SerializeField] private float moveIncrementVertical;

    //temps entre l'apparition de chaque salle
    private float timeBtwSpawn = 0;
    [SerializeField] private float startTimeBtwSpawn = 0.25f;


    void Start()
    {
        //tire au sort un point de départ
        int randStartingPos = Random.Range(0, startingPos.Length);
        //place le generateur sur le point de départ
        roomGenerator.transform.position = startingPos[randStartingPos].position;
        //Génere la room 0 pour la première salle
        Instantiate(staringRoom, roomGenerator.position, Quaternion.identity, roomsContainer);

        //commence vers la droite (3 ou 4)
        direction = 3;
    }

    private void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            Move();
            timeBtwSpawn = startTimeBtwSpawn;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }

    private void Move()
    {
        //tant que toute les salles ne sont pas crée
        if (roomCounterLimite > roomCounter)
        {
            // variable direction donne : 1 ou 2 => gauche, 3 ou 4 => Droite, 5 => Bas (répartition des proba)

            // Gauche
            if (direction == 1 || direction == 2)
            {
                // bouge vers la gauche
                Vector2 pos = new Vector2(transform.position.x - moveIncrementHorizontal, transform.position.y);
                transform.position = pos;

                //pour ne pas revenir sur la salle
                direction = Random.Range(1, 6);
                while (direction == 3 || direction == 4)
                {
                    direction = Random.Range(1, 6);
                }

                //créer une salle qui se combine avec la prochaine
                if (direction == 5)
                {
                    Instantiate(roomsBcDb [Random.Range(0,roomsBcDb.Length)], roomGenerator.position, Quaternion.identity, roomsContainer);
                }
                else
                {
                    Instantiate(roomsGbDb [Random.Range(0, roomsGbDb.Length)], roomGenerator.position, Quaternion.identity, roomsContainer);
                }
            }
            //Droite
            else if (direction == 3 || direction == 4)
            {
                // bouge vers la droite
                Vector2 pos = new Vector2(transform.position.x + moveIncrementHorizontal, transform.position.y);
                transform.position = pos;

                //pour ne pas revenir sur la salle
                direction = Random.Range(1, 6);
                while (direction == 1 || direction == 2)
                {
                    direction = Random.Range(1, 6);
                }

                //créer une salle qui se combine avec la prochaine
                if (direction == 5)
                {
                    Instantiate(roomsBcGb [Random.Range(0, roomsBcGb.Length)], roomGenerator.position, Quaternion.identity, roomsContainer);
                }
                else
                {
                    Instantiate(roomsGbDb[Random.Range(0, roomsGbDb.Length)], roomGenerator.position, Quaternion.identity, roomsContainer);
                }

            }
            //Bas
            else if (direction == 5)
            {
                //bouge vers le bas
                Vector2 pos = new Vector2(transform.position.x, transform.position.y - moveIncrementVertical);
                transform.position = pos;

                //nouvelle direction
                direction = Random.Range(1, 5);

                //créer une salle qui se combine avec la prochaine
                if (direction == 5)
                {
                    Instantiate(roomsHcBc [Random.Range(0, roomsHcBc.Length)], roomGenerator.position, Quaternion.identity, roomsContainer);
                }
                else if (direction == 1 || direction == 2)
                {
                    Instantiate(roomsHcGc [Random.Range(0, roomsHcGc.Length)], roomGenerator.position, Quaternion.identity, roomsContainer);
                }
                else if (direction == 3 || direction == 4)
                {
                    Instantiate(roomsHcDc [Random.Range(0, roomsHcDc.Length)], roomGenerator.position, Quaternion.identity, roomsContainer);
                }
            }

            //incrémente le compteur de salle créées
            roomCounter = roomCounter + 1;
        }
        else
        {
            //fait apparaitre la dernière salle

        }

    }

}
