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

    [SerializeField] private GameObject impactBalleAnim;

    [SerializeField] private Text scoreText;
    
    void Awake()
    {
        controls = new PlayControls();

        rb = GetComponent<Rigidbody2D>();
        scAudioManager = GetComponent<SC_AudioManager>();

        if (isP1)
        {
            controls.P1.MoveCrossair.performed += OnMoveCrossair;
            controls.P1.MoveCrossair.canceled += ctx => rb.velocity = Vector2.zero;
            controls.P1.Shoot.performed += OnShoot;
            controls.P1.Reload.performed += OnReload;

            this.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else
        {
            controls.P2.MoveCrossair.performed += OnMoveCrossair;
            controls.P2.MoveCrossair.canceled += ctx => rb.velocity = Vector2.zero;
            controls.P2.Shoot.performed += OnShoot;
            controls.P2.Reload.performed += OnReload;

            this.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    public void updateScore(int STATIC_ENNEMIE_POINTS)
    {
        scoreText.GetComponent<SC_ScoreUI>().updateScore(isP1, STATIC_ENNEMIE_POINTS);
    }

    public void OnMoveCrossair(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        rb.velocity = direction * movementSpeed;
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
