using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class SpawnNote : MonoBehaviour
{
    [SerializeField]private GameObject prefab;
    [SerializeField]private GameObject parent;
    [SerializeField]private Vector2 spawnPos;
    [SerializeField]private bool random;
    private Random rand1 = new Random();

    public BeatScan theNT;

    // void Update() {
    //     if(theNT.bass){
    //         float x = Random.Range(-8,8);
    //         float y = Random.Range(-4,4);

    //         Instantiate(prefab, new Vector2(x, y), Quaternion.identity);
    //     }
    // }
    public void OnSpawnPrefab(){
        if (random)
        {
            var arr1 = new[]{-1.5f, -0.5f, 0.5f, 1.5f};
            float x = arr1[rand1.Next(arr1.Length)];
            float y = 9.5f;
            Instantiate(prefab, new Vector2(x, y), Quaternion.identity, parent.transform);
        }
        else
        {
            Instantiate(prefab, spawnPos, Quaternion.identity, parent.transform);
        }
    }
}
