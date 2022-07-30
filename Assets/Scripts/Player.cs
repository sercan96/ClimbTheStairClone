using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    public static Animator Animator;
    
    void OnEnable()
    {
        EventManager.MousePressEvent += RunAnimation;
        EventManager.MousePressEvent += PlayPlayerSound;
    }
    void OnDisable()
    {
        EventManager.MousePressEvent -= RunAnimation;
        EventManager.MousePressEvent -= PlayPlayerSound;
    }

    void Start()
    {
        Animator = GetComponent<Animator>();
    }
    
    public void RunAnimation()
    {
        Animator.SetBool("isRun",true);
        Animator.SetBool("isIdle",false);
    }  
    public void IdleAnimation()
    {
        Animator.SetBool("isRun",false);
        Animator.SetBool("isIdle",true);
    }
    
    public void PlayPlayerSound()
    {
        AudioManager.Instance.PlayClipFx(_audioClip,0.5f);
    }

}
