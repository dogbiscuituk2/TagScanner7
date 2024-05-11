
# Grammar

_TermList_ = _Compound_ \{ __comma__ _Compound_ ... \}

_Compound_ = _SimpleTerm_ \{ _BinaryOperator_ _SimpleTerm_ ... \}

_SimpleTerm_ = \{ _UnaryOperator_ | _Cast_ ... \} _Atom_ \{ _MemberFunction_ ... \}

_Cast_ = __lparen__ Type __rparen__

_Atom_ = _Constant_ | _Default_ | _Parameter_ | _Field_ | _Variable_ | _StaticFunction_

_MemberFunction_ = \{ __dot__ \} _StaticFunction_

_UnaryOperator_ = '+' | '-' | '!'

_BinaryOperator_ = ':=' | '&=' | '|=' | '\^=' | '+=' | '-=' | '*=*' | '/=' | '%=' | '&' | '|' | '^' | '=' | '!=' | '<' | '<=' | '>=' | '>' | '+' | '-' | '*' | '/' | '%'

__comma__ = ','

__dot__ = '.'

__lparen__ = '('

__rparen__ = ')'
