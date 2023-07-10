using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public Transform spawnsHolder;
    public GameObject prefab;
    public float spawnHeight;
    float positionX;
    float positionZ;
    public int row = 1;
    public int column = 1;
    public float spacing = 2;
    public float spawnInterval;
    public Transform spawnPosition;

    private float offsetX;
    private float offsetZ;


    int x, z;
    private void Awake()
    {
        offsetToSpawnSymmetricallyAroundSpawnPos(row, column);
    }

    void Start () {
        
        positionX = spawnPosition.position.x;
        positionZ = spawnPosition.position.z;
        x = z = 0;
        
        if (spawnInterval == 0f)
        {
            for ( ; z < row; z++)
            {
                for ( ; x < column; x++)
                {
                    spawnSettings();
                }
                x = 0;
            }
        }
        else
        {
            InvokeRepeating("spawnObject", 1f, spawnInterval);
        }
        
	}
	
    public void offsetToSpawnSymmetricallyAroundSpawnPos(int rowZ, int columnX)
    {
        if(columnX > 1)
        {
            offsetX = (columnX - 1) / 2 * spacing;
        }
        if (rowZ > 1)
        {
            offsetZ = (rowZ - 1) / 2 * spacing;
        }
    }

    void spawnObject()
    {
        spawnSettings();
        x++;
        if(x > column - 1)
        {
            x = 0;
            z++;
        }
        if(z > row - 1)
        {
            CancelInvoke();
        }
    }

    void spawnSettings()
    {
        GameObject character = Instantiate(prefab, new Vector3(positionX - offsetX + x * spacing, spawnHeight, positionZ - offsetZ + z * spacing), prefab.transform.rotation);
        character.transform.parent = spawnsHolder;
        
    }

    private void OnDrawGizmos()
    {
        offsetToSpawnSymmetricallyAroundSpawnPos(row, column);
        Gizmos.color = Color.red;
        Vector3 offsetVector = new Vector3(spacing, 0, spacing) / 2;
        Gizmos.DrawWireCube(spawnPosition.position + offsetVector + Vector3.up, new Vector3(column * spacing, 1 ,row * spacing)) ;
    }
}
