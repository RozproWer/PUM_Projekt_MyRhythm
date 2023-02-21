using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnAudio : MonoBehaviour
{
    public GameObject objectPrefab;
    public GameObject objectParent;
    public float spawnThreshold = 0.5f;
    [SerializeField]private Vector2 spawnPos;
    public int frequency = 0;
    public FFTWindow fftWindow;

    private float[] samples = new float[1024];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.GetSpectrumData(samples,0,fftWindow);
        if(samples[frequency] > spawnThreshold)
        {
            Instantiate(objectPrefab, spawnPos, Quaternion.identity, objectParent.transform);
        }    
    }
}
