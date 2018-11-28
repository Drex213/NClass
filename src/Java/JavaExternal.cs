using NClass.Core;
using NClass.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NClass.Java
{
    internal sealed class JavaExternal : ExternalType
    {
        internal JavaExternal() : this("NewExternal")
        {
        }

        /// <exception cref="BadSyntaxException">
        /// The <paramref name="name"/> does not fit to the syntax.
        /// </exception>
        internal JavaExternal(string name) : base(name)
        {
        }

        public override AccessModifier AccessModifier
        {
            get
            {
                return base.AccessModifier;
            }
            set
            {
                if (IsNested ||
                    value == AccessModifier.Default ||
                    value == AccessModifier.Public)
                {
                    base.AccessModifier = value;
                }
            }
        }

        public override AccessModifier DefaultAccess
        {
            get { return AccessModifier.Internal; }
        }

        /// <exception cref="ArgumentException">
        /// The <paramref name="value"/> is already a child member of the type.
        /// </exception>
        public override CompositeType NestingParent
        {
            get
            {
                return base.NestingParent;
            }
            protected set
            {
                try
                {
                    RaiseChangedEvent = false;

                    base.NestingParent = value;
                    if (NestingParent == null && Access != AccessModifier.Public)
                        AccessModifier = AccessModifier.Default;
                }
                finally
                {
                    RaiseChangedEvent = true;
                }
            }
        }

        public override Language Language
        {
            get { return JavaLanguage.Instance; }
        }

        public override string GetDeclaration()
        {
            StringBuilder builder = new StringBuilder();

            if (AccessModifier != AccessModifier.Default)
            {
                builder.Append(Language.GetAccessString(AccessModifier, true));
                builder.Append(" ");
            }
            builder.AppendFormat("enum {0}", Name);

            return builder.ToString();
        }
    }
}
