using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public Action OnEnemyCollision;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<EnemyPresenter>())
        {
            OnEnemyCollision?.Invoke();
        }
    }
}
