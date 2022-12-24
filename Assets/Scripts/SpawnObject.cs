using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Vector2 minPosition;
    public Vector2 maxPosition;
    public float x_pos;
    public float y_pos;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 randomPosition = new Vector2(
        Random.Range(minPosition.x, maxPosition.x),
        Random.Range(minPosition.y, maxPosition.y)
        );
        Vector2 newObjectPosition = new Vector2(x_pos,y_pos);
        Instantiate(objectToSpawn, newObjectPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
