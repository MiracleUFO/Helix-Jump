using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixManager : MonoBehaviour
{
    public GameObject[] helixRings;
    public float ySpawn = 0;
    public float ringsDistance =  5;
    public int noOfRings = 7;

    void Start()
    {
        for (int i = 0; i < noOfRings; i++) {
            if (i == 0) {
                SpawnHelixRings(0);
            } else if (i == (noOfRings - 1)) {
                SpawnHelixRings(helixRings.Length - 1);
            } else {
                SpawnHelixRings(Random.Range(0, helixRings.Length - 1));
            }
        }
    }

    void Update()
    {

    }

    public void SpawnHelixRings(int ringIndex) {
        GameObject ring = Instantiate(helixRings[ringIndex], transform.up * ySpawn, Quaternion.identity);
        ring.transform.parent = transform;
        ySpawn -= ringsDistance;
    }
}
