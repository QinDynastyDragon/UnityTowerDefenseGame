using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUI : MonoBehaviour {


    public GameObject ui;

    private Node target;


    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition(); // reason we dont just use target.transform.position is because our UI is not in the center of the node

        ui.SetActive(true);

    }

    public void Hide()
    {
        ui.SetActive(false);
    }

}
