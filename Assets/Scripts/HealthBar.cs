using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    //Karakterimizin caný çoktan aza doðru deðiþtikçe healthbarýn renginin yeþil-sarý-kýrmýzý olarak upgradelenmesini istiyoruz. 
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        //1f dediði color gradient 0 ile 1 arasýnda deðer alýr ve benim gradientimde 0 kýrmýzý ortasý sarý ve 1 ise yeþil olacak yani yeþil renginden  baþlayacak demek
        fill.color = gradient.Evaluate(1f);

    }

    public void SetHealth(int health)
    {
        slider.value = health;

        //burda normalizedvalue diyorum çünkü gradient 0 ile 1 arasýnda deðer alýrken benim renk valuem 0 ile 100 arasýnda alýyor yani burda aslýnda deðerleri orantýlýyoruz.
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
