using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class SC_Player : MonoBehaviour, PlayControls.IP1Actions, PlayControls.IP2Actions
{
    public bool isP1;
    public float movementSpeed;
    public int nbBalleMax = 7;
    public int nbBalle = 7;
    public UnityEvent<bool> OnFireEvent; //UnityEvent<isP1>
    public UnityEvent<bool> OnReloadEvent; //UnityEvent<isP1>

    public Sprite crosshairSprite;
    public Sprite needReloadSprite;

    private PlayControls controls;
    private Rigidbody2D rb;
    private SC_AudioManager scAudioManager;
    private Vector2 direction = Vector2.zero;
    public static bool isGame = false;

    [SerializeField] private GameObject impactBalleAnim;

    [SerializeField] private static GameObject pauseBoutons = null;
    [SerializeField] private GameObject pauseBoutonsInspector = null;

    [SerializeField] private Text scoreText;
    
    void Awake()
    {
        controls = new PlayControls();

        rb = GetComponent<Rigidbody2D>();
        scAudioManager = GetComponent<SC_AudioManager>();

        if (pauseBoutonsInspector != null)
            pauseBoutons = pauseBoutonsInspector;

        if (isP1)
        {
            controls.P1.MoveCrossair.performed += OnMoveCrossair;
            controls.P1.MoveCrossair.canceled += ctx => direction = Vector2.zero; //rb.velocity = Vector2.zero;
            controls.P1.Shoot.performed += OnShoot;
            controls.P1.Reload.performed += OnReload;
            controls.P1.Pause.performed += OnPause;

            this.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else
        {
            controls.P2.MoveCrossair.performed += OnMoveCrossair;
            controls.P2.MoveCrossair.canceled += ctx => direction = Vector2.zero; //rb.velocity = Vector2.zero;
            controls.P2.Shoot.performed += OnShoot;
            controls.P2.Reload.performed += OnReload;
            controls.P2.Pause.performed += OnPause;

            this.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    private void Update()
    {
        if(Time.timeScale > 0)
            transform.position = transform.position + new Vector3(direction.x, direction.y, 0f)* movementSpeed * Time.deltaTime;
        else
            transform.position = transform.position + new Vector3(direction.x, direction.y, 0f)* movementSpeed * Time.fixedDeltaTime * 1/20;

    }

    public void updateScore(int STATIC_ENNEMIE_POINTS)
    {
        scoreText.GetComponent<SC_ScoreUI>().updateScore(isP1, STATIC_ENNEMIE_POINTS);
    }

    public void OnMoveCrossair(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (nbBalle > 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);

            if (hit.collider != null)
            {
                var hitObjectRigibody = hit.rigidbody;
                if (hitObjectRigibody.CompareTag("Shootable"))
                {
                    IShootable shootableScript = (IShootable)hitObjectRigibody.gameObject.GetComponent<IShootable>();
                    shootableScript.GetShoot(this);
                }
            }

            Instantiate(impactBalleAnim, new Vector3(transform.position.x, transform.position.y, -30f), Quaternion.identity);

            nbBalle -= 1;
            OnFireEvent?.Invoke(isP1);

            scAudioManager.playFireSound();
        }

        updateCrosshair();
    }

    //public void OnShoot(InputAction.CallbackContext context)
    //{
    //    if (nbBalle > 0)
    //    {
    //        var oi = Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hit, Mathf.Infinity, 0);
    //        Debug.Log(oi);

    //        if (oi)
    //        {
    //            Debug.Log("TOUCHER");
    //            var hitObjectRigibody = hit.rigidbody;
    //            if (hitObjectRigibody.CompareTag("Shootable"))
    //            {
    //                IShootable shootableScript = (IShootable)hitObjectRigibody.gameObject.GetComponent<IShootable>();
    //                shootableScript.GetShoot(this); 
    //            }
    //        }

    //        Debug.Log("On tire");

    //        Instantiate(impactBalleAnim, new Vector3(transform.position.x, transform.position.y, -30f), Quaternion.identity);

    //        nbBalle -= 1;
    //        OnFireEvent?.Invoke(isP1);

    //        scAudioManager.playFireSound();
    //    }

    //    updateCrosshair();
    //}

    public void OnReload(InputAction.CallbackContext context)
    {
        nbBalle = nbBalleMax;
        OnReloadEvent?.Invoke(isP1);
        updateCrosshair();
        scAudioManager.playReloadSound();
    }

    private void updateCrosshair()
    {
        Sprite updatedCrosshair;
        if (nbBalle <= 0)
        {
            updatedCrosshair = needReloadSprite;
        } else
        {
            updatedCrosshair = crosshairSprite;
        }

        this.gameObject.GetComponent<SpriteRenderer>().sprite = updatedCrosshair;
    }
    
    public static void Pause()
    {
        if(isGame && pauseBoutons != null)
        {
            if (Time.timeScale > 0)
            {
                Time.timeScale = 0;
                pauseBoutons.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                pauseBoutons.SetActive(false);
            }
        }
    }
    
    public void OnPause(InputAction.CallbackContext context)
    {
        Pause();
    }

    private void OnEnable()
    {
        if (isP1)
        {
            controls.P1.Enable();
        }
        else
        {
            controls.P2.Enable();
        }
    }

    private void OnDisable()
    {
        if (isP1)
        {
            controls.P1.Disable();
        }
        else
        {
            controls.P2.Disable();
        }
    }

}
