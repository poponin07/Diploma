using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Score;
using TowerDefense;

public class AbilityComponent : MonoBehaviour
{
    [SerializeField] private BaseComponent m_baseComponent;
    [SerializeField] private PlayerData m_playerData;
    [SerializeField] private ScoreComponent m_scoreComponent;
    [SerializeField] private GameObject m_ability;
    private int m_ability1Price;

    private Plane plane = new Plane(Vector3.up, 0);
    private InputController _input;
    private Ray ray;
    private void Awake()
    {
        _input = new InputController();
        _input.Enable();
    }

    IEnumerator UseAbility(GameObject ability)
    {
        GameObject newAbility = Instantiate(m_ability, new Vector3(55, 5, 5), Quaternion.identity);
        Camera _camera = Camera.main;

        while (true)
        {
            plane.Raycast(ray, out float distance);
            newAbility.transform.position = ray.GetPoint(distance);
        
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                StartCoroutine(StartAbility());
                break;
            }   
        }

        yield return null;
    }

    IEnumerator StartAbility()
    {
        yield return null;
    }

    public void Heal()
    {
        if (m_playerData.CheckCoins(500))
        {
            m_baseComponent.AddHeath(5);
        }
    }
    
    public void AddScore()
    {
        if (m_playerData.CheckCoins(200))
        {
            m_scoreComponent.UpdateScore(100);
            
        }
    }
    
    private void OnRayCastPlayer()
    {
        Camera _camera = Camera.main;
        ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());
    }

    
}
