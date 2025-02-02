using System.Collections.Generic;
using UnityEngine;

public class BusinesSpawner : MonoBehaviour
{
    [SerializeField] private BusinessConfig _businessesConfig;
    [SerializeField] private BusinessController _businessPrefab;
    [SerializeField] private RectTransform _parent;
    [SerializeField] private Profit _profit; //Сделать через EventBus
    [SerializeField] private Timer _timer; //сделаем через EventBus
    [SerializeField] private ConfigSystem _configSystem;
    
    private readonly List<BusinessController> _controllers = new ();

    public void SpawnBusiness(BusinessModel[] businessModels)
    {
        foreach (var businessModel in businessModels)
        {
            var business = Instantiate(_businessPrefab, _parent);
            business.Initialize(businessModel, _configSystem);
            _timer.Initialize(_profit);
            _controllers.Add(business);
        }
    }
    public void DeleteComtrollers()
    {
        foreach (var controller in _controllers)
        {
            Destroy(controller.gameObject);
        }
        _controllers.Clear();
    }
    
}