using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerLoaderManager : MonoBehaviour
{
    public static PlayerLoaderManager Instance;

    public List<GameObject> aiKarts;
    public List<Transform> startingPositions;
    public GameObject playerKart;

    private void Awake()
    {
        if (Instance == null) 
            Instance = this;
        else 
            Destroy(gameObject);

        //startingPositions = GetComponentsInChildren<Transform>().ToList();
        
        //playerKart = Instantiate(Resources.Load("Karts/DuckKart", typeof(GameObject))) as GameObject;
        //playerKart.transform.position = startingPositions[11].transform.position;
        //playerKart.transform.rotation = startingPositions[11].transform.rotation;

        /*if(aiKarts[0] != null)
            Instantiate(aiKarts[0], startingPositions[0].transform.position, startingPositions[0].transform.rotation);
        if(aiKarts[1] != null)
            Instantiate(aiKarts[1], startingPositions[1].transform.position, startingPositions[1].transform.rotation);
        if(aiKarts[2] != null)
            Instantiate(aiKarts[2], startingPositions[2].transform.position, startingPositions[2].transform.rotation);
        if(aiKarts[3] != null)
            Instantiate(aiKarts[3], startingPositions[3].transform.position, startingPositions[3].transform.rotation);
        if(aiKarts[4] != null)
            Instantiate(aiKarts[4], startingPositions[4].transform.position, startingPositions[4].transform.rotation);
        if(aiKarts[5] != null)
            Instantiate(aiKarts[5], startingPositions[5].transform.position, startingPositions[5].transform.rotation);
        if(aiKarts[6] != null)
            Instantiate(aiKarts[6], startingPositions[6].transform.position, startingPositions[6].transform.rotation);
        if(aiKarts[7] != null)
            Instantiate(aiKarts[7], startingPositions[7].transform.position, startingPositions[7].transform.rotation);
        if(aiKarts[8] != null)
            Instantiate(aiKarts[8], startingPositions[8].transform.position, startingPositions[8].transform.rotation);
        if(aiKarts[9] != null)
            Instantiate(aiKarts[9], startingPositions[9].transform.position, startingPositions[9].transform.rotation);
        if(aiKarts[10] != null)
            Instantiate(aiKarts[10], startingPositions[10].transform.position, startingPositions[10].transform.rotation);*/

    }
}