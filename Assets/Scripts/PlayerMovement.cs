using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    private Rigidbody playerRb;
    private bool isPlaying = false;
    [SerializeField] private float sideLerpSpeed;
    [SerializeField] LayerMask layer;


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.velocity = transform.forward * playerSpeed;
    }

    void FixedUpdate()
    {
        if (isPlaying == true)
        {
            MoveForward();
            MoveSideways();

        }

        if (Input.GetMouseButton(0))
        {
            if (isPlaying == false)
            {
                isPlaying = true;
            }
        }


        Vector3 posX = transform.position;
        posX.x = Mathf.Clamp(transform.position.x,-3.7f,3.7f);
        transform.position = posX;
    }

    void MoveForward()
    {
        playerRb.velocity = Vector3.forward * playerSpeed;
    }

    void MoveSideways()
    {
        Ray MyRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(MyRay,out hit, 100, layer))
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(hit.point.x, transform.position.y, transform.position.z), sideLerpSpeed * Time.deltaTime);
        }
    }


   

}
