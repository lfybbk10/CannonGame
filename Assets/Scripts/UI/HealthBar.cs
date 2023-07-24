using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(IHP))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Image _image;

    private Camera _camera;
    
    private IHP _hp;

    private float _maxValue;
    
    private void Awake()
    {
        _hp = GetComponent<IHP>();
        _camera = Camera.main;
    }

    private void Start()
    {
        _maxValue = _hp.GetMaxValue();
    }

    private void OnEnable()
    {
        _image.fillAmount = _hp.GetValue() / _hp.GetMaxValue();
        _hp.OnValueChanged += UpdateBar;
    }

    private void OnDisable()
    {
        _hp.OnValueChanged -= UpdateBar;
    }

    private void UpdateBar(float value)
    {
        _image.fillAmount = value / _maxValue;
    }

    private void LateUpdate()
    {
        _canvas.transform.LookAt(_camera.transform);
    }
}
