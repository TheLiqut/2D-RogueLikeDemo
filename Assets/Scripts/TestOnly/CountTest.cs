using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountTest : MonoBehaviour
{
    public List<string> tester = new List<string>();

    void Start()
    {
        Debug.Log(tester.Count.ToString());
    }

    void Update()
    {
        
    }
}
