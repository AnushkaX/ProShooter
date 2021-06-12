
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float turnSpeed = 5;

    [SerializeField]
    private float moveSpeed = 100;

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var movement = new Vector3(horizontal, 0, vertical);

        GetComponent<CharacterController>().SimpleMove(movement * Time.deltaTime * moveSpeed);

        GetComponentInChildren<Animator>().SetFloat("Speed", movement.magnitude);   //value from the key

        if(movement.magnitude > 0)
        {
            Quaternion newDirection = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, newDirection, Time.deltaTime * turnSpeed);
        }
       
    }
}
