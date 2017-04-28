using System.Drawing;
using System.Windows.Forms;

namespace ns18
{
	public abstract class AbstractBaseTreeNode1 : TreeNode
	{
		public static bool bool_0 = true;

		public virtual void vmethod_0()
		{
			if (!bool_0)
			{
				return;
			}
			Text = GetText();
			ToolTipText = GetToolTipText();
			BackColor = GetColor();
			SelectedImageIndex = (ImageIndex = vmethod_1());
		}

		public abstract int vmethod_1();

		public abstract void vmethod_2(ref int int_0);

		public virtual string GetText() 
		{
			return GetNodeText();
		}

		public virtual string GetToolTipText() 
        {
			return GetNodeText();
		}

		public abstract string GetNodeText();

		public Color GetColor2IfPrevNodeIsColor1(Color color1, Color color2)
		{
			if (Parent != null && PrevNode != null && PrevNode.BackColor.Equals(color1))
			{
				return color2;
			}
			return color1;
		}

		public virtual Color GetColor()
		{
			return Color.Aqua;
		}
	}
}
