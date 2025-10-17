using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoSpawner : MonoBehaviour
{
    public Transform ObstaculoPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawnar", 0f, 2f); 
    }

    // Update is called once per frame
    void Spawnar()
    {
        Instantiate(ObstaculoPrefab, new Vector2(12f, -3.1f), Quaternion.identity);
    }
}
