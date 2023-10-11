using UnityEngine;

public class MovementVechickle : MonoBehaviour
{
    public Vector3 moveDirection = Vector3.forward;
    public float moveSpeed = 5f;

    private void Update()
    {
        MoveObject();
    }

    private void MoveObject()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}

