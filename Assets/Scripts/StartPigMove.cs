using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPigMove : MonoBehaviour
{
    public GameObject pig;

    // Start is called before the first frame update
    public void Start()
    {
        Instantiate(pig, transform.position, Quaternion.identity);
    }

}
