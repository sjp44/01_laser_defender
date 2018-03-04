using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controler : MonoBehaviour {

    public float speed = 15;
    float xmin;
    float xmax;
       
	// Use this for initialization
	void Start () {
        float paddle = 1f;
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rigthmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftmost.x + paddle;
        xmax = rigthmost.x - paddle;
        Debug.Log(xmin);
        Debug.Log(xmax);
        
    }
	
	// Update is called once per frame
	void Update () {
        // Keyboard input
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        // Restrict player space
        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

        
    }
}
