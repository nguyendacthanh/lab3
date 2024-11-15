using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveRadius = 2f;
    public float moveSpeed = 1.5f;
    public float waitTime = 1f;
    public float attackRange = 3f;     

    private Vector2 startPosition;
    private Vector2 targetPosition;
    private Transform player;         

    void Start()
    {
        startPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(MoveUpDown());
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

    }

    IEnumerator MoveUpDown()
    {
        while (true)
        {
            float randomY = Random.Range(-moveRadius, moveRadius);
            targetPosition = new Vector2(startPosition.x, startPosition.y + randomY);

            while (Vector2.Distance(transform.position, targetPosition) > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }

            yield return new WaitForSeconds(waitTime); 
        }
    }

  
}
