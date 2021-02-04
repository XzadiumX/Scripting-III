using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController  : MonoBehaviour
{
    [Header("Físicas")]
    public float velocidadAndar = 3.0F;
    public float velocidadCorrer = 5.0f;
    public float velocidadDeslizar = 10.0f;
    public float aceleracion = 5.0f;
    public float velocidadPegadoAlSuelo = -10;
    public float velocidadRotacion = 90;
    public float velocidadSalto = 5;
    public float gravedad = -9.8f;

    [Header("Input")]
    public string inputAxisMovZ = "Vertical";
    public string inputAxisMovX = "Horizontal";
    public string inputAxisRotY = "Mouse X";
    public string inputAxisRotCameraX = "Mouse Y";

    Vector3 velXZLocal;
    Vector3 velDeslizarGlobal;
    float velocidadY;
    float velocidadAngular;
    float anguloCamara = 0;

    CharacterController cmpCC;
    Camera cmpCamera;
    public Interaction_UI player_UI;


    bool saltando = false;
    bool agachado = false;
    bool deslizando = false;

    public GameObject granadaTocha;
    public GameObject granadaDebil;
    float CD;
    public GrenadeInfo g_data;
    float nextGrenade= 0;

    private void Awake()
    {
        cmpCC = GetComponent<CharacterController>();
        cmpCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Start()
    {
        CD = g_data.CD;
    }


    void Update()
    {
        
        AplicarGravedad();
        Rotar();
        RotarCamara();
        Agarchar();
        Deslizar();
        Mover();
        ComprobarSuelo();
        Saltar();
        Interact();
        nextGrenade -= Time.deltaTime;
        if (nextGrenade<=0)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                LanzarGranada();
                nextGrenade = CD;
            }
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            LanzarGranadaDebil();
            nextGrenade = CD;
        }
    }

    private void Interact()
    {
        player_UI.CanvasUI.SetActive(false);
        //player_UI.IsActive = false;
        Ray ray;
        RaycastHit hit;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, 5))
        {
            if(hit.collider.gameObject.tag == "Item")
            {
                
                player_UI.CanvasUI.SetActive(true);
                //player_UI.IsActive = true;
                hit.collider.gameObject.GetComponent<Item_Behavior>().Observe();
                Debug.Log("Veo");
                if(Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.gameObject.GetComponent<Item_Behavior>().Take();
                }
            }
        }
    }

    private void Saltar()
    {
        if (cmpCC.isGrounded && Input.GetKeyDown(KeyCode.Space) && !deslizando)
        {
            saltando = true;
            velocidadY = velocidadSalto;
        }
    }

    private void ComprobarSuelo()
    {
        if (saltando && velocidadY < 0)
        {
            if (cmpCC.isGrounded) { saltando = false; }
        }
        if (!saltando)
        {
            if (cmpCC.isGrounded) { velocidadY = velocidadPegadoAlSuelo; }
        }
    }

    private void AplicarGravedad()
    {
        velocidadY += gravedad * Time.deltaTime;
    }

    private void Agarchar()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (!agachado) { ActivarAgachado(); }
        }
        else
        {
            if (agachado && PuedoLevantarme())
            {
                DesactivarAgachado();
            }
        }
    }

    private bool PuedoLevantarme()
    {
        Vector3 floor = this.transform.position + cmpCC.center - Vector3.up * cmpCC.height / 2;
        Ray ray = new Ray(floor, Vector3.up);
        return !Physics.SphereCast(ray, cmpCC.radius + cmpCC.skinWidth, cmpCC.height);
    }

    private void DesactivarAgachado()
    {
        agachado = false;
        cmpCC.height = 2;
        cmpCC.center = Vector3.zero;
        cmpCamera.transform.localPosition = Vector3.up * 0.5f;
    }

    private void ActivarAgachado()
    {
        agachado = true;
        cmpCC.height = 1;
        cmpCC.center = new Vector3(0, -0.5f, 0);
        cmpCamera.transform.localPosition = Vector3.zero;
    }

    private void Mover()
    {
        float magnitudVelocidad = Input.GetKey(KeyCode.LeftShift) ? velocidadCorrer : velocidadAndar;

        float inputZ = string.IsNullOrEmpty(inputAxisMovZ) ? 0 : Input.GetAxis(inputAxisMovZ);
        float inputX = string.IsNullOrEmpty(inputAxisMovX) ? 0 : Input.GetAxis(inputAxisMovX);
        Vector3 inputNormalizado = new Vector3(inputX, 0, inputZ);
        if (inputNormalizado.magnitude > 1) { inputNormalizado.Normalize(); }

        Vector3 velXZLocalDeseada = inputNormalizado * magnitudVelocidad;
        velXZLocal = Vector3.MoveTowards(velXZLocal, velXZLocalDeseada, aceleracion * Time.deltaTime);

        Vector3 velXZGlobal = transform.TransformDirection(velXZLocal);
        Vector3 velocidadTotal = velXZGlobal + velDeslizarGlobal + Vector3.up * velocidadY;
        cmpCC.Move(velocidadTotal * Time.deltaTime);
    }


    protected virtual void Rotar()
    {
        float input = string.IsNullOrEmpty(inputAxisRotY) ? 0 : Input.GetAxis(inputAxisRotY);
        velocidadAngular = input * velocidadRotacion;
        transform.Rotate(Vector3.up * velocidadAngular * Time.deltaTime);
    }


    private void RotarCamara()
    {
        if (cmpCamera != null && !string.IsNullOrEmpty(inputAxisRotCameraX))
        {
            anguloCamara += Input.GetAxis(inputAxisRotCameraX) * velocidadRotacion * Time.deltaTime;
            anguloCamara = Mathf.Clamp(anguloCamara, -90, 90);
            cmpCamera.transform.localRotation = Quaternion.Euler(-anguloCamara, 0, 0);
        }
    }

    private void Deslizar()
    {
        deslizando = false;

        Vector3 direccionDeslizamiento = Vector3.zero;
        RaycastHit infoImpacto;
        if (Physics.SphereCast(this.transform.position + cmpCC.center, 0.5f, Vector3.down, out infoImpacto, 1))
        {
            Vector3 normalSuperficie = infoImpacto.normal;
            Debug.DrawRay(infoImpacto.point, normalSuperficie, Color.green, 1);
            float angulo = Vector3.Angle(normalSuperficie, Vector3.up);
            if (angulo > cmpCC.slopeLimit)
            {
                deslizando = true;

                direccionDeslizamiento = normalSuperficie;
                direccionDeslizamiento.y = 0;
                direccionDeslizamiento.Normalize();
            }
        }

        if (deslizando) { velDeslizarGlobal = Vector3.Lerp(velDeslizarGlobal, direccionDeslizamiento * velocidadDeslizar, Time.deltaTime * 2); }
        else { velDeslizarGlobal = Vector3.zero; }
    }

    void LanzarGranada()
    {
        GameObject grenade = Instantiate(granadaTocha, transform.position, transform.rotation);
        
    }

    void LanzarGranadaDebil()
    {
        GameObject grenade = Instantiate(granadaDebil, transform.position, transform.rotation);
    }


}

