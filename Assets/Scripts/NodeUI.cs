using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour {


    public GameObject ui;

    public Text upgradeCost;
    public Button upgradeButton;

    public Text sellAmount;

    private Node target;


    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition(); // reason we dont just use target.transform.position is because our UI is not in the center of the node

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBluePrint.upgradeCost;
            upgradeButton.interactable = true;
        } else
        {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
        }

        sellAmount.text = "$" + target.turretBluePrint.GetSellAmount();

        ui.SetActive(true);

    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
        target.isUpgraded = false;
    }

}
