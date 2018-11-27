using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NClass.Core.Entities
{
    public class ExternalType : TypeBase
    {
        public ExternalType(string name) : base(name)
        {
        }

        public override EntityType EntityType => EntityType.External;

        public override AccessModifier DefaultAccess => new AccessModifier();

        public override Language Language => null;

        public override string Stereotype => "«external»";

        public override string Signature => (Language.GetAccessString(Access, false) + " External");

        public override string GetDeclaration()
        {
            throw new NotImplementedException();
        }

        public override bool MoveDownItem(object item)
        {
            throw new NotImplementedException();
        }

        public override bool MoveUpItem(object item)
        {
            throw new NotImplementedException();
        }
    }
}
