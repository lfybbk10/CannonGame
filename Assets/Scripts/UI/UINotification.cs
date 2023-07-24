using TMPro;
using UnityEngine;


public class UINotification : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        GameProgressEvents.OnDifficultyIncreased.Add(SetDifficultyIncrease);
        BoosterEvents.OnUpgradeCannonDamage.Add(SetUpgradeCannonDamage);
        BoosterEvents.OnUpgradeCannonSpeed.Add(SetUpgradeCannonSpeed);
        BoosterEvents.OnPauseEnemySpawner.Add(SetPauseSpawner);
        BoosterEvents.OnKillAllEnemies.Add(SetKillAllEnemies);
    }
    
    private void OnDisable()
    {
        GameProgressEvents.OnDifficultyIncreased.Remove(SetDifficultyIncrease);
        BoosterEvents.OnUpgradeCannonDamage.Remove(SetUpgradeCannonDamage);
        BoosterEvents.OnUpgradeCannonSpeed.Remove(SetUpgradeCannonSpeed);
        BoosterEvents.OnPauseEnemySpawner.Remove(SetPauseSpawner);
        BoosterEvents.OnKillAllEnemies.Remove(SetKillAllEnemies);
    }
    
    private void SetKillAllEnemies()
    {
        _text.gameObject.SetActive(true);
        _text.text = "<color=green>Все монстры уничтожены!</color>";
        Invoke("HideText",5f);
    }

    private void SetPauseSpawner(int obj)
    {
        _text.gameObject.SetActive(true);
        _text.text = "<color=green>Спаун монстров заморожен!</color>";
        Invoke("HideText",5f);
    }

    private void SetUpgradeCannonSpeed()
    {
        _text.gameObject.SetActive(true);
        _text.text = "<color=green>Скорость пушки увеличена!</color>";
        Invoke("HideText",5f);
    }

    private void SetUpgradeCannonDamage()
    {
        _text.gameObject.SetActive(true);
        _text.text = "<color=green>Урон снарядов увеличен!</color>";
        Invoke("HideText",5f);
    }

    private void SetDifficultyIncrease()
    {
        _text.gameObject.SetActive(true);
        _text.text = "<color=red>Сложность увеличена!</color>";
        Invoke("HideText",5f);
    }

    private void HideText()
    {
        _text.gameObject.SetActive(false);
    }
}
