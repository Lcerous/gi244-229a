using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera cam;

    [Header("Move")]
    [SerializeField] private float moveSpeed;

    [SerializeField] private float xInput;
    [SerializeField] private float zInput;

    public static CameraController instance;

    void Awake()
    {
        instance = this;
        cam = Camera.main;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 50;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveByKB()
    {
        xInput = Input.GetAxis("Horizontral");
        zInput = Input.GetAxis("Vertical");
    }
}