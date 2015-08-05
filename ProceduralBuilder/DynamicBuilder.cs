using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PGenCore
{
    /// <summary>
    /// TODO: test construction
    /// TODO: test different field retreival techniques (using fields from T, and managing in a Dictionary)
    ///  - how would we define defaults?
    /// </summary>
    /// <typeparam name="T">Type to Build</typeparam>
    public class DynamicBuilder<T> : DynamicObject
    {
        #region List of FieldInformation
        protected FieldInfo[] FieldInfos;
        public FieldInfo[] FieldInformation
        {
            get
            {
                // don't GetFields all the time
                if (FieldInfos != null) return FieldInfos;

                FieldInfos = this.GetType().GetFields(
                    BindingFlags.Public |
                    BindingFlags.NonPublic |
                    BindingFlags.Instance);

                return FieldInfos;
            }
        }
        #endregion

        #region Method is Missing? Check for With{FieldName} Pattern

        /// <summary>
        /// Inherited form DynamicObject.
        /// Ran before each method call.
        /// TODO: test functionality of statically defined methods
        ///
        /// TODO: Simplify this method
        /// </summary>
        /// <param name="binder"></param>
        /// <param name="args"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override bool TryInvokeMember(
             InvokeMemberBinder binder,
             object[] args,
             out object result)
        {
            result = this;

            var firstArgument = args[0];
            var methodName = binder.Name;
            var methodPrefix = "With";

            if (firstArgument is bool)
            {
                methodPrefix = "";
            }

            if (!methodName.Contains(methodPrefix))
            {
                return false;
            }

            // convert the method name of pattern:
            // With{PropertyName} to the builder fild name pattern
            // _{propertyName}
            var propertyRootName = methodName.Replace(methodPrefix, "");
            var propertyLowerFirstLetterName = char.ToLower(
                propertyRootName[0]) +
                                               propertyRootName.Substring(1);

            var builderFieldName = "_" + propertyLowerFirstLetterName;

            // find matching field name, given the method name
            var fieldsMatchingName = FieldInformation
                .Where(field => field.Name == builderFieldName);

            // this should only be one field
            // we are returning anyway, so even if there are
            // somehow multiple matches, it doesn't matter.
            foreach (var field in fieldsMatchingName)
            {
                // set the field to the value in args
                field.SetValue(this, firstArgument);
                return true;
            }

            return false;
        }

        #endregion

        /// <summary>
        /// Returns the built object
        /// </summary>
        /// <returns></returns>
        public virtual T Build()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// for any complex associations
        /// - building lists of items
        /// - building anything else that isn't just an easy vavlue.
        /// </summary>
        public virtual void SetRelationshipDefaults()
        {
            throw new NotImplementedException();
        }
    }
}
