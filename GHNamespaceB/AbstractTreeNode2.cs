using System.Drawing;

namespace GHNamespaceB
{
    public abstract class AbstractTreeNode2 : AbstractBaseTreeNode1
    {
        private static bool _colorFlipFlopper;

        public abstract object vmethod_7();

        public abstract byte[] vmethod_8();

        public abstract void vmethod_9(byte[] byte0);

        public string IntToHex32Bit(int int0) // This is kind of dumb because this is implemented elsewhere already
        {
            string text = int0.ToString("x");
            while (text.Length < 8)
            {
                text = "0" + text;
            }
            return text;
        }

        public override Color GetColor()
        {
            if (_colorFlipFlopper = !_colorFlipFlopper) // Why would you do this max
            {
                return Color.Ivory;
            }
            return Color.Khaki;
        }

        public override object Clone()
        {
            AbstractTreeNode2 @class = (AbstractTreeNode2) base.Clone();
            @class.vmethod_9(vmethod_8());
            return @class;
        }

        public override bool Equals(object obj)
        {
            return obj is AbstractTreeNode2 && ((AbstractTreeNode2) obj).vmethod_7().Equals(vmethod_7());
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}