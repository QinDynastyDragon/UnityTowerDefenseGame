using UnityEngine;

public class BuildManager : MonoBehaviour 
{
    public static BuildManager instance; // static, only want one instance of the build manager/meny that is shared to everyone else through public

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    
    public GameObject buildEffect;

    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    public NodeUI nodeUI;

    public bool CanBuild { get { return turretToBuild != null; } } // CanBuild property, checks if turretToBuild is equal to null, if yes, return true
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }
       

    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();

    }
    // sets the private turretToBuild equals to the turret paramenter from shop script, SelectTurretToBuild()

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }

}
