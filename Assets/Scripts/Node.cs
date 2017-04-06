using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour 
{

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBluePrint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;


        if(turret != null)
        {
            buildManager.SelectNode(this);  // selected the Node itself, if there is already a turret.
            return;
        }

        if (!buildManager.CanBuild)
            return;

        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret (TurretBlueprint blueprint)
    {

        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        PlayerStats.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBluePrint = blueprint;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity); // store it into a temporary variable, so we can destroy it in next line
        Destroy(effect, 5f);

        Debug.Log("Turret built!");
    }

    public void UpgradeTurret()
    {

        if (PlayerStats.Money < turretBluePrint.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade that!");
            return;
        }

        PlayerStats.Money -= turretBluePrint.upgradeCost;

        // get rid of the old turret
        Destroy(turret);

        // building a new one
        GameObject _turret = (GameObject)Instantiate(turretBluePrint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity); // store it into a temporary variable, so we can destroy it in next line
        Destroy(effect, 5f);

        isUpgraded = true;

        Debug.Log("Turret upgraded!");
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;


        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor; // we can do GetComponent<Renderer>().material.color = hoverColor, without making a private Renderer rend.
        }

        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
        
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
    
    // OnMouseDown will check if everything is alright to put the turret on, if yes, call to the buildManager.BuildTurretOn
    // in BuildManager script, the turret will be passed to the private Node.turret here in this script, which will be seen in the Optional Header. 
    // and that node.turret will always check if there is something else in the node. 
}
