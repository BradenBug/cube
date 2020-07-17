using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCurve : MonoBehaviour
{
    public AnimationCurve xCurve, yCurve, rCurve;
    private Rigidbody2D rigidBody;
    private float timeElapsed = 0;
    private bool follow = false;
    private Vector2 startPosition;
    private int directionMultiplier = 1;
    private float verticalSpeed = 0;
    
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (follow)
        {
            timeElapsed += Time.deltaTime;

            rigidBody.MovePosition(new Vector2(
                startPosition.x + directionMultiplier * xCurve.Evaluate(timeElapsed),
                rigidBody.position.y + verticalSpeed * Time.deltaTime
            ));
            rigidBody.MoveRotation(-rCurve.Evaluate(timeElapsed));

            if (timeElapsed >= getAnimationLength(xCurve))
            {
                follow = false;
                directionMultiplier = -directionMultiplier;
            }
        }
    } 

    public void initFollow(bool goRight)
    {
        if (!goRight)
        {
            directionMultiplier = -directionMultiplier;
        }
        follow = true;
        timeElapsed = 0;
        startPosition = transform.position;
    }

    private float getAnimationLength(AnimationCurve curve)
    {
        return curve.keys[curve.length - 1].time;
    }

    public bool isFollowing()
    {
        return follow;
    }

    public void setVerticalSpeed(float speed)
    {
        verticalSpeed = speed;
    }
}
