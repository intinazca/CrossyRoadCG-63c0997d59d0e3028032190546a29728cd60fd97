using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private generadorTerreno generadorTerreno;
    private Animator animator;
    private bool isHopping;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {// si se aprieta la tecla W el animator llama a la animacion de salto
        if (Input.GetKeyDown(KeyCode.W) && !isHopping)
        {   //con esto hace la animacion de salto
            animator.SetTrigger("Hop");
            isHopping = true; 
            float zDifference = 0;
            //con esto le indicamos el eje en donde queremos que se desplace con la tecla W
            if (transform.position.z % 1 != 0)
            {
                // por cada pulso de la tecla W, se desplaza una unidad en el eje z
                zDifference = Mathf.Round(transform.position.z) - transform.position.z;
                //transform.position = (transform.position + new Vector3(1, 0, 0));
            }
            MoveCharacter(new Vector3(1, 0, zDifference));
        }
        //para movernos al usal la tecla A
        else if (Input.GetKeyDown(KeyCode.A) && !isHopping)
        {
            MoveCharacter(new Vector3(0, 0, 1));
        }
        //para movernos al usal la tecla D
        else if (Input.GetKeyDown(KeyCode.D) && !isHopping)
        {
            MoveCharacter( new Vector3(0, 0, -1));
        }
    }

    private void MoveCharacter(Vector3 difference)
    {
        animator.SetTrigger("Hop");
        isHopping = true;
        transform.position = (transform.position + difference);
        generadorTerreno.SpawnTerrain(false, transform.position);
      
            
    }

    public void FinishHop()
    {
        isHopping = false;
    }
}

