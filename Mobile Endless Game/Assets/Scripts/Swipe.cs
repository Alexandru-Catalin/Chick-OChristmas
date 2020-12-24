using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum SIDE { Left, Mid, Right}

public class Swipe : MonoBehaviour
{
    private bool tap, swipeLeft, swipeRight;
    private bool isDraging = false;
    private Vector2 startTouch, swipeDelta;

    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool swipeToTheLeft { get { return swipeLeft; } }
    public bool swipeToTheRight { get { return swipeRight; } }

    public SIDE m_Side = SIDE.Mid;
    float NewXPos = 0f;
    public bool SwipeLeft;
    public bool SwipeRight;
    public float XValue;
    private CharacterController m_char;
    public float speed = 10f;
    private float x;
    public float speedDodge;

    void Start()
    {
        m_char = GetComponent<CharacterController>();
        transform.position = Vector3.zero;
    }

    void Update()
    {
        tap = swipeLeft = swipeRight = false;

        #region Mobile Inputs
        if(Input.touches.Length > 0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                isDraging = true;
                tap = true;
                startTouch = Input.touches[0].position;
            }
            else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                Reset();
            }
        }

        //Calculate the distance
        swipeDelta = Vector2.zero;
        if(isDraging)
        {
            if(Input.touches.Length > 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }          
        }

        //Cross the deadzone?
        if(swipeDelta.magnitude > 150)
        {
            //Direction?
            float dx = swipeDelta.x;
            float dy = swipeDelta.y;
            if(Mathf.Abs(dx) > Mathf.Abs(dy))
            {
                //Left or Right
                if(dx < 0)
                {
                    swipeLeft = true;
                    if (m_Side == SIDE.Mid)
                    {
                        NewXPos = -XValue;
                        m_Side = SIDE.Left;
                    }
                    else if (m_Side == SIDE.Right)
                    {
                        NewXPos = 0;
                        m_Side = SIDE.Mid;
                    }

                }
                else
                {
                    swipeRight = true;
                    if (m_Side == SIDE.Mid)
                    {
                        NewXPos = XValue;
                        m_Side = SIDE.Right;
                    }
                    else if (m_Side == SIDE.Left)
                    {
                        NewXPos = 0;
                        m_Side = SIDE.Mid;
                    }
                }
            }
            Reset();
        }
        #endregion

        SwipeLeft = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        SwipeRight = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);

        if (SwipeLeft)
        {
            if(m_Side == SIDE.Mid)
            {
                NewXPos = -XValue;
                m_Side = SIDE.Left;
            }
            else if(m_Side == SIDE.Right)
            {
                NewXPos = 0;
                m_Side = SIDE.Mid;
            }
        }
        else if (SwipeRight)
        {
            if (m_Side == SIDE.Mid)
            {
                NewXPos = XValue;
                m_Side = SIDE.Right;
            }
            else if (m_Side == SIDE.Left)
            {
                NewXPos = 0;
                m_Side = SIDE.Mid;
            }
        }
        Vector3 moveVector = new Vector3(x - transform.position.x, transform.position.y, speed * Time.deltaTime);
        x = Mathf.Lerp(x, NewXPos, Time.deltaTime * speedDodge);
        m_char.Move(moveVector);
        speed += 0.4f * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, 1.4f, transform.position.z);
    }

    public void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }
}
