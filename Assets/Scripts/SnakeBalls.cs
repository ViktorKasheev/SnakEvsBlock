using System.Collections.Generic;
using UnityEngine;

public class SnakeBalls : MonoBehaviour
{
    public Transform SnakeHead;
    public float BallDiameter;

    private List<Transform> snakeBalls = new List<Transform>();
    private List<Vector3> positionSnake = new List<Vector3>();

   
    private void Awake()
    {
        positionSnake.Add(SnakeHead.position);
    }

    
    void Update()
    {
        float distance = (SnakeHead.position - positionSnake[0]).magnitude;

        if (distance > BallDiameter)
        {
            Vector3 direction = (SnakeHead.position - positionSnake[0]).normalized;

            positionSnake.Insert(0, positionSnake[0] + direction * BallDiameter);
            positionSnake.RemoveAt(positionSnake.Count - 1);

            distance -= BallDiameter;
        }

        for (int i = 0; i < snakeBalls.Count; i++)
        {
            snakeBalls[i].position = Vector3.Lerp(positionSnake[i + 1], positionSnake[i], distance / BallDiameter);
        }
    }

    public void AddBall()
    {
        Transform ball = Instantiate(SnakeHead, positionSnake[positionSnake.Count - 1], Quaternion.identity, transform);
        snakeBalls.Add(ball);
        positionSnake.Add(ball.position);
    }

    public void RemoveBall()
    {
        Destroy(snakeBalls[0].gameObject);
        snakeBalls.RemoveAt(0);
        positionSnake.RemoveAt(1);
    }
}
