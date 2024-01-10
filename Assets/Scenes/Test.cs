using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    private GameObject[] GameObjects;

    [SerializeField] private List<int> i = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        i.Add(10);
        i.Add(40);
        i.Add(720);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
