using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected float speed;
    [SerializeField] protected PlayerController player;
    [SerializeField] protected float damage;
    private PointManager pointManager;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        // Verifica se o PointManager existe antes de atribuir
        GameObject pointManagerObj = GameObject.Find("PointManager");
        if (pointManagerObj != null)
        {
            pointManager = pointManagerObj.GetComponent<PointManager>();
        }
        else
        {
            Debug.LogError("GameObject 'PointManager' não encontrado na cena!");
        }
    }
    // Update is called once per frame
    protected virtual void Update()
    {
        if (health <= 0)
        {
            if (pointManager != null)
            {
                pointManager.UpdateScore(200); // Adiciona pontos
            }
            else
            {
                Debug.LogWarning("PointManager não atribuído!");
            }
            Destroy(gameObject);
        }
    }


    public virtual void EnemyHit(float _damageDone)
    {
        health -= _damageDone;
    }

    protected void OnTriggerStay2D(Collider2D _other)
    {
        if (_other.CompareTag("Player") && !PlayerController.Instance.pState.invincible)
        {
            Attack();
        }
    }
    protected virtual void Attack()
    {
        PlayerController.Instance.TakeDamage(damage);
    }
}
