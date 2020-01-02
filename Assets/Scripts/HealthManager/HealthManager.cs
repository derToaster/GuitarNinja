using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    private Image lifeIndicator;
    private Animator playerAnim;
    public float invincibilityLength;
    public Renderer playerRenderer;
    private playerMovement player;
    private GameManager _gameManger;

    // Start is called before the first frame update
    void Start()
    {

        lifeIndicator = GameObject.FindGameObjectWithTag(Tags.LIFE_INDICATOR).GetComponent<Image>();
        playerAnim = GameObject.FindGameObjectWithTag(Tags.PLAYER).GetComponent<Animator>();
        player = FindObjectOfType<playerMovement>();
        _gameManger = FindObjectOfType<GameManager>();
    }
        
    // Update is called once per frame
    void Update() {
        if (lifeIndicator.fillAmount <= 0f){            playerAnim.SetBool(Tags.ANIMATION_CONDITION_BOOL_DEATH, true);            player.Death();            _gameManger.GameOver();

            
        }
        
    }



    public IEnumerator GettingHurt(Vector3 direction) {        if (lifeIndicator.fillAmount > 0.25f) {            lifeIndicator.fillAmount -= 0.25f;            playerAnim.SetBool(Tags.ANIMATION_CONDITION_BOOL_HURT, true);            yield return new WaitForSeconds(0.3f);            playerAnim.SetBool(Tags.ANIMATION_CONDITION_BOOL_HURT, false);            StartCoroutine(DoBlinks(invincibilityLength, 0.2f));
        } else  { lifeIndicator.fillAmount -= 0.25f; }

        
        

        
    }

        IEnumerator DoBlinks(float duration, float blinkTime) {        while (duration > 0f) {            duration -= Time.deltaTime;            Debug.Log(duration);            Physics.IgnoreLayerCollision(9, 10, true);            //toggle renderer            playerRenderer.enabled = !playerRenderer.enabled;            //wait for a bit            yield return new WaitForSeconds(blinkTime);        }        //make sure renderer is enabled when we exit        playerRenderer.enabled = true;        Physics.IgnoreLayerCollision(9, 10, false);    }



   
}
