using UnityEngine;

public class CameraController : MonoBehaviour 
{

    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    private bool doMovement = true;
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;
	
	// Update is called once per frame
	void Update () 
	{

        if (Input.GetKeyDown(KeyCode.Escape))
            doMovement = !doMovement;

        if (!doMovement)
            return;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)  // getkeydown/up is only one time, getkey is everything hold and pressed
            // the screen resolution starts from bottom left of the screen
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World); // this is the  same as    new Vector3(0f,0f,1f) * panSpeed;
            // Space.World = making the transform global instead of local, the moving tool
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness) 
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World); // -Vector3.forward is the same as Vector3.back
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel"); // GetAxis because scrolling is not discrete, you can scroll quick and slow.
        // Debug.Log(scroll); 
        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY); // restricting the max and min scrolling limit, too high or too low. 

        transform.position = pos;

    }
}
