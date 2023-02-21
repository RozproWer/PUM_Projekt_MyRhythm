using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AddPath : MonoBehaviour
{
    private AudioSource audio;

    private void Start(){
        Debug.Log("costo : "+ FileOpener.instance.FinalPath);
        audio = this.GetComponent<AudioSource>();
        StartCoroutine(LoadAudio());
    }

    private IEnumerator LoadAudio(){
        string fullpath = "file://" + FileOpener.instance.FinalPath;
        WWW url = new WWW(fullpath);
        yield return url;

        audio.clip = url.GetAudioClip(false, true);
    }
}
