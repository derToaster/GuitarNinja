using UnityEngine;


public class Controls : MonoBehaviour {
    public bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool isDraging = false;
    private float lastTimer, currentTimer;
    private int clickCounter;


    private Vector2 startTouch;

    public Vector2 swipeDelta;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        tap = swipeLeft = swipeRight = swipeDown = swipeUp = false;


        #region MouseInputs

        if (Input.GetMouseButtonDown(0)) {
            isDraging = true;
            tap = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0)) {
            isDraging = false;
            Reset();
        }

        #endregion

        #region MobileInputs

        if (Input.touches.Length != 0) {
            if (Input.touches[0].phase == TouchPhase.Began) {
                isDraging = true;
                tap = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled) {
                isDraging = false;
                Reset();
            }
        }

        #endregion


        //calculate the distance 
        swipeDelta = Vector2.zero;
        if (isDraging) {
            if (Input.touches.Length != 0) {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            else if (Input.GetMouseButton(0)) {
                swipeDelta = (Vector2) Input.mousePosition - startTouch;
            }
        }
        //DeadZone Calculation

        if (swipeDelta.magnitude > 125) {
            //Direction Calculation

            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y)) {
                //X axis
                if (x < 0) {
                    swipeLeft = true;
                }
                else {
                    swipeRight = true;
                }
            }
            else {
                //Y Axis
                if (y < 0) {
                    swipeDown = true;
                }
                else {
                    swipeUp = true;
                }
            }

            Reset();
        }
    }


    public bool IsDoubleClick(float timeBetweenClicks) {
        if (Input.GetMouseButtonDown(0)) {
            clickCounter++;
            if (clickCounter == 1) {
                lastTimer = Time.unscaledTime;
            }

            if (clickCounter >= 2) {
                currentTimer = Time.unscaledTime;
                float difference = currentTimer - lastTimer;
                if (difference <= timeBetweenClicks) {
                    clickCounter = 0;
                    return true;
                }
                else {
                    clickCounter = 0;
                }
            }
        }

        if (Input.touches.Length != 0) {
            if (Input.touches[0].phase == TouchPhase.Began) {
                clickCounter++;
                if (clickCounter == 1) {
                    lastTimer = Time.unscaledTime;
                }

                if (clickCounter >= 2) {
                    currentTimer = Time.unscaledTime;
                    float difference = currentTimer - lastTimer;
                    if (difference <= timeBetweenClicks) {
                        clickCounter = 0;
                        return true;
                    }
                    else {
                        clickCounter = 0;
                    }
                }
            }
        }

        return false;
    }

    private void Reset() {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }
}