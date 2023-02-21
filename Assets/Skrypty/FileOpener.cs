using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileOpener : MonoBehaviour
{
    public string FinalPath;
    public static FileOpener instance;
    // private string FileType;

    // void Start(){
    //     instance = this;
    //     FileType = NativeFilePicker.ConvertExtensionToFileType("*");
    // }
    public void LoadFile(){
        instance = this;
        string FileType = NativeFilePicker.ConvertExtensionToFileType("mp3");

        NativeFilePicker.Permission permission = NativeFilePicker.PickFile((path) =>
        {
            if(path == null)
                Debug.Log("Operation cancelled");
            else{
                FinalPath = path;
                Debug.Log("Picked file: "+ FinalPath);
            }
        }, new string[] {FileType}); 
    }

}
