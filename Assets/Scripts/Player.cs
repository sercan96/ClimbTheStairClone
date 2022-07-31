using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private ParticleSystem[] PlayerParticles;
    [SerializeField] private Color[] _playerColor;
    
    public static Animator Animator;
    public float Stamine;

    private Material _playerMat;
    private float maxSpeed = 10;
    private float _decreaseAmount = 15;

    
    void OnEnable()
    {
        EventManager.MousePressEvent += RunAnimation;
        EventManager.MousePressEvent += PlayPlayerSound;
        EventManager.MousePressEvent += DecreaseStamine;
    }
    void OnDisable()
    {
        EventManager.MousePressEvent -= RunAnimation;
        EventManager.MousePressEvent -= PlayPlayerSound;
        EventManager.MousePressEvent -= DecreaseStamine;
    }

    void Start()
    {
        _playerMat = gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material;
        Animator = GetComponent<Animator>();
        Stamine = 5;
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

    public void RaiseStamine() // Mouse El çekince
    {
        StopSweatingAnim();
        Blushing(_playerColor[0],1f);
        Stamine += Time.deltaTime;
        Stamine= Mathf.Min(Stamine, maxSpeed);
        Debug.Log(Stamine);
    }  
    public void DecreaseStamine() // Mouse Press
    {
        Stamine -= _decreaseAmount * Time.deltaTime;
        Stamine = Mathf.Max(Stamine, 0);

        if (Stamine <= 2 && Stamine >=0 )
        {
            RunSweatingAnim();
            Blushing(_playerColor[1],1f);
        }

        if (Stamine <= 0)
        {
            Die();
        }
        Debug.Log(Stamine);
    }

    public void Die()
    {
        PlayerParticles[1].Play();
        Destroy(gameObject,0.3f);
    }

    private void RunSweatingAnim()
    {
        PlayerParticles[0].Play();
    }
    
    private void StopSweatingAnim()
    {
        PlayerParticles[0].Stop();
    }

    private void Blushing(Color color,float duration)
    {
        _playerMat.DOColor(color, duration);
    }

}
