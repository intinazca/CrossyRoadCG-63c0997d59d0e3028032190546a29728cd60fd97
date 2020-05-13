using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
public class generadorTerreno : MonoBehaviour
{
    [SerializeField] private int minDistanceFromPlayer;
    [SerializeField] private int maxTerrainCount;
    //creamos una lista que va almacenar objetos del juego que son las partes del terreno
    [SerializeField] private List<TerrainData> terrainDatas = new List<TerrainData>();
    [SerializeField] private Transform terrainHolder; // este es el pivote sobre el cual se empieza a generar el terreno
    //creamos un objeto de tipo vector que inicia en la posicion 0,0,0 y es la direccion a donde se nos va a generar el terreno
    private List<GameObject> currentTerrains = new List<GameObject>();  //creamos una lista de tipo gameobject que va a guardar el terreno actual
    [HideInInspector] public Vector3 currentPosition = new Vector3(0, 0, 0);

    private void Start()
    {
        //usamos el for para recorrer el array del contador de terreno maximo
        for (int i = 0; i < maxTerrainCount; i++)
        {
            SpawnTerrain(true, new Vector3(0,0,0));
        }
        maxTerrainCount = currentTerrains.Count;
    }

    public void SpawnTerrain( bool isStart, Vector3 playerPos)
    {
       
        if ((currentPosition.x - playerPos.x < minDistanceFromPlayer) || (isStart))// genera terreno a la par del movimiento, corrige el proble del desface
        {
            int whichTerrain = UnityEngine.Random.Range(0, terrainDatas.Count);
            int terrainInSuccession = UnityEngine.Random.Range(1, terrainDatas[whichTerrain].maxInSuccession);
            for (int i = 0; i < terrainInSuccession; i++)
            {
                GameObject terrain = Instantiate(terrainDatas[whichTerrain].terrain, currentPosition, Quaternion.identity, terrainHolder);
                currentTerrains.Add(terrain);
                if (!isStart)
                {
                    if (currentTerrains.Count > maxTerrainCount)
                    {
                        Destroy(currentTerrains[0]);
                        currentTerrains.RemoveAt(0);
                    }
                }

                currentPosition.x++;
            }
        }

        /*
        //  instaciamos el terrenoo como tipo game object y lo generamos de manera ramdom en un rango determinado y se va astar actualizando en  currentTerrains
        GameObject terrains = Instantiate(terrains[Random.Range(0, terrains.Count)], currentPosition, Quaternion.identity);
        currentTerrains.Add(terrains);
        //el siguiente if es para que cada que cree terreno, vaya destruyendo el que va quedando atras, esto se hace para no saturar la maquina
        if (currentTerrains.Count > maxTerrainCount)
        {
           Destroy(currentTerrains[0]);
            currentTerrains.RemoveAt(0);
        }
        currentPosition.x++;
       */
    }
}
