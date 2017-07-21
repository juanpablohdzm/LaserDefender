using UnityEngine;

public class PlayerController_CS : MonoBehaviour {

    public float Speed=5f;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow))
            MoveToLeft();
        if (Input.GetKey(KeyCode.RightArrow))
            MoveToRight();
        
	}

    void MoveToLeft()
    {

        transform.position += new Vector3(-Speed*Time.deltaTime, 0, 0);
    }

    void MoveToRight()
    {
        transform.position += new Vector3(Speed*Time.deltaTime, 0, 0);
    }
}
