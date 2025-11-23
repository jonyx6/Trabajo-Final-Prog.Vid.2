using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Atributos))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class ControllerSystem : MonoBehaviour
{
    private Atributos _atributos;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SistemaDeSalud _sistemDeSalud;
    private Camera cam;
    private Mochila _mochila;
    private Vector2 target;// guarda la posicion donde hago el clik
    private Vector2 direccion;

    private BotonDeObjeto botonDeAtaque;
    private BotonDeObjeto botonDeAtaqueEspecial;
    private BotonDeObjeto botonDeManzana;
    private BotonDeObjeto botonDePocion;

    [SerializeField]
    private float recuperacionDeAtaque;
    [SerializeField]
    private float recuperacionDeAtaqueEspecial;

    private StaminaSystem _StaminaSistem;


    private void Awake()
    {
        cam = Camera.main;
        target = transform.position;
        _animator = GetComponent<Animator>();
        _sistemDeSalud = GetComponent<SistemaDeSalud>();
        _atributos = GetComponent<Atributos>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _mochila = GetComponent<Mochila>();
        botonDeAtaque = GameObject.Find("SlotAtaque").GetComponent<BotonDeObjeto>();
        botonDeAtaqueEspecial = GameObject.Find("SlotFlechas").GetComponent<BotonDeObjeto>();
        _StaminaSistem = GetComponent<StaminaSystem>();
    }

    void OnEnable()
    {
        _sistemDeSalud.OnDie += Morir;
    }

    private void Update()
    {
        
        
            if (Input.GetMouseButtonDown(0))
            {
                target = cam.ScreenToWorldPoint(Input.mousePosition);//comvierte las cordenadad del screen en las del wordspace
            }
            if (Input.GetKeyDown(KeyCode.R) && botonDeAtaque.SePuedeUsar())
            {
                Atacar();
                botonDeAtaque.Usar(recuperacionDeAtaque);
            }
            if (Input.GetKeyDown(KeyCode.W) && _mochila.SePuedeUsarUnItem(ItemsDeMochila.Flecha))
            {
                _mochila.UsarItem(ItemsDeMochila.Flecha);
                AtacarEspecial();
                //botonDeAtaqueEspecial.Usar(recuperacionDeAtaqueEspecial);
            }
            if (Input.GetKeyDown(KeyCode.E) && _mochila.SePuedeUsarUnItem(ItemsDeMochila.Manzana))
            {
                _mochila.UsarItem(ItemsDeMochila.Manzana);
                _sistemDeSalud.CambiarVida(_atributos.Vida + 1);
            }

            if (EstaLejosDelObjetivo())
            {
                AsignarDireccion();
            }
            else
            {
                QuitarDireccion();
            }
        
       
    }
    void FixedUpdate()
    {
        if (EstaAtacando())
        {
            return;
        }
        _rigidbody2D.MovePosition(_rigidbody2D.position + direccion * _atributos.Velocidad);
    }
    private void AsignarDireccion()
    {
        _animator.SetBool("isWalk", true);
        direccion = (target - (Vector2)transform.position).normalized;
        if (direccion.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    private void QuitarDireccion()
    {
        _animator.SetBool("isWalk", false);
        direccion = Vector2.zero;
    }
    private bool EstaLejosDelObjetivo()
    {
        return Vector2.Distance(target, (Vector2)transform.position) > 0.2f;
    }
    public bool EstaAtacando()
    {
        AnimatorStateInfo estado = _animator.GetCurrentAnimatorStateInfo(0);
        return estado.IsName("attack1") || estado.IsName("attack2") || estado.IsName("especialAtack");
    }

    private void Atacar()
    {
        _animator.SetTrigger("isAtack");
        _StaminaSistem.RestarUna_DeEstamina(_StaminaSistem.cansancionProAtacque);


    }
    private void AtacarEspecial()
    {
        _animator.SetTrigger("isEspecialAtack");
        //la flecha se dispara con un animation event
        _StaminaSistem.RestarUna_DeEstamina(_StaminaSistem.cansancionProAtacque * 3);
    }
    private void Morir()
    {
        this.enabled = false;
        StartCoroutine(Reiniciar());
    }
    IEnumerator Reiniciar()
    {
        NotificationSystem.Instance.ShowMessage("Has Muerto", 4);
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }







}
