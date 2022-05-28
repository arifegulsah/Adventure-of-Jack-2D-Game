using UnityEngine;


[System.Serializable]
public class Diyalogue 
    //: MonoBehaviour //monobehavior ile demek istiyoruz ki biz bu scripti gameobjectlerimize entegre edebilelim. Ama bu scriptimiz biraz �zel olacak. O y�zden monobehavior de�il.
{

    public string name; //Bu bizim NPC Not Player Characterimizin ad� k�sm� i�in

    [TextArea(3,10)]
    public string[] sentences; //Bu da konu�malar i�in.


}
