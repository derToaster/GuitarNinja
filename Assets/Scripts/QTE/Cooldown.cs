using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour {
    private float timeThreshold;
    public Image arrowUp, arrowDown, doubleTap;
    private bool canKick, canJump, canSlide, correctHit;
    public int emissionsNote;
    private CollectionEffect sparkle;
    private Controls controls;
    

    private Image coolDownArrowUp, coolDownArrowDown, coolDownDoubleTap;
    public KeyCode jumpKey, slideKey, kickkey;
    private Animator playerAnim;
    private PointSystem points;
    public int pointsForJump, pointsForSlide, pointsForKick;
    private AudioManager am;
    private HealthManager health;
    public int counter;

    // Start is called before the first frame update
    void Awake() {
        coolDownArrowUp = GameObject.FindGameObjectWithTag(Tags.COOLDOWN_RING_ARROW_UP).GetComponent<Image>();
        coolDownArrowDown = GameObject.FindGameObjectWithTag(Tags.COOLDOWN_RING_ARROW_DOWN).GetComponent<Image>();
        coolDownDoubleTap = GameObject.FindGameObjectWithTag(Tags.COOLDOWN_RING_DOUBLETAP).GetComponent<Image>();
        playerAnim = GameObject.FindGameObjectWithTag(Tags.PLAYER).GetComponent<Animator>();
        points = FindObjectOfType<PointSystem>();
        health = FindObjectOfType<HealthManager>();
        controls = FindObjectOfType<Controls>();

    }

    private void Start() {
        am = FindObjectOfType<AudioManager>();
        sparkle = FindObjectOfType<CollectionEffect>();
        //Making all Indications Invisible
        arrowUp.fillAmount = 0f;
        arrowDown.fillAmount = 0f;
        doubleTap.fillAmount = 0f;
        coolDownArrowUp.fillAmount = 0f;
        coolDownArrowDown.fillAmount = 0f;
        coolDownDoubleTap.fillAmount = 0f;
        
    }

   

//////////////////////////////////////////////////QTE Jumping////////////////////////////////////////////////////////////

    public IEnumerator TimerUp(float rateOfReduction, float repeatRate, Animator anim, string nameAnimationBool) { 
        correctHit = false;
        arrowUp.fillAmount = 1f;
        coolDownArrowUp.fillAmount = 1f;
        anim.SetBool(nameAnimationBool, true);
        bool timesUp = false;
        while (!timesUp) {
            //When Hit Correctly
            if (correctHit) {
                points.addPoints(pointsForJump);
                am.PlayHighNote();
                counter += 1;

                timesUp = true;
                canJump = false;
                arrowUp.fillAmount = 0f;
                coolDownArrowUp.fillAmount = 0f;
                playerAnim.SetBool(Tags.ANIMATION_CONDITION_BOOL_JUMP, true);
            }
            //When Missed
            else if (coolDownArrowUp.fillAmount == 0f) {
                timesUp = true;
                canJump = false;
                arrowUp.fillAmount = 0f;
                Debug.Log("Too Late");
                am.PlayWrongNote();
                StartCoroutine(health.GettingHurt());
            }
            else {
                coolDownArrowUp.fillAmount -= rateOfReduction;
                canJump = true;
            }

            yield return new WaitForSeconds(repeatRate);
        }
    }
//////////////////////////////////////////////////QTE Jumping End////////////////////////////////////////////////////////////




//////////////////////////////////////////////////QTE Sliding////////////////////////////////////////////////////////////

    public IEnumerator TimerDown(float rateOfReduction, float repeatRate, Animator anim, string nameAnimationBool) {
        correctHit = false;
        arrowDown.fillAmount = 1f;
        coolDownArrowDown.fillAmount = 1f;
        bool timesUp = false;
        anim.SetBool(nameAnimationBool, true);

        while (!timesUp) {
            //When Hit Correctly
            if (correctHit) {
                points.addPoints(pointsForSlide);
                am.PlayBassNote();
                counter += 1;


                timesUp = true;
                canSlide = false;
                arrowDown.fillAmount = 0f;
                coolDownArrowDown.fillAmount = 0f;
                playerAnim.SetBool(Tags.ANIMATION_CONDITION_BOOL_SLIDE, true);
            }
            //When Missed

            else if (coolDownArrowDown.fillAmount == 0f) {
                timesUp = true;
                canSlide = false;
                arrowDown.fillAmount = 0f;
                Debug.Log("Too Late");
                am.PlayWrongNote();
                StartCoroutine(health.GettingHurt());
            }
            else {
                coolDownArrowDown.fillAmount -= rateOfReduction;
                canSlide = true;
            }

            yield return new WaitForSeconds(repeatRate);
        }
    }

//////////////////////////////////////////////////QTE Sliding End////////////////////////////////////////////////////////////



//////////////////////////////////////////////////QTE Kicking////////////////////////////////////////////////////////////

    public IEnumerator TimerKick(float rateOfReduction, float repeatRate,Vector3 position, GameObject note) {
        correctHit = false;
        doubleTap.fillAmount = 1f;
        coolDownDoubleTap.fillAmount = 1f;
        bool timesUp = false;

        while (!timesUp) {
            //When Hit Correctly
            if (correctHit) {
                points.addPoints(pointsForKick);
                am.PlayHarmonicNote();
                counter += 1;


                timesUp = true;
                canKick = false;
                doubleTap.fillAmount = 0f;
                coolDownDoubleTap.fillAmount = 0f;
                playerAnim.SetBool(Tags.ANIMATION_CONDITION_BOOL_KICK, true);
                sparkle.LetItSparkle(position,emissionsNote);
                note.SetActive(false);
            }
            //When Missed
            else if (coolDownDoubleTap.fillAmount == 0f) {
                timesUp = true;
                canKick = false;
                doubleTap.fillAmount = 0f;
                Debug.Log("Too Late");
                am.PlayWrongNote();
                StartCoroutine(health.GettingHurt());
                
            }
            else {
                coolDownDoubleTap.fillAmount -= rateOfReduction;
                canKick = true;
            }

            yield return new WaitForSeconds(repeatRate);
        }
    }

//////////////////////////////////////////////////QTE Kicking End////////////////////////////////////////////////////////////


    private void Update() {
        if (canJump) {
            if (controls.swipeUp || Input.GetKeyDown(jumpKey)) {
                Debug.Log("Nice");
                correctHit = true;
            }
        }


        if (canSlide) {
            if (controls.swipeDown || Input.GetKeyDown(slideKey)) {
                Debug.Log("Nice");
                correctHit = true;
            }
        }


        if (canKick) {
            if (controls.IsDoubleClick(0.2f)|| Input.GetKeyDown(kickkey)) {
                Debug.Log("Nice");
                correctHit = true;
            }
        }
    }
}