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
    //remember this "Fation" is Nation
    public Nation Fation {  get { return nation; } }

    [SerializeField] private Transform unitsParent;
    public Transform UnitsParent { get { return unitsParent; } }

    [SerializeField] private Transform buildingsParent;
    public Transform BuildingsParent { get { return buildingsParent; } }

    [SerializeField] private Transform ghostBuildingParent;
    public Transform GhostBuildingParent { get { return ghostBuildingParent; } }


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

    [SerializeField] private List<Unit> aliveUnits = new List<Unit>();
    public List<Unit> AliveUnits { get { return aliveUnits; } }

    [SerializeField] private Faction myFaction;
    public Faction MyFaction { get { return myFaction; } }

    [SerializeField] private Faction enemyFaction;
    public Faction EnemyFaction { get { return enemyFaction; } }

    //All factions in this game (2 factions for now)
    [SerializeField] private Faction[] factions;

    public static GameManager instance;

    [SerializeField] private List<Building> aliveBuildings = new List<Building>();
    public List<Building> AliveBuildings { get { return aliveBuildings; } }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CheckUnitCost(Unit unit)
    {
        if (food < unit.UnitCost.food)
            return false;

        if (wood < unit.UnitCost.wood)
            return false;

        if (gold < unit.UnitCost.gold)
            return false;

        if (stone < unit.UnitCost.stone)
            return false;

        return true;
    }

    public void DeductUnitCost(Unit unit)
    {
        food -= unit.UnitCost.food;
        wood -= unit.UnitCost.wood;
        gold -= unit.UnitCost.gold;
        stone -= unit.UnitCost.stone;
    }

    public bool IsMyUnit(Unit u)
    {
        return aliveUnits.Contains(u);
    }

    public bool IsMyBuilding(Building b)
    {
        return aliveBuildings.Contains(b);
    }

    //temp Change Building to Sturcture for making it work

    /*public bool CheckBuildingCost(Building Structure)
    {
        if (food < Structure.StructureCost.food)
            return false;

        if (wood < Structure.StructureCost.wood)
            return false;

        if (gold < Structure.StructureCost.gold)
            return false;

        if (stone < Structure.StructureCost.stone)
            return false;

        return true;
    }*/

    /*public void DeductBuildingCost(Building Structure)
    {
        food -= Structure.StructureCost.food;
        wood -= Structure.StructureCost.wood;
        gold -= Structure.StructureCost.gold;
        stone -= Structure.StructureCost.stone;
    }*/




}
