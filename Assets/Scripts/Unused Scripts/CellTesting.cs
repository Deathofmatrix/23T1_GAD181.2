using SheepGame.Chonnor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellTesting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //public void CheckAndChangeStats(bool isIncreasedOrDecreased)
    //{
    //    switch (buildingTypeScript.GetBuildingType())
    //    {
    //        case BuildingType.TypeOfBuilding.ClickIncrease:
    //            ChangeStoredClick(buildingTypeScript.GetBuildingClick(), isIncreasedOrDecreased);
    //            //gridManager.SetClickLevel(buildingTypeScript.GetBuildingClick(), isIncreasedOrDecreased);
    //            break;
    //        case BuildingType.TypeOfBuilding.SpawnIncreaser:
    //            //gManager.SetClickLevel(buildingTypeScript.GetBuildingClick(), isIncreasedOrDecreased);
    //            break;
    //        case BuildingType.TypeOfBuilding.AdjacencyBonus:
    //            foreach (GameObject adjacentCell in allAdjacentSquares)
    //            {
    //                if (adjacentCell != null)
    //                {
    //                    Cell adjacentCellScript = adjacentCell.GetComponent<Cell>();
    //                    BuildingType adjacentBuildingTypeScript = adjacentCellScript.GetBuildingTypeScript();

    //                    if (adjacentBuildingTypeScript != null && adjacentBuildingTypeScript.GetBuildingType() != BuildingType.TypeOfBuilding.AdjacencyBonus)
    //                    {
    //                        adjacentCellScript.ChangeStoredClick(buildingTypeScript.GetBuildingAdjacency(), isIncreasedOrDecreased);
    //                        //Debug.Log(adjacentCell.name);
    //                        //if (isIncreasedOrDecreased)
    //                        //{
    //                        //    gridManager.SetClickLevel(adjacentBuildingTypeScript.GetBuildingClick(), !isIncreasedOrDecreased);
    //                        //}
    //                        //adjacentBuildingTypeScript.SetBuildingStats(adjacentBuildingTypeScript.GetBuildingType(), buildingTypeScript.GetBuildingAdjacency(), isIncreasedOrDecreased);
    //                        //gridManager.SetClickLevel(adjacentBuildingTypeScript.GetBuildingClick(), isIncreasedOrDecreased);
    //                        ////adjacentCellScript.CheckAndChangeStats(isIncreasedOrDecreased);
    //                        ////Debug.Log("adjacent" + adjacentCell.GetComponent<Cell>().allAdjacentSquares);
    //                        adjacentCellScript = null;
    //                        adjacentBuildingTypeScript = null;
    //                    }

    //                    else
    //                    {
    //                        //Debug.Log("noscript " + adjacentCell.name);
    //                    }
    //                }

    //                else
    //                {
    //                    //Debug.Log("null");
    //                }
    //            }
    //            break;
    //        default:
    //            Debug.LogError("Invalid Type passed through: " + buildingTypeScript.GetBuildingType());
    //            break;
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
