using UnityEngine;

public class BlackHole : CharacterEnd {

    [SerializeField]
    private float speedForSurvive = 80;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D characterRb = collision.GetComponent<Rigidbody2D>();
        if(characterRb.velocity.y <= speedForSurvive){
            ResultCheck(collision);
        }
    }

    private void Update()
    {
        DieCheck();
    }

    protected void DieCheck()
    {
        if (Camera.main.transform.position.y - Camera.main.orthographicSize > transform.position.y)
        {
            Die();
        }
    }

    private void Die()
    {
        EnemyCreator instance = EnemyCreator.GetInstance();
        instance.CreateBlackHole();
        Destroy(gameObject);
    }
}
