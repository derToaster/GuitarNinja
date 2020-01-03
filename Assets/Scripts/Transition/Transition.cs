
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour {
    public Animator animator;

    private int levelToLoad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeToLevel(int levelIndex) {
        levelToLoad = levelIndex;
        animator.SetTrigger(Tags.ANIMATION_CONDITION_TRIGGER_FADE_OUT);
        
    }

    public void OnFadeComplete() {


        SceneManager.LoadScene(levelToLoad);
    }
}
