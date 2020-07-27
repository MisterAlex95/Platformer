using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
   public Slider slider;

   public Gradient gradient;
   public Image fill;

   public void setMaxHealth(int _maxHealth) {
       slider.maxValue = _maxHealth;
       slider.value = _maxHealth;

       fill.color = gradient.Evaluate(1f);
   }

   public void setHealth(int _health) {
        slider.value = _health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
   }
}
