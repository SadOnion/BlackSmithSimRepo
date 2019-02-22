using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class PanelChange : MonoBehaviour
{

    
    public Animator anim;

   
    public void ForgeToQuest()
    {
        anim.SetTrigger("ForgeToQuest");
    }
    public void ForgeToShop()
    {
        anim.SetTrigger("ForgeToShop");
    }
    public void QuestToForge()
    {
        anim.SetTrigger("QuestToForge");
    }
    public void ShopToForge()
    {
        anim.SetTrigger("ShopToForge");
    }
}