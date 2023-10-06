using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestMusic : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("IntroMusic").GetComponent<MusicIntro>().StopMusic();
    }
}