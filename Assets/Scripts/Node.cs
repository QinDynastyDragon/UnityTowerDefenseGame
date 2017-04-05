using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour 
{

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turret;

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

        buildManager.BuildTurretOn(this);
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
