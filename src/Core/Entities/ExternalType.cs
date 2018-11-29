using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NClass.Core.Entities
{
    public abstract class ExternalType : TypeBase
    {
        public ExternalType(string name) : base(name)
        {
        }

        public override string Name
        {
            get
            {
                return name;
            }
            set
            {
                string newName = value;

                if (newName != name)
                {
                    name = newName;
                    Changed();
                }
            }
        }

        public override EntityType EntityType => EntityType.External;

        public override string Stereotype => "«external»";

        public override string Signature => (Language.GetAccessString(Access, false) + " External");

        public override bool MoveDownItem(object item)
        {
            return false;
        }

        public override bool MoveUpItem(object item)
        {
            return false;
        }
    }
}
