﻿using geniussolution.Bytecode_Library.Bytecode;
using geniussolution.Bytecode_Library.IR;

namespace geniussolution.Obfuscator.Opcodes
{
    public class OpBOR : VOpcode
    {
        public override string OverrideString { get; set; } = "Stk[Inst[OP_A]]=BitBOR(Stk[Inst[OP_B]],Stk[Inst[OP_C]]);";

        public override bool IsInstruction(Instruction instruction) =>
            instruction.OpCode == Opcode.BOR && instruction.B <= 255 && instruction.C <= 255;

        public override string GetObfuscated(ObfuscationContext context) =>
            OverrideString;
    }

    public class OpBORB : VOpcode
    {
        public override string OverrideString { get; set; } = "Stk[Inst[OP_A]]=BitBOR(Const[Inst[OP_B]],Stk[Inst[OP_C]]);";

        public override bool IsInstruction(Instruction instruction) =>
            instruction.OpCode == Opcode.BOR && instruction.B > 255 && instruction.C <= 255;

        public override string GetObfuscated(ObfuscationContext context) =>
            OverrideString;

        public override void Mutate(Instruction instruction)
        {
            instruction.B -= 255;
        }
    }

    public class OpBORC : VOpcode
    {
        public override string OverrideString { get; set; } = "Stk[Inst[OP_A]]=BitBOR(Stk[Inst[OP_B]],Const[Inst[OP_C]]);";

        public override bool IsInstruction(Instruction instruction) =>
            instruction.OpCode == Opcode.BOR && instruction.B <= 255 && instruction.C > 255;

        public override string GetObfuscated(ObfuscationContext context) =>
            OverrideString;

        public override void Mutate(Instruction instruction)
        {
            instruction.C -= 255;
        }
    }

    public class OpBORD : VOpcode
    {
        public override string OverrideString { get; set; } = "Stk[Inst[OP_A]]=BitBOR(Const[Inst[OP_B]],Const[Inst[OP_C]]);";

        public override bool IsInstruction(Instruction instruction) =>
            instruction.OpCode == Opcode.BOR && instruction.B > 255 && instruction.C > 255;

        public override string GetObfuscated(ObfuscationContext context) =>
            OverrideString;

        public override void Mutate(Instruction instruction)
        {
            instruction.B -= 255;
            instruction.C -= 255;
        }
    }
}