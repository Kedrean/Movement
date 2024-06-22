using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;    // Reference to the player's transform.
    public Vector3 offset = new Vector3(0, 20, 0);      // Offset position from the player.

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player not assigned to the camera follow script.");
            return;
        }

        // Set the initial position with offset.
        transform.position = player.position + offset;
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Update the camera's position to follow the player with the specified offset.
            transform.position = player.position + offset;
        }
    }
}