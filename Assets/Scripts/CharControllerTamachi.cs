using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControllerTamachi : MonoBehaviour
{
    public GameObject[] hitColliders;
    public GameObject fire;
    public float maxWalkSpeed;
    public float jumpSpeed;
    public GameObject groundPoint;
    public float checkRadius;
    public LayerMask groundLayer;
    public bool covering;
    public GameObject shield;

    Vector3 playerVelocity;
    Animator charAnim;
    Rigidbody rigidbody;

    [SerializeField]
    bool grounded;
    float left = -0.7f;
    float right = 0.7f;
    [SerializeField]
    bool jumping;
    [SerializeField]
    bool kicking;
    [SerializeField]
    bool firing;
    bool comboPossible;
    bool canJump;
    int comboStep;
    private ParticleSystem fireParticles;


    void Start()
    {
        playerVelocity = Vector3.zero;
        charAnim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        jumping = false;
        covering = false;
        kicking = false;
        firing = false;
        canJump = false;
        fireParticles = fire.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        var main = fireParticles.main;
        main.simulationSpeed = 2;

        if (Physics.OverlapSphere(groundPoint.transform.position, checkRadius, groundLayer).Length > 0 && !jumping) grounded = true;
        else grounded = false;

        playerVelocity.x = Input.GetAxis("Horizontal") * maxWalkSpeed;

        if (Input.GetKeyDown(KeyCode.Space) && grounded && !covering && !firing && !kicking)
        {
            jumping = true;
            playerVelocity.y = jumpSpeed;
            charAnim.SetBool("isJumping", true);
        }
        else if (grounded && !jumping)
        {
            charAnim.SetBool("isJumping", false);
            playerVelocity.y = rigidbody.velocity.y;
        }
        else
        {
            playerVelocity.y = rigidbody.velocity.y;
        }

        if (Input.GetKeyDown(KeyCode.G) && grounded && !covering && !firing)
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.B) && grounded && !covering && !kicking)
        {
            if (transform.GetComponent<FireChargeManager>().m_CurrentHealth == 100)
            {
                SetFreezePos();
                charAnim.SetBool("isFiring", true);
                firing = true;
                transform.GetComponent<FireChargeManager>().m_CurrentHealth = 0;
            }
        }

        if (Input.GetKey(KeyCode.H) && grounded && !kicking && !firing)
        {
            SetFreezePos();
            charAnim.SetBool("isCovering", true);
            shield.SetActive(true);
            covering = true;
        }
        else if (!kicking && !firing)
        {
            charAnim.SetBool("isCovering", false);
            covering = false;
            SetConstrains();
            shield.SetActive(false);
        }

        rigidbody.velocity = playerVelocity;
        if (playerVelocity.x != 0 && grounded && !jumping)
        {
            if (!covering)
            {
                charAnim.SetBool("isWalking", true);
            }
        }
        else
        {
            charAnim.SetBool("isWalking", false);
        }
        if (!kicking && !covering && !firing)
        {
            if (playerVelocity.x < 0)
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, left);
            }
            else if (playerVelocity.x > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, right);
            }
        }
    }

    public void SetJumping()
    {
        jumping = false;
        print("Segundo evento");
    }

    public void SetKicking()
    {
        kicking = true;
    }

    public void SetNotKicking()
    {
        kicking = false;
    }

    public void SetFreezePos()
    {
        rigidbody.constraints = RigidbodyConstraints.FreezePosition;
    }

    public void SetConstrains()
    {
        rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }

    public void activateHit(int i)
    {
        hitColliders[i].SetActive(true);
    }
    public void deactivateHit(int i)
    {
        hitColliders[i].SetActive(false);
        kicking = false;
    }

    public void ActivateFire()
    {
        if (transform.localScale.z < 0)
        {
            fire.transform.localScale = new Vector3(fire.transform.localScale.x, fire.transform.localScale.y, -1);
            fire.GetComponent<BoxCollider>().center = new Vector3(fire.GetComponent<BoxCollider>().center.x,
                fire.GetComponent<BoxCollider>().center.y, -4.5f);
        }
        else
        {
            fire.transform.localScale = new Vector3(fire.transform.localScale.x, fire.transform.localScale.y, 1);
            fire.GetComponent<BoxCollider>().center = new Vector3(fire.GetComponent<BoxCollider>().center.x,
                fire.GetComponent<BoxCollider>().center.y, 4.5f);
        }
        fire.SetActive(true);
        fire.GetComponent<BoxCollider>().enabled = false;
    }

    public void EnableFireCollider()
    {
        fire.GetComponent<BoxCollider>().enabled = true;
    }

    public void DeactivateFire()
    {
        fire.GetComponent<BoxCollider>().enabled = false;
        fire.SetActive(false);
    }

    public void EndFiring()
    {
        firing = false;
        charAnim.SetBool("isFiring", false);
    }

    public void Attack()
    {
        if (comboStep == 0)
        {
            charAnim.Play("Kick1");
            comboStep = 1;
            return;
        }
        if (comboStep != 0)
        {
            if (comboPossible)
            {
                comboPossible = false;
                comboStep++;
            }
        }
    }

    public void ComboPossible()
    {
        comboPossible = true;
    }

    public void Combo()
    {
        if (comboStep == 2)
        {
            charAnim.Play("Kick2");
        }
        if (comboStep == 3)
        {
            charAnim.Play("Kick3");
        }
    }

    public void ComboReset()
    {
        comboPossible = false;
        comboStep = 0;
    }

    public void CanJump()
    {

    }
}
