using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTest : MonoBehaviour
{
    public SaveObject so;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            SaveManager.Save(so);
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            so = SaveManager.Load();
        }
    }
}
