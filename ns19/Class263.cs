using ns16;
using ns18;
using System;
using System.Drawing;

namespace ns19
{
	public abstract class Class263 : Class260
	{
		public abstract byte vmethod_16();

		public override void vmethod_13(Stream26 stream26_0)
		{
			this.int_0 = stream26_0.method_19();
			this.int_1 = stream26_0.method_19();
			int num = stream26_0.method_19();
			stream26_0.method_19();
			if (num != 0)
			{
				Class259 @class = this.vmethod_12(stream26_0.method_42(num, true));
				base.Nodes.Add(@class);
				@class.method_4(stream26_0);
			}
		}

		public override void vmethod_14(Stream26 stream26_0)
		{
			byte[] array = new byte[4];
            array[1] = (this.vmethod_7() ? (byte)32 : (byte)4);
			array[2] = this.vmethod_16();
			stream26_0.method_16(array, false);
			stream26_0.method_5(this.int_0);
			stream26_0.method_5(this.int_1);
			stream26_0.method_5((base.Nodes.Count != 0) ? ((int)stream26_0.Position + 8) : 0);
			stream26_0.method_5(0);
			foreach (Class259 @class in base.Nodes)
			{
				@class.vmethod_14(stream26_0);
			}
		}

		public override void vmethod_2(ref int int_2)
		{
			int_2 += 20;
			foreach (Class259 @class in base.Nodes)
			{
				@class.vmethod_2(ref int_2);
			}
		}

		public override Color vmethod_15()
		{
			return base.method_0(Color.Lime, Color.SpringGreen);
		}
	}
}