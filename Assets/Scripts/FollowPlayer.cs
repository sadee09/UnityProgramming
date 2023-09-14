
using UnityEngine;
public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(0f, 1f, -5f);
    public float rotationSpeed = 0.5f;

    private void LateUpdate()
    {
        // Update the position based on the player's position and offset
        transform.position = player.transform.position + offset;

        // Rotate the camera to match the player's rotation
        // Quaternion targetRotation = Quaternion.Euler(0f, player.transform.eulerAngles.y, 0f);
        // transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
