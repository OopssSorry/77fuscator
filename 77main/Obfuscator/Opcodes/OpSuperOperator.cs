/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using geniussolution.Bytecode_Library.IR;

namespace geniussolution.Obfuscator.Opcodes
{
	public class OpSuperOperator : VOpcode
	{
		public override string OverrideString { get; set; } = "";

        public VOpcode[] SubOpcodes;

		public override bool IsInstruction(Instruction instruction) =>
			false;

		public bool IsInstruction(List<Instruction> instructions)
		{
			if (instructions.Count != SubOpcodes.Length)
				return false;

			for (int i = 0; i < SubOpcodes.Length; i++)
			{
                if (SubOpcodes[i] is OpMutated mut)
				{
					if (!mut.Mutated.IsInstruction(instructions[i]))
						return false;
				}
				else

                if (!SubOpcodes[i].IsInstruction(instructions[i]))
					return false;
			}

			return true;
		}

		public override string GetObfuscated(ObfuscationContext context)
		{
			List<string> locals = new List<string>();

			for (var index = 0; index < SubOpcodes.Length; index++)
			{
				var subOpcode = SubOpcodes[index];
				string s2 = subOpcode.GetObfuscated(context);

				Regex reg = new Regex("local(.*?)[;=]");
				foreach (Match m in reg.Matches(s2))
				{
					string loc = m.Groups[1].Value.Replace(" ", "");
					if (!locals.Contains(loc))
						locals.Add(loc);

					if (!m.Value.Contains(";"))
						s2 = s2.Replace($"local{m.Groups[1].Value}", loc);
					else
						s2 = s2.Replace($"local{m.Groups[1].Value};", "");
				}

                OverrideString += s2;

				if (index + 1 < SubOpcodes.Length)
                    OverrideString += "InstrPoint = InstrPoint + 1;Inst = Instr[InstrPoint];";
			}

			foreach (string l in locals)
                OverrideString = "local " + l + ';' + OverrideString;

			return OverrideString;
		}
	}
}*/