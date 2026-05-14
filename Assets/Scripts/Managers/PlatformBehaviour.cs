using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    // Script done by Jorge Cristobal
    // Script state [IN PROGRESS]

    // Script done for managing the individual behaviour of each platform
    // Needed things:
    // - State machine for each of the parts where the platform is. It needs a behaviour for each of the phases
    // - For the top part: Gets current game speed multpliyer from PlatformManager and adds it to its velocity
    // - Middle part; just changes the state
    // - Bottom part: changes the state; it deactivates the platform itself and returns to the pool
    // - 

    // STATES
    private enum State {Top, Middle, Bottom }
    private State platformState;

    // COMPONENTS
    private Rigidbody rb;
    private float platformSpeed = 10f;

    // REFERENCES TO OTHER COMPONENTS
    private PlatformManager platformManager;

    private void Start()
    {
        platformState = State.Top;
        platformManager = GetComponent<PlatformManager>();
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = AddVelocity();
    }
    private Vector2 AddVelocity() 
    {
        float gameSpeedIncrementer = platformManager.GetGameIncrementer();
        return new Vector2(0, gameSpeedIncrementer * platformSpeed);
      
    }

    private void Update()
    {
        switch (platformState)
        {
            case State.Top:
                break;
            case State.Middle:
                break;
            case State.Bottom:
                EndPlatformLife();
                break;
        }
    }
    private void EndPlatformLife()
    {
        //gameObject.SetActive(false);
        
        platformManager.ReturnPlatformToPool(this.gameObject);
        Debug.Log("Plataforma Devuelta");
    }
    // Funcion para cambiar el comportamiento de la plataforma entre secciones.
    public void ChangePlatformPoint()
    {
        // En cuanto entre en camara se activa. Cuando salga se desactiva y vuelve al pool.

    }
    //public void ChangeStatePlatform(State newState)
    //{
    //    if (newState < platformState) return;
    //    platformState = newState;
    //}
}
