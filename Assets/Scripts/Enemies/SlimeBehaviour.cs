using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBehaviour : MonoBehaviour
{
    [Header("Behaviour")]

    [SerializeField] private float walkSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float detectionRange;

    private float chronometer = 3.5f;

    private bool isGrounded;
    private bool isJumping;
    private bool isLanding;

    private Transform target;
    private Rigidbody2D rb;
    private Animator animator;


    private void Start()
    {
        target = GameObject.Find("PlayerController").transform;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        RangeDetection();
    }

    private void Jump(Vector2 jumpDirection)
    {
        rb.AddForce((Vector2.up + jumpDirection) * jumpForce, ForceMode2D.Impulse);

        StartCoroutine(ChangeToAirAfterDelay(0f));

        isGrounded = false;

        animator.SetBool("Air", false);
        animator.SetBool("Idle", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;

            if (isJumping)
            {
                isJumping = false;

                animator.SetBool("Landing", true);
                animator.SetBool("Air", false);

                isLanding = true;

                chronometer = 3.5f;

                StartCoroutine(ChangeToIdleAfterDelay(0.6f));
            }
        }
    }
    private IEnumerator ChangeToIdleAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        animator.SetBool("Idle", true);
        animator.SetBool("Landing", false);
        
        isLanding = false;
    }
    private IEnumerator ChangeToAirAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        animator.SetBool("Air", true);
        animator.SetBool("Jump", false);
    }
    private void RangeDetection()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, target.position);

        if (distanceToPlayer <= detectionRange)
        {
            Vector2 moveDirection = new Vector2(target.position.x - transform.position.x, 0f).normalized;

            if (transform.position.x > target.position.x && !isLanding && isGrounded)
            {
                Vector3 localScaleX = transform.localScale;
                localScaleX.x = -1.5f;
                transform.localScale = localScaleX;
            }
            else if (transform.position.x < target.position.x && !isLanding && isGrounded)
            {
                Vector3 localScaleX = transform.localScale;
                localScaleX.x = 1.5f;
                transform.localScale = localScaleX;
            }

            if (isGrounded)
            {
                transform.Translate(moveDirection * walkSpeed * Time.deltaTime);
            }

            if (chronometer >= 0)
            {
                chronometer -= Time.deltaTime;
            }
            if (target.position.y > transform.position.y && chronometer <= 0.7f && isGrounded)
            {
                isJumping = true;

                animator.SetBool("Jump", true);
                animator.SetBool("Idle", false);

                if (chronometer <= 0)
                {
                    Jump(moveDirection);
                }
            }
        }
        else
        {
            animator.SetBool("Idle", true);
        }
    }
}