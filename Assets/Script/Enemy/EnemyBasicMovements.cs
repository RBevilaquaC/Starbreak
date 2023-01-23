using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicMovements : MonoBehaviour
{
    #region Parameters

    [SerializeField] protected float speedModifier;
    [SerializeField] protected float turnModifier;
    private Rigidbody2D _rigidbody2D;

    #endregion

    protected void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    protected float DirToPlayer()
    {
        return (PlayerStatus.playerObject.transform.position - transform.position).magnitude;
    }

    protected void lookToPlayer()
    {
        Vector3 mousePosition = PlayerStatus.playerObject.transform.position;
        Vector3 direction = mousePosition - transform.position;
        float angle = Vector2.SignedAngle(Vector2.right, direction);
        Vector3 targetRotation = new Vector3(0, 0, angle-90);
        transform.rotation = (Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetRotation), turnModifier));
    }
    
    
    protected void MoveFoward()
    {
        float angle = transform.rotation.eulerAngles.z+90;
        Vector3 dir = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad),0);
        _rigidbody2D.velocity = dir * speedModifier;
    }
    
    protected void MoveToSide()
    {
        float angle = transform.rotation.eulerAngles.z;
        Vector3 dir = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad),0);
        _rigidbody2D.velocity = dir * speedModifier;
    }
    
    protected void Stay()
    {
        _rigidbody2D.velocity = Vector2.zero;
    }
    
    protected void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<LifeSystem>().takeDamage(10);
        }
    }

    protected void MoveBack()
    {
        float angle = transform.rotation.eulerAngles.z-90;
        Vector3 dir = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad),0);
        _rigidbody2D.velocity = dir * speedModifier;
        
    }
}
