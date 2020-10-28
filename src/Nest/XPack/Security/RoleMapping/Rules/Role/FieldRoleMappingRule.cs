namespace Nest6
{
	public class FieldRoleMappingRule : RoleMappingRuleBase
	{
		public FieldRoleMappingRule(FieldRuleBase field) => FieldRule = field;

		public FieldRuleBase Field => FieldRule;
	}
}
