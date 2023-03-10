using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private bool diagonalMovement = false;
    Vector3 movementVector;
    bool wasMovingVertical;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }    
    public void Movement()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");

        if (diagonalMovement == false) FourSides();
        if (diagonalMovement == true) HeightSides();

        transform.position += movementVector * playerSpeed * Time.deltaTime;
    }
    public Vector3 HeightSides()
    {
        return movementVector.normalized;
    }
    public Vector3 FourSides()
    {
        bool isMovingHorizontal = Mathf.Abs(movementVector.x) > 0.5f;
        bool isMovingVertical = Mathf.Abs(movementVector.y) > 0.5f;
        if (isMovingVertical && isMovingHorizontal)
        {
            if (wasMovingVertical)
            {
                movementVector.y = 0;
            }
            else
            {
                movementVector.x = 0;
            }
        }
        else if (isMovingHorizontal)
        {
            movementVector.y = 0;
            wasMovingVertical = false;
        }
        else if (isMovingVertical)
        {
            movementVector.x = 0;
            wasMovingVertical = true;
        }
        else
        {
            movementVector.x = 0;
            movementVector.y = 0;
        }
        return movementVector;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Teleporter>() != null)
        {
            collision.gameObject.GetComponent<Teleporter>().TeleportPlayer();
           
        }
    }
}
