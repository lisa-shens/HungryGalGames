using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class onAppleHIt : MonoBehaviour
{
    private int appleCount;
    private EndShowcase endShowcase;

    // Start is called before the first frame update
    void Start()
    {
        endShowcase = GameObject.Find("EndShowcase").GetComponent<EndShowcase>();
        appleCount = 8;
    }

    // Update is called once per frame
    public void onHit()
    {
        appleCount = appleCount - 1;
        print(appleCount);
        if (appleCount == 0)
        {
            endShowcase.end();
            
        }
        //Destroy(button);
    }


    // Detect mouse clicks on the GameObject
    void OnMouseDown()
    {
        onHit();
    }
}
