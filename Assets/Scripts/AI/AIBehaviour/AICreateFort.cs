using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICreateFort : AICreateHQ
{
    // Start is called before the first frame update
    void Start()
    {
        support = gameObject.GetComponent<AISupport>();

        buildingPrefab = support.Faction.BuildingPrefabs[2];
        buildingGhostPrefab = support.Faction.GhostBuildingPrefabs[2];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool CheckIfAnyUnFinishBuilding()
    {
        foreach (GameObject houseObj in support.Houses)
        {
            Building h = houseObj.GetComponent<Building>();

            if (!h.IsFunctional && (h.CurHP < h.MaxHP)) //This house is not yet finished
                return true;
        }

        foreach (GameObject barrackObj in support.Barracks)
        {
            Building b = barrackObj.GetComponent<Building>();

            if (!b.IsFunctional && (b.CurHP < b.MaxHP)) //This barrack is not yet finished
                return true;
        }

        foreach (GameObject fortObj in support.Fort)
        {
            Building b = fortObj.GetComponent<Building>();

            if (!b.IsFunctional && (b.CurHP < b.MaxHP)) //This fort is not yet finished
                return true;
        }
        return false;
    }

    public override float GetWeight()
    {
        Building b = buildingPrefab.GetComponent<Building>();

        if (!support.Faction.CheckBuildingCost(b)) //Don't have enough resource to build a fort
            return 0;

        if (CheckIfAnyUnFinishBuilding()) //Check if there is any unfinished building
            return 0;

        if (support.Barracks.Count >= 2 && support.Houses.Count > 0) // If there are enough barrack and some house
            return 2;

        return 0;
    }
}
