using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Toggle : MonoBehaviour, ITouchable
{
    [SerializeField] Color _onColor = Color.green;
    [SerializeField] Color _offColor = Color.red;
    [SerializeField] SpriteRenderer _spriteRenderer;

    // Je veux ouvrir un évènement pour les designers pour qu'ils puissent set la couleur du sprite eux même
    [SerializeField] UnityEvent _onToggleChange;
    [SerializeField] UnityEvent _onToggleOn;
    [SerializeField] UnityEvent _onToggleOff;

    public bool IsActive { get; private set; }

    private void Awake()
    {
        IsActive = false;
        SetOffColor();
    }

    public void Touch(int power)
    {
        IsActive = !IsActive;

        _onToggleChange?.Invoke();

        if (IsActive) _onToggleOn?.Invoke();
        else _onToggleOff?.Invoke();
    }

    public void SetOnColor()
    {
        _spriteRenderer.color = _onColor;
    }

    public void SetOffColor()
    {
        _spriteRenderer.color = _offColor;
    }
}
