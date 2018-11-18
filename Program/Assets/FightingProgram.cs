using System;
using System.Collections;
using Expload.Unity.Codegen;

namespace Expload.Pravda.FightingProgram
{
    public class AttachImplantToFighterRequest: ProgramRequest<string>
    {
        public AttachImplantToFighterRequest(byte[] programAddress) : base(programAddress) { }

        protected override string ParseResult(string elem)
        {
            return ExploadTypeConverters.ParseUtf8(elem);
        }

        public IEnumerator AttachImplantToFighter(int arg0, int arg1, int arg2, int arg3, int arg4, int arg5)
        {
            yield return SendRequest("AttachImplantToFighter", new string[] { ExploadTypeConverters.PrintInt32(arg0), ExploadTypeConverters.PrintInt32(arg1), ExploadTypeConverters.PrintInt32(arg2), ExploadTypeConverters.PrintInt32(arg3), ExploadTypeConverters.PrintInt32(arg4), ExploadTypeConverters.PrintInt32(arg5) });
        }
    }
    public class CreateImplantRequest: ProgramRequest<int>
    {
        public CreateImplantRequest(byte[] programAddress) : base(programAddress) { }

        protected override int ParseResult(string elem)
        {
            return ExploadTypeConverters.ParseInt32(elem);
        }

        public IEnumerator CreateImplant()
        {
            yield return SendRequest("CreateImplant", new string[] {  });
        }
    }
    public class GetAccountImplantsRequest: ProgramRequest<string>
    {
        public GetAccountImplantsRequest(byte[] programAddress) : base(programAddress) { }

        protected override string ParseResult(string elem)
        {
            return ExploadTypeConverters.ParseUtf8(elem);
        }

        public IEnumerator GetAccountImplants()
        {
            yield return SendRequest("GetAccountImplants", new string[] {  });
        }
    }
    public class GetFighterImplantsRequest: ProgramRequest<string>
    {
        public GetFighterImplantsRequest(byte[] programAddress) : base(programAddress) { }

        protected override string ParseResult(string elem)
        {
            return ExploadTypeConverters.ParseUtf8(elem);
        }

        public IEnumerator GetFighterImplants(int arg0)
        {
            yield return SendRequest("GetFighterImplants", new string[] { ExploadTypeConverters.PrintInt32(arg0) });
        }
    }
    public class GetImplantStatsRequest: ProgramRequest<string>
    {
        public GetImplantStatsRequest(byte[] programAddress) : base(programAddress) { }

        protected override string ParseResult(string elem)
        {
            return ExploadTypeConverters.ParseUtf8(elem);
        }

        public IEnumerator GetImplantStats(int arg0)
        {
            yield return SendRequest("GetImplantStats", new string[] { ExploadTypeConverters.PrintInt32(arg0) });
        }
    }
    public class ProceedBattleRequest: ProgramRequest<string>
    {
        public ProceedBattleRequest(byte[] programAddress) : base(programAddress) { }

        protected override string ParseResult(string elem)
        {
            return ExploadTypeConverters.ParseUtf8(elem);
        }

        public IEnumerator ProceedBattle(int arg0, int arg1)
        {
            yield return SendRequest("ProceedBattle", new string[] { ExploadTypeConverters.PrintInt32(arg0), ExploadTypeConverters.PrintInt32(arg1) });
        }
    }
    public class createNewFighterRequest: ProgramRequest<int>
    {
        public createNewFighterRequest(byte[] programAddress) : base(programAddress) { }

        protected override int ParseResult(string elem)
        {
            return ExploadTypeConverters.ParseInt32(elem);
        }

        public IEnumerator createNewFighter(string arg0)
        {
            yield return SendRequest("createNewFighter", new string[] { ExploadTypeConverters.PrintUtf8(arg0) });
        }
    }
}