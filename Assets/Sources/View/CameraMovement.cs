using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Vector3 _distanceFromPlayer;

    public void LateUpdate()
    {
        FollowOnZAndYAxis();
    }

    public void FollowOnZAndYAxis()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = _distanceFromPlayer.x;
        newPosition.y = _playerTransform.position.y + _distanceFromPlayer.y;
        newPosition.z = _playerTransform.position.z + _distanceFromPlayer.z;
        transform.position = newPosition;
    }
}
