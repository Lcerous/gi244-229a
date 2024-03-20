using System;
using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;


public class Building : Structure
{

    [SerializeField] private Transform spawnPoint;
    public Transform SpawnPoint { get { return spawnPoint; } }
    [SerializeField] private Transform rallyPoint;
    public Transform RallyPoint { get { return rallyPoint; } }

    [SerializeField] private GameObject[] unitPrefabs;
    public GameObject[] UnitPreFab { get { return unitPrefabs; } }

    [SerializeField] private List<Unit> recruitList = new List<Unit>();

    [SerializeField] private float unitTimer = 0f;
    [SerializeField] private int curUnitProgress = 0;

    [SerializeField] private float curUnitWaitTime = 0f;

    [SerializeField] private bool isFunctional;
    public bool IsFunctional { get { return isFunctional; } set { isFunctional = value; } }

    [SerializeField] private bool isHQ;
    public bool IsHQ { get {  return isHQ; } }

    [SerializeField] private float intoTheGround = 5f;
    public float IntoTheGround { get { return intoTheGround; } }

    private float timer = 0f; //Constructing timer
    public float Timer { get { return timer; } set { timer = value; } }
    private float waitTime = 0.5f; //How fast it will be construct, higher is longer
    public float WaitTime { get { return waitTime; } set { waitTime = value; } }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
            ToCreateUnit(0);

        if ((recruitList.Count > 0) && (recruitList[0] != null))
        {
            unitTimer += Time.deltaTime;
            curUnitWaitTime = recruitList[0].UnitWaitTime;

            if (unitTimer >= curUnitWaitTime)
            {
                curUnitProgress++;
                unitTimer = 0f;

                if (curUnitProgress >= 100)
                {
                    curUnitProgress = 0;
                    curUnitWaitTime = 0f;
                    CreateUnitCompleted();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.H))
            ToCreateUnit(1);

        if ((recruitList.Count > 0) && (recruitList[1] != null))
        {
            unitTimer += Time.deltaTime;
            curUnitWaitTime = recruitList[1].UnitWaitTime;

            if (unitTimer >= curUnitWaitTime)
            {
                curUnitProgress++;
                unitTimer = 0f;

                if (curUnitProgress >= 100)
                {
                    curUnitProgress = 0;
                    curUnitWaitTime = 0f;
                    CreateUnitCompleted();
                }
            }
        }

        /*switch (unitPrefabs.ToString()) 
        {
            case UnitState.MoveToBuild:
                MoveToBuild(inProguessBuilding);
                break;

            case UnitState.BuildProguess:
                BuildingProguess();
                break;
        }*/
    }



    public void ToCreateUnit(int i)
    {
        Debug.Log(structureName + " creates " + i + ":" + unitPrefabs.Length);
        if (unitPrefabs.Length == 0)
            return;

        if (unitPrefabs[i] == null)
            return;

        Unit unit = unitPrefabs[i].GetComponent<Unit>();

        if (unit == null)
            return;

        if (!faction.CheckUnitCost(unit)) //not enough resources
            return;

        //Deduct Resource
        faction.DeductUnitCost(unit);

        //If it's me, update UI
        if (faction == GameManager.instance.MyFaction)
            MainUI.instance.UpdateAllResource(faction);

        //Add unit into faction's recruit list
        recruitList.Add(unit);

        Debug.Log("Adding" + i + "to Recruit List");
    }

    public void CreateUnitCompleted()
    {
        int id = recruitList[0].ID;

        if (unitPrefabs[id] == null)
            return;

        GameObject unitObj = Instantiate(unitPrefabs[id], spawnPoint.position, Quaternion.Euler(0f, 180f, 0f));

        recruitList.RemoveAt(0);

        Unit unit = unitObj.GetComponent<Unit>();
        //unit.faction;
        unit.MoveToPosition(rallyPoint.position); //Go to Rally Point

        //Add unit into faction's Army
        faction.AliveUnits.Add(unit);

        Debug.Log("Unit Recruited");
        //If it's me, update UI
        if (faction == GameManager.instance.MyFaction)
            MainUI.instance.UpdateAllResource(faction);
    }

    public void ToggleSelectionVisual(bool flag)
    {
        if (SelectionVisual != null)
            SelectionVisual.SetActive(flag);
    }

    /*private void BuildProgress()
    {
        /*if (inProgressBuilding == null)
            return;

        unit.LookAt(inProgressBuilding.transform.position);
        Building b = inProgressBuilding.GetComponent<Building>();

        //building is already finished
        if ((b.CurHP >= b.MaxHP) && b.IsFunctional)
        {
            inProgressBuilding = null; //Clear this job off his mind
            unit.SetState(UnitState.Idle);
            return;
        }
        //constructing
        b.Timer += Time.deltaTime;

        if (b.Timer >= b.WaitTime)
        {
            b.Timer = 0;
            b.CurHP++;

            if (b.IsFunctional == false) //if this building is being built, not being fixed
                //Raise up building from the ground
                inProgressBuilding.transform.position += new Vector3(0f, b.IntoTheGround / (b.MaxHP - 1), 0f);

            if (b.CurHP >= b.MaxHP) //finish
            {
                b.CurHP = b.MaxHP;
                b.IsFunctional = true;

                inProgressBuilding = null; //Clear this job off his mind
                unit.SetState(UnitState.Idle);
            }

        }
    }*/

        
    

    /*private void OnTriggerStay(Collider other)
    {
        if (unit.State == UnitState.Die)
            return;

        if (unit != null)
        {
            if (other.gameObject == inProgressBuilding)
            {
                unit.NavAgent.isStopped = true;
                unit.SetState(UnitState.BuildProgress);
            }
        }
    }*/

    /*private void OnDestroy()
    {
        if (ghostBuilding != null)
            Destroy(ghostBuilding);
    }*/



}




