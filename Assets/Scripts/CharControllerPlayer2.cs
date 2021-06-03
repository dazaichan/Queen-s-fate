using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControllerPlayer2 : MonoBehaviour
{
    public GameObject[] hitColliders;
    public GameObject fire;
    public GameObject[] enemies;
    public float maxWalkSpeed;
    public float jumpSpeed;
    public GameObject groundPoint;
    public float checkRadius;
    public LayerMask groundLayer;
    public bool covering;
    public bool hurt;
    public GameObject shield;
    public GameObject ultEffects;
    public Camera myCam;
    public Transform targetCam;
    public AudioClip[] audios;
    public AudioClip[] audiosTamachi;
    public AudioSource audioEffects;

    Vector3 playerVelocity;
    Animator charAnim;
    Rigidbody rigidbody;
    public ParticleSystem fireParticles;

    [SerializeField]
    bool grounded;
    float right = -0.6f;
    float left = 0.6f;
    [SerializeField]
    bool jumping;
    [SerializeField]
    bool kicking;
    [SerializeField]
    bool firing;
    [SerializeField]
    bool ulting;
    bool comboPossible;
    bool canJump;
    int comboStep;
    Vector3 beforeJumpPos;


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
        ulting = false;
        hurt = false;
        beforeJumpPos = Vector3.zero;
    }

    void Update()
    {
        myCam.transform.LookAt(targetCam);

        var main = fireParticles.main;
        main.simulationSpeed = 2;

        if (Physics.OverlapSphere(groundPoint.transform.position, checkRadius, groundLayer).Length > 0 && !jumping) grounded = true;
        else grounded = false;

        playerVelocity.x = Input.GetAxis("HorizontalPlayer2") * maxWalkSpeed;

        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded && !covering && !firing && !kicking && !ulting && !hurt)
        {
            jumping = true;
            beforeJumpPos = this.transform.position;
            playerVelocity.y = jumpSpeed;
            charAnim.SetBool("isJumping", true);
            if (this.name == "YuraIA")
            {
                this.GetComponent<AudioSource>().clip = audios[0];
            }
            else
            {
                this.GetComponent<AudioSource>().clip = audiosTamachi[0];
            }
            this.GetComponent<AudioSource>().volume = 1f;
            this.GetComponent<AudioSource>().pitch = 1f;
            this.GetComponent<AudioSource>().Play();
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

        if (Input.GetKeyDown(KeyCode.Keypad0) && grounded && !covering && !firing && !ulting && !hurt && !jumping)
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.Keypad1) && grounded && !covering && !kicking && !ulting && !hurt && !jumping)
        {
            if (transform.GetComponent<FireChargeManager>().m_CurrentHealth == 100)
            {
                SetFreezePos();
                charAnim.SetBool("isFiring", true);
                if (this.name == "YuraIA")
                {
                    this.GetComponent<AudioSource>().clip = audios[5];
                    this.GetComponent<AudioSource>().volume = 0.3f;
                }
                else
                {
                    this.GetComponent<AudioSource>().clip = audiosTamachi[5];
                    this.GetComponent<AudioSource>().volume = 2f;
                }
                this.GetComponent<AudioSource>().pitch = 1f;
                this.GetComponent<AudioSource>().Play();
                firing = true;
                transform.GetComponent<FireChargeManager>().m_CurrentHealth = 0;
            }
        }

        if (Input.GetKey(KeyCode.Keypad2) && grounded && !kicking && !firing && !covering && !hurt && !jumping)
        {
            if (transform.GetComponent<UltiChargeManager>().m_CurrentHealth == 100)
            {
                SetFreezePos();
                charAnim.SetBool("tryUlt", true);
                if (this.name == "YuraIA")
                {
                    this.GetComponent<AudioSource>().clip = audios[7];
                }
                else
                {
                    this.GetComponent<AudioSource>().clip = audiosTamachi[7];
                }
                this.GetComponent<AudioSource>().pitch = 1f;
                this.GetComponent<AudioSource>().volume = 1f;
                this.GetComponent<AudioSource>().Play();
                ulting = true;
                transform.GetComponent<UltiChargeManager>().m_CurrentHealth = 0;
            }
        }
        if (Input.GetKey(KeyCode.DownArrow) && grounded && !kicking && !firing && !ulting && !hurt && !jumping)
        {
            SetFreezePos();
            charAnim.SetBool("isCovering", true);
            shield.SetActive(true);
            covering = true;
        }
        else if (!kicking && !firing && !ulting && !hurt)
        {
            charAnim.SetBool("isCovering", false);
            covering = false;
            SetConstrains();
            shield.SetActive(false);
        }

        rigidbody.velocity = playerVelocity;
        if (playerVelocity.x != 0 && grounded && !jumping && !hurt)
        {
            if (!covering && !firing && !ulting && !kicking)
            {
                charAnim.SetBool("isWalking", true);
            }
        }
        else
        {
            charAnim.SetBool("isWalking", false);
        }
        if (!kicking && !covering && !firing && !ulting && !hurt)
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
    }
    public void CheckSetJumping()
    {
        if (Physics.OverlapSphere(groundPoint.transform.position, checkRadius, groundLayer).Length > 0)
        {
            jumping = false;
        }
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
        rigidbody.constraints = RigidbodyConstraints.FreezeAll;
    }

    public void SetConstrains()
    {
        rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX 
            | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
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
        if (this.name == "TamachiIA")
        {
            if (transform.localScale.z < 0)
            {
                //fire.transform.eulerAngles = new Vector3(0, 90, -90);
                fire.transform.rotation = Quaternion.Euler(new Vector3(0, 90, -90));
                fire.transform.localPosition = new Vector3(fire.transform.localPosition.x, fire.transform.localPosition.y, 0.78f);
                fire.GetComponent<BoxCollider>().center = new Vector3(fire.GetComponent<BoxCollider>().center.x,
                    fire.GetComponent<BoxCollider>().center.y, -6f);
            }
            else
            {
                //fire.transform.eulerAngles = new Vector3(0, -90, -90);
                fire.transform.rotation = Quaternion.Euler(new Vector3(0, 270, -90));
                fire.transform.localPosition = new Vector3(fire.transform.localPosition.x, fire.transform.localPosition.y, 0.78f);
                fire.GetComponent<BoxCollider>().center = new Vector3(fire.GetComponent<BoxCollider>().center.x,
                    fire.GetComponent<BoxCollider>().center.y, 5f);
            }
            fire.SetActive(true);
            fire.GetComponent<BoxCollider>().enabled = false;
            audioEffects.clip = audiosTamachi[6];
            audioEffects.pitch = 1f;
            audioEffects.volume = 0.5f;
            audioEffects.Play();
        }
        else
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
            audioEffects.clip = audios[6];
            audioEffects.pitch = 0.5f;
            audioEffects.volume = 1f;
            audioEffects.Play();
        }

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

    public void TryUltEnd()
    {
        charAnim.SetBool("tryUlt", false);
        ulting = false;
    }

    public void EnableMyCam()
    {
        myCam.gameObject.SetActive(true);
    }

    public void DisableMyCam()
    {
        myCam.gameObject.SetActive(false);
    }

    public void EnableUltEffects()
    {
        ultEffects.SetActive(true);
        if (this.name == "YuraIA")
        {
            audioEffects.clip = audios[9];
        }
        else
        {
            audioEffects.clip = audiosTamachi[9];
        }
    }

    public void DisableUltEffects()
    {
        ultEffects.SetActive(false);
    }
    public void Hurt()
    {
        hurt = true;
    }

    public void NoHurt()
    {
        hurt = false;
    }
    public void resetPlayer()
    {
        DisableUltEffects();
        DeactivateFire();
        ComboReset();
        for (int i = 0; i < hitColliders.Length; i++)
        {
            hitColliders[i].SetActive(false);
        }
        jumping = false;
        charAnim.SetBool("isJumping", false);
        covering = false;
        kicking = false;
        firing = false;
        canJump = false;
        ulting = false;
    }

    public void cancelJump()
    {
        if (jumping)
        {
            this.transform.position = beforeJumpPos;
        }
    }

    /*(public void adjustOrientation(Transform enemyTransform)
    {
        if (this.transform.localScale.z < 0 && enemyTransform.localScale.z > 0)
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y, 0.6f);
        }
        else if (this.transform.localScale.z > 0 && enemyTransform.localScale.z < 0)
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y, -0.6f);
        }
    }*/

    public void adjustOrientation()
    {
        Transform enemyTransform;
        if (enemies[0] != null)
        {
            enemyTransform = enemies[0].transform;
        }
        else
        {
            enemyTransform = enemies[1].transform;
        }

        if (this.transform.localScale.z < 0 && enemyTransform.localScale.z > 0)
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y, 0.6f);
        }
        else if (this.transform.localScale.z > 0 && enemyTransform.localScale.z < 0)
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y, -0.6f);
        }
    }

    public void playUltiAudio()
    {
        if (this.name == "YuraIA")
        {
            this.GetComponent<AudioSource>().clip = audios[8];
        }
        else
        {
            this.GetComponent<AudioSource>().clip = audiosTamachi[8];
        }
        this.GetComponent<AudioSource>().Play();
    }

    public void PlayCoverAudio()
    {
        if (this.name == "YuraIA")
        {
            this.GetComponent<AudioSource>().clip = audios[1];
        }
        else
        {
            this.GetComponent<AudioSource>().clip = audiosTamachi[1];
        }
        this.GetComponent<AudioSource>().pitch = 1f;
        this.GetComponent<AudioSource>().volume = 1f;
        this.GetComponent<AudioSource>().Play();
    }
}
