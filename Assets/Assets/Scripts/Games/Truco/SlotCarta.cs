using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotCarta : MonoBehaviour
{
    public CartaView cartaViewActual;

    public bool EstaLibre()
    {
        return cartaViewActual == null;
    }

    public void ColocarCarta(CartaView cartaView)
    {
        cartaViewActual = cartaView;
        cartaView.transform.position = transform.position;
        cartaView.transform.localScale = transform.localScale;
    }

    public void Vaciar()
    {
        cartaViewActual = null;
    }

}
