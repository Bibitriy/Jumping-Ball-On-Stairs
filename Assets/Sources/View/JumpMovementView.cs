using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

public class JumpMovementView : MonoBehaviour
{
    [SerializeField] private Transform _playerBallTransform;
    [SerializeField] private float _jumpDuration;

    public Action JumpEnded;
    public Action JumpAsideEnded;

    public void JumpOnNextStair(float yDirectionToJump, float zDirectionToJump)
    {
        Vector3 directionToJump = new Vector3(0, yDirectionToJump, zDirectionToJump);
        _playerBallTransform.DOJump(_playerBallTransform.position + directionToJump, 0.5f, 1, _jumpDuration);
        StartCoroutine(StartJumpEndEvent(_jumpDuration));
    }

    public void JumpAside(float xDirectionToJump)
    {
        _playerBallTransform.DOJump(_playerBallTransform.position + xDirectionToJump * Vector3.right, 0.5f, 1, _jumpDuration);
        StartCoroutine(StartJumpAsideEndEvent(_jumpDuration));
    }

    public IEnumerator StartJumpEndEvent(float jumpDuration)
    {
        yield return new WaitForSeconds(jumpDuration);
        JumpEnded?.Invoke();
    }

    public IEnumerator StartJumpAsideEndEvent(float jumpDuration)
    {
        yield return new WaitForSeconds(jumpDuration);
        JumpAsideEnded?.Invoke();
    }
}
