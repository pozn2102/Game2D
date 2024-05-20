using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPatrol : MonoBehaviour
{
    public float moveSpeed;
    public float rayLenght;
    private bool moveLeft;
    public Transform contactChecker;
    // Start is called before the first frame update
    void Start()
    {
        moveLeft = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        int layerMask = 1 << 8;
        layerMask = ~layerMask;
        RaycastHit2D contactCheck = Physics2D.Raycast(contactChecker.position, Vector2.right, rayLenght, layerMask);
        Debug.DrawRay(contactChecker.position, Vector2.right * rayLenght, Color.red);
        if (contactCheck == true)
        {
            if(moveLeft == true)
            {
                transform.eulerAngles = new Vector2(0, -180);
                moveLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector2(0, 0);
                moveLeft = true;
            }
        }
    }
}
