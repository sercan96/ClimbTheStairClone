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
    public static float Stamina;
    private int StartStamina = 10;
    public static int MaxStaminaValue = 10;

    private Material _playerMat;



    void OnEnable()
    {
        EventManager.MousePressEvent += RunAnimation;
        EventManager.MousePressEvent += PlayPlayerSound;
        EventManager.MousePressEvent += StaminaController;
        
    }
    void OnDisable()
    {
        EventManager.MousePressEvent -= RunAnimation;
        EventManager.MousePressEvent -= PlayPlayerSound;
        EventManager.MousePressEvent -= StaminaController;
    }

    void Start()
    {
        _playerMat = gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material;
        Animator = GetComponent<Animator>();
        Stamina = StartStamina;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            DecreaseStamina();
        }
    }

    private void RunAnimation()
    {
        Animator.SetBool("isRun",true);
        Animator.SetBool("isIdle",false);
    }  
    public static void IdleAnimation()
    {
        Animator.SetBool("isRun",false);
        Animator.SetBool("isIdle",true);
    }

    private void PlayPlayerSound()
    {
        AudioManager.Instance.PlayClipFx(_audioClip,0.5f);
    }

    public void RaiseStamina() // Mouse El çekince
    {
        StopSweatingAnim();
        Blushing(_playerColor[0],1f);
        Stamina += Time.deltaTime;
        Stamina= Mathf.Min(Stamina, MaxStaminaValue);
        Debug.Log(Stamina);
    }

    private void DecreaseStamina() // Mouse Press
    {
        Stamina -=Time.deltaTime;
        Stamina = Mathf.Max(Stamina, 0);
    }

    private void StaminaController()
    {
        if (Stamina <= 2 && Stamina >=0 )
        {
            Blushing(_playerColor[1],1f);
            ShapeShifting();
            RunSweatingAnim();
        }

        if (Stamina <= 0)
        {
            Die();
        } 
        Debug.Log(Stamina);
    }

    private void Die()
    {
        PlayerParticles[1].Play();
        Destroy(gameObject,0.3f);
        CanvasUI.Instance.LosePanel();
    }

    private void RunSweatingAnim()
    {
        Debug.Log("Bence giriyorsun");
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

    private void ShapeShifting()
    {
        transform.DOScale(.8f,.2f).SetEase(Ease.OutBounce)
            .OnComplete(() =>transform.DOScale(.7f,.2f));   
    }

}
