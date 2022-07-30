using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    private Animator _animator;
    
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
        _animator = GetComponent<Animator>();
    }
    
    public void RunAnimation()
    {
        _animator.SetBool("isRun",true);
        _animator.SetBool("isIdle",false);
    }  
    public void IdleAnimation()
    {
        _animator.SetBool("isRun",false);
        _animator.SetBool("isIdle",true);
    }
    
    public void PlayPlayerSound()
    {
        AudioManager.Instance.PlayClipFx(_audioClip,0.5f);
    }

}
