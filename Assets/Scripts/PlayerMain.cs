using System.Collections;
using System.Collections.Generic;
using UnityEngine ;

public class PlayerMain : MonoBehaviour
{
    public float walkSpeed = 0.125f, jumpSpeed = 8, xDirection = 0;
    CapsuleCollider playerCollider;
    Rigidbody rigidBody;
    public LayerMask layerNotSelf;
    public bool controlling = true;

    public float fallMultiplier = 2.5f, lowJumpMultiplier = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        playerCollider = GetComponent<CapsuleCollider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controlling)
        {
            //xDir
            xDirection = Input.GetAxis("Horizontal");

            //Jump Check
            if (rigidBody.velocity.y < 0)
                rigidBody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            else if (rigidBody.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
                rigidBody.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;


            if (IsGrounded() && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)))
                rigidBody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);

            if (!IsWalled())
                rigidBody.MovePosition(new Vector3(transform.position.x + xDirection * walkSpeed, transform.position.y, transform.position.z));
         }

        if (Input.GetKeyDown(KeyCode.X))
            controlling = !controlling;
    }

    public bool IsGrounded()
    {
        return Physics.CheckCapsule(playerCollider.bounds.center, new Vector3(playerCollider.bounds.center.x, playerCollider.bounds.min.y, playerCollider.bounds.center.z), playerCollider.radius * 0.8f, layerNotSelf);
    }

    public bool IsWalled()
    {
        float offset = Mathf.Sign(xDirection) * walkSpeed;
        return Physics.CheckCapsule(new Vector3(playerCollider.bounds.center.x + offset, playerCollider.bounds.max.y - 0.5f, playerCollider.bounds.center.z), 
            new Vector3(playerCollider.bounds.center.x + offset, playerCollider.bounds.min.y + 0.5f, playerCollider.bounds.center.z), playerCollider.radius * 0.8f, layerNotSelf);
    }
}
