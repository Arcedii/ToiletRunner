using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeMovement : MonoBehaviour
{
    public BoxCollider playerCollider;
    public Vector3 newScale;
    public Vector3 newCenter;
    private Vector3 oldScale;
    private Vector3 oldCenter;

    public Animator animator;
    private Vector2 touchStartPos;
    private Vector2 touchEndPos;
    private bool isSwiping = false;
    private bool isSwipeEnabled = true; // Флаг для включения/отключения свайпа
    public float swipeDistanceThreshold = 100.0f; // Порог расстояния свайпа для активации
    public GameObject movingObject; // Ссылка на объект для перемещения
    public float moveDistance = 1.0f; // Расстояние перемещения при свайпе
    public float moveSpeed = 5.0f; // Скорость перемещения объекта
    public float jumpHeight = 2.0f; // Высота прыжка
    public float rollDuration = 1.0f; // Длительность переката

    private Vector3 targetPosition;
    private bool isMoving = false;
    private bool isJumping = false;
    private bool isRolling = false;
    private float rollTimer = 0.0f;
    public Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = movingObject.GetComponent<Rigidbody>();

        // Сохраняем начальные значения scale и center
        oldScale = playerCollider.size;
        oldCenter = playerCollider.center;
    }

    private void Update()
    {
        if (isMoving)
        {
            float step = moveSpeed * Time.deltaTime;
            movingObject.transform.position = Vector3.MoveTowards(movingObject.transform.position, targetPosition, step);

            if (Vector3.Distance(movingObject.transform.position, targetPosition) < 0.01f)
            {
                isMoving = false;
            }
        }
        else if (isJumping)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Roll", false);

            float jumpForce = Mathf.Sqrt(2 * jumpHeight * Mathf.Abs(Physics.gravity.y));
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            animator.SetBool("Jump", true);
            isJumping = false;
            StartCoroutine(DisableJumpAnimation());
            DisableSwipe(); // Отключить свайпы во время прыжка
        }
        else if (isRolling)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Roll", false);

            playerCollider.size = newScale;
            playerCollider.center = newCenter;

            animator.SetBool("Roll", true);
            isRolling = false;
            StartCoroutine(DisableRollAnimation());
            DisableSwipe(); // Отключить свайпы во время переката
        }
        else if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
                isSwiping = true;
            }
            else if (touch.phase == TouchPhase.Ended && isSwiping)
            {
                touchEndPos = touch.position;
                float swipeDistanceX = touchEndPos.x - touchStartPos.x;
                float swipeDistanceY = touchEndPos.y - touchStartPos.y;

                if (Mathf.Abs(swipeDistanceX) > swipeDistanceThreshold)
                {
                    float moveAmount = Mathf.Sign(swipeDistanceX) * moveDistance;
                    targetPosition = movingObject.transform.position + new Vector3(-moveAmount, 0, 0); // Изменение знака здесь
                    isMoving = true;
                }

                if (isSwipeEnabled)
                {
                    if (swipeDistanceY > swipeDistanceThreshold)
                    {
                        Jump();
                    }
                    else if (swipeDistanceY < -swipeDistanceThreshold)
                    {
                        Roll();
                    }
                }

                isSwiping = false;
            }
        }
    }

    void Jump()
    {
        if (!isJumping && !isRolling)
        {
            isJumping = true;
            DisableSwipe(); // Отключить свайпы во время прыжка
        }
    }

    void Roll()
    {
        if (!isJumping && !isRolling)
        {
            isRolling = true;
            DisableSwipe(); // Отключить свайпы во время переката

            // Добавьте логику для переката, если необходимо
        }
    }

    IEnumerator DisableJumpAnimation()
    {
        yield return new WaitForSeconds(rollDuration);
        animator.SetBool("Jump", false);
        EnableSwipe(); // Включить свайпы после окончания прыжка
    }

    IEnumerator DisableRollAnimation()
    {
        // Установить новые значения размера и центра коллайдера
        playerCollider.size = newScale;
        playerCollider.center = newCenter;

        // Ждать заданную длительность переката
        yield return new WaitForSeconds(rollDuration);

        // Восстановить старые значения размера и центра коллайдера
        playerCollider.size = oldScale;
        playerCollider.center = oldCenter;

        animator.SetBool("Roll", false);
        EnableSwipe(); // Включить свайпы после окончания переката
    }

    void DisableSwipe()
    {
        isSwipeEnabled = false;
    }

    void EnableSwipe()
    {
        isSwipeEnabled = true;
    }
}





