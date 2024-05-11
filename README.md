# Grammar

A _Program_ comprises a single _Block_, which is a sequence of _Compounds_, separated by commas. A _Compound_ is a sequence of _Terms_, separated by _binary operators_. A _Term_... actually, let's just have the Grammar specification speak for itself:

_Block_ = _Compound_ \{ __comma__ _Compound_ ... \}
_Compound_ = _Term_ \{ _BinaryOp_ _Term_ ... \}
_Term_ = \{ _UnaryOp_ | _Cast_ ... \} _Value_ \{ \{ __period__ \} _Function_ ... \}
_Cast_ = __left-paren__ _Type_ __right-paren__
_Value_ = _Constant_ | _Default_ | _Field_ | _Function_ | _Parameter_ | _Variable_

_Constant_ = _Bool_ | _Char_ | _DateTime_ | _Decimal_ | _Double_ | _Float_ | _Int_ | _Long_ | _String_ | _TimeSpan_ | _Uint_ | _Ulong_
_Default_ = __left-brace__ _Type_ __right-brace__
_Field_ = '# Album Artists' | '# Album Artists (sorted)' | ... | 'Year/Album' ^(1)^
_Function_ = _Fn_ \{ _Term_ | __left-paren__ \{ _Block_ \} __right-paren__ \}
_Parameter_ = 'Track'
_Variable_^(1)^ = "\w+"

_Fn_ = 'Compare' | 'Concat' | ... | 'Upper' ^(1)^
_UnaryOp_ = '+' | '-' | '!'
_BinaryOp_ = ':=' | '&=' | '|=' | '\^=' | '+=' | '-=' | '*=*' | '/=' | '%=' | '&' | '|' | '^' | '=' | '!=' | '<' | '<=' | '>=' | '>' | '+' | '-' | '*' | '/' | '%'

_Bool_^(1)^ = 'true' | 'false'
_Char_ = ^(2)^
_DateTime_ = ^(2)^
_Decimal_ = ^(2)^
_Double_ = ^(2)^
_Float_ = ^(2)^
_Int_ = ^(2)^
_Long_ = ^(2)^
_String_ = ^(2)^
_TimeSpan_ = ^(2)^
_Uint_ = ^(2)^
_Ulong_ = ^(2)^

__comma__ = ','
__period__ = '.'
__left-brace__ = '{'
__right-brace__ = '}'
__left-paren__ = '('
__right-paren__ = ')'

Notes: (1) case-insensitive; (2) uses Regex.
