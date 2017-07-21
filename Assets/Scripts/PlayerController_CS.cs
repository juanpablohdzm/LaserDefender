using UnityEngine;

public class PlayerController_CS : MonoBehaviour {

    public float Speed=5f;
    public float ShipWidth = .5f;

    float minX;
    float maxX;

    private void Start()
    {
        float Distance = transform.position.z - Camera.main.transform.position.z;
        //Finds the vector from the relative origin of the camera to lower left corner
        Vector3 WorldLeftPos=Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Distance));
        Vector3 WorldRightPos = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, Distance));
        minX = WorldLeftPos.x+ShipWidth;
        maxX = WorldRightPos.x-ShipWidth;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.LeftArrow))
            MoveToLeft();
        if (Input.GetKey(KeyCode.RightArrow))
            MoveToRight();

        float NewX = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(NewX, transform.position.y);
        
	}

    void MoveToLeft()
    {

        transform.position += Vector3.left * Speed * Time.deltaTime;
    }

    void MoveToRight()
    {
        transform.position += Vector3.right * Speed * Time.deltaTime;
    }
}
