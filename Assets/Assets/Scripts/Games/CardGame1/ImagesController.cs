using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImagesController : MonoBehaviour
{
    public Cards CardValue;

    [SerializeField] Image[] _CardImages = new Image[3];

    private void Awake()
    {
        EventManager.SubscribeToEvent(EventsType.StartCardGame, ImageAsigner);
        EventManager.SubscribeToEvent(EventsType.ActiveTrick, OffDorse);
    }
    public void ImageAsigner(object[] p)
    {
        if(CardValue.CardValue != 0)
        {
            _CardImages[0].enabled = true;
            _CardImages[1].enabled = true;
            _CardImages[2].enabled = false;
        }
        else if(CardValue.CardValue == 0)
        {
            _CardImages[0].enabled = true;
            _CardImages[1].enabled = false;
            _CardImages[2].enabled = true;
        }
    }

    public void OffDorse(object[] p)
    {
        StartCoroutine(CeroOff());
    }

    private IEnumerator CeroOff()
    {
        _CardImages[0].enabled = false;
        yield return new WaitForSeconds(3f);
        _CardImages[0].enabled = true;
    }
}
