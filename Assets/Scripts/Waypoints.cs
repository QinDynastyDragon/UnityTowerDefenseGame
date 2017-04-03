using UnityEngine;

public class Waypoints : MonoBehaviour 
{
    public static Transform[] points;

    void Awake ()
    {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
	
} // make .points static and array,  makes it equal to the number of childs, and order them by .points[1] .points[2]
