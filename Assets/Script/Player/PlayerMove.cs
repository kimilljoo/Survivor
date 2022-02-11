using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Animator animator;
    private bool isMoving = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Move(float moveSpeed)
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (h == 0 && v == 0)
            isMoving = false;
        else
            isMoving = true;

        Vector2 moveDirection = new Vector2(h, v);

        animator.SetBool("isMoving", isMoving);
        transform.Translate(moveDirection.normalized * moveSpeed * Time.deltaTime);
    }
}
