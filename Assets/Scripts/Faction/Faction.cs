using System.Collections;
using System.Collections.Generic;
//using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class Faction : MonoBehaviour
{
    public enum Nation
    {
        Natural = 0,
        Britain,
        Pirates,
        France,
        Spain,
        Portuese,
        Dutch

    }

    [SerializeField] private Nation nation;
    //public Nation Nation {  get { return nation; } }

    public Nation GetNation()
    { return nation; }

    [Header("Resources")]
    [SerializeField] private int food;
    public int Food { get { return food; } set { food = value; } }
    [SerializeField] private int wood;
    public int Wood { get { return wood; } set { wood = value; } }
    [SerializeField] private int gold;
    public int Gold { get { return gold; } set { gold = value; } }
    [SerializeField] private int stone;
    public int Stone { get {  return stone; } set {  stone = value; } }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
