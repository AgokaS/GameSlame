using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    [SerializeField] private float speed = 0.04f;

    private Animator animator;

    private bool MoveTarget = false;
    private Vector3 target;
    private float Velocity = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        animator=this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!MoveTarget)
        {
            if (Input.GetButtonDown("Horizontal"))
            {
                animator.SetInteger("State", 1);
                MoveTarget = true;
                MoveX();
            }
            else if (Input.GetButtonDown("Vertical"))
            {
                animator.SetInteger("State", 1);
                MoveTarget = true;
                MoveY();
            }
        }
        else
        {
            AnimateMove();
        }
    }

    private void MoveX()
    {
        if (Input.GetAxis("Horizontal") < 0)
            target = new Vector3(transform.position.x - 1.0f, transform.position.y + 0.5f, transform.position.z);
        else
            target = new Vector3(transform.position.x + 1.0f, transform.position.y - 0.5f, transform.position.z);

        AnimateMove();
    }

    private void MoveY()
    {
        if (Input.GetAxis("Vertical") < 0)
            target = new Vector3(transform.position.x - 1.0f, transform.position.y - 0.5f, transform.position.z);
        else
            target = new Vector3(transform.position.x + 1.0f, transform.position.y + 0.5f, transform.position.z);

        AnimateMove();
    }

    private void AnimateMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, target ,speed);

        if (transform.position == target)
        {
            MoveTarget = false;
            animator.SetInteger("State", 0);
        }
    }

    
    private void CheckBlock()
    {

    }
}
