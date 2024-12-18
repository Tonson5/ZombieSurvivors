using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Slow()
    {
        Time.timeScale = 0.3f;
    }
    public void Normal()
    {
        Time.timeScale = 1;
    }
}
