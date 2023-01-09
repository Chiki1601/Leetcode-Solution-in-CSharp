public class Solution {
    public string CategorizeBox(int l, int w, int h, int mass) {
        
        bool isBulky = IsBulky(l, w, h, mass);
        bool isHeavy = IsHeavy(mass);
        
        if(isBulky)
        {
            if(isHeavy)
                return "Both";
            else
                return "Bulky";
        }
        
        if(isHeavy)
            return "Heavy";
        
        return "Neither";
        
    }
    
    private bool IsBulky(int l, int w, int h, int mass)
    {
        long vol = (long)l * w * h;
        return (vol >= (long)1e9 || l >= (int)1e4 || w >= (int)1e4 || h >= (int)1e4);
    }
    
    private bool IsHeavy(int mass) => mass >= 100 ? true : false;
}
