using UnityEngine;


[System.Serializable]
public class Diyalogue 
    //: MonoBehaviour //monobehavior ile demek istiyoruz ki biz bu scripti gameobjectlerimize entegre edebilelim. Ama bu scriptimiz biraz özel olacak. O yüzden monobehavior deðil.
{

    public string name; //Bu bizim NPC Not Player Characterimizin adý kýsmý için

    [TextArea(3,10)]
    public string[] sentences; //Bu da konuþmalar için.


}
