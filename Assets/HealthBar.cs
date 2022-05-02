using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    //Karakterimizin can� �oktan aza do�ru de�i�tik�e healthbar�n renginin ye�il-sar�-k�rm�z� olarak upgradelenmesini istiyoruz. 
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        //1f dedi�i color gradient 0 ile 1 aras�nda de�er al�r ve benim gradientimde 0 k�rm�z� ortas� sar� ve 1 ise ye�il olacak yani ye�il renginden  ba�layacak demek
        fill.color = gradient.Evaluate(1f);

    }

    public void SetHealth(int health)
    {
        slider.value = health;

        //burda normalizedvalue diyorum ��nk� gradient 0 ile 1 aras�nda de�er al�rken benim renk valuem 0 ile 100 aras�nda al�yor yani burda asl�nda de�erleri orant�l�yoruz.
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
