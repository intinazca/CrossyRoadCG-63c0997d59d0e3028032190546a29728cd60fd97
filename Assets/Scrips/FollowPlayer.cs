using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject Player; //el objeto que recibe la escip que tiene la capara para saber a quien sigue
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothness;

    void Start()
    {//sigue al jugador en cada frame, por eso se pone en el star
       // transform.position = player.transform.position + offset;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Player.transform.position + offset, smoothness);
    }
}
