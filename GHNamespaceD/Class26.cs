using GHNamespace3;

namespace GHNamespaceD
{
    public class Class26 : Class24
    {
        public override int vmethod_3(OggClass6 class710, object object0, float[][] float0, int[] int1, int int2)
        {
            int num = 0;
            for (int i = 0; i < int2; i++)
            {
                if (int1[i] != 0)
                {
                    float0[num++] = float0[i];
                }
            }
            if (num != 0)
            {
                return smethod_0(class710, object0, float0, num, 1);
            }
            return 0;
        }
    }
}