using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using TowerDefense;
using UnityEngine.UI;

public class AbilityComponent : MonoBehaviour
{
    [SerializeField] private BaseComponent m_baseComponent;
    [SerializeField] private PlayerData m_playerData;
    private int m_ability1Price;
    private bool m_isBuilding;

    private Plane plane = new Plane(Vector3.up, 0);
    private InputController _input;
    private Ray ray;
    
    private bool m_inCooldown;
    [SerializeField] private TextMeshProUGUI m_TimeBombText;
    [SerializeField] private Button BombButton;
    [SerializeField] private TextMeshProUGUI m_TimeSlowText;
    [SerializeField] private Button SlowButton;
    
    private void Awake()
    {
        _input = new InputController();
        _input.Enable();
        m_isBuilding = false;
    }
    
    public void SetSlow(GameObject ability)
    {
        if (m_isBuilding)
        {
            return;
        }
        m_isBuilding = true;
        
        GameObject newAbility = Instantiate(ability, new Vector3(55, 5, 5), Quaternion.identity);
        StartCoroutine(AbilityBuilding(newAbility));
    }
    
    IEnumerator AbilityBuilding(GameObject ability)
    {
        Camera _camera = Camera.main;

        while (true)
        {
            ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());
            
            if (plane.Raycast(ray, out float distance))
            {
                ability.transform.position = ray.GetPoint(distance);

                if (Input.GetKey(KeyCode.Mouse0))
                {
                    m_isBuilding = false;
                    var bombAbility = ability.GetComponent<BaseAbility>();

                    switch (bombAbility)
                    {
                        case BombAbility:
                            
                            bombAbility.StartTimer(m_TimeBombText, BombButton);
                            break;
                        
                        case SlowDownAbility:
                            bombAbility.StartTimer(m_TimeSlowText, SlowButton);
                            break;
                    }
                    break;
                }
            }
            yield return new WaitForEndOfFrame();
        }
        yield return null;
    }
    
    public void Heal()
    {
        if (m_playerData.CheckCoins(500))
        {
            m_baseComponent.AddHeath(5);
        }
    }
    
    private void OnRayCast()
    {
        Camera _camera = Camera.main;
        ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());
    }
}
