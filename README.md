
# Grammar

_Block_ = _Compound_ \{ __comma__ _Compound_ ... \}
_Compound_ = _Term_ \{ _BinaryOp_ _Term_ ... \}
_Term_ = \{ _UnaryOp_ | _Cast_ ... \} _Value_ \{ \{ __dot__ \} _Function_ ... \}
_Cast_ = __lparen__ _Type_ __rparen__
_Value_ = _Constant_ | _Default_ | _Field_ | _Function_ | _Parameter_ | _Variable_
_Constant_ = _Bool_ | _Char_ | _DateTime_ | _Decimal_ | _Double_ | _Float_ | _Int_ | _Long_ | _String_ | _Uint_ | _Ulong_
_Default_ = __lbrace__ _Type_ __rbrace__
_Field_ = '# Album Artists' | '# Album Artists (sorted)' | ... _(100+ others)_ ... | 'Year/Album'
_Function_ = _Fn_ \{ _Term_ | __lparen__ \{ _Block_ \} __rparen__ \}
_Parameter_ = 'Track'
_Variable_ =
_Fn_ =
_UnaryOp_ = '+' | '-' | '!'
_BinaryOp_ = ':=' | '&=' | '|=' | '\^=' | '+=' | '-=' | '*=*' | '/=' | '%=' | '&' | '|' | '^' | '=' | '!=' | '<' | '<=' | '>=' | '>' | '+' | '-' | '*' | '/' | '%'
_Bool_ = 'true' | 'false'
_Char_ =
_DateTime_ =
_Decimal_ =
_Double_ =
_Float_ =
_Int_ =
_Long_ =
_String_ =
_Uint_ =
_Ulong_ =
__comma__ = ','
__dot__ = '.'
__lparen__ = '('
__rparen__ = ')'
