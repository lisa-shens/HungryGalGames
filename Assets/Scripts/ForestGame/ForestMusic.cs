using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestMusic : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicIntro>().StopMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}