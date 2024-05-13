﻿# Grammar

A _program_ is a single _block_ (sequence of comma separated _compounds_).  
A _compound_ is a sequence of _bop_ (binary operator) separated _terms_.  
A _term_ is... actually, let's have the grammar speak for itself:

_program_ = _block_  
_block_ = _compound_ \{ ',' _compound_ ... \}  
_compound_ = _term_ \{ _bop_ _term_ ... \}  
_term_ = \{ _op_ | _cast_ ... \} _value_ | '(' _block_ ')' \{ \{ '.' \} _function_ ... \}  
_cast_ = '(' _type_ ')'  
_value_ = _constant_ | _default_ | _field_ | _function_ | _parameter_ | _variable_  

_constant_ = _bool_ | _char_ | _datetime_ | _decimal_ | _double_ | _float_ | _int_ | _long_ | _string_ | _timespan_ | _uint_ | _ulong_  
_default_ = '{' _type_ '}'  
_field_ = _one of_ **Album**, **Artist**, **Duration**, **Title**, ..., **Year** _(1,4)_  
_function_ = _fn_ \{ _term_ | '(' \{ _block_ \} ')' \}  
_parameter_ = **Track** _(1)_  
_variable_ = _(any unreserved word)_ _(2)_  

_fn_ = _one of_ **Compare** **Concat** ... **Upper** _(1)_  
_op_ = _one of_ +, -, !, **not** _(1,3)_  
_bop_ = _one of_ :=, &=, |=, \^=, +=, -=, \*=, /=, %=, &, |, ^, **and**, **or**, **xor**, =, !=, <, \<=, >=, >, +, -, *, /, % _(1,3)_  

_bool_ = _one of_ **true**, **false** _(1)_  
_char, datetime, decimal, double, float, int, long, string, timespan, uint, ulong_ - values are matched using Regex.  
_comments_ /* using C notation */ are treated as // whitespace.  

Notes:  
1. Terminal keywords are case-insensitive and reserved.  
2. Variable names are case-insensitive.  
3. Operators (both unary _op_ and binary _bop_) include further symbolic aliases.  
4. A _field_ name may start with a digit or a symbol, and may contain symbols and/or spaces; e.g. **\#&nbsp;Album&nbsp;Artists**, **1st&nbsp;Album&nbsp;Artist**. But with great power comes great heatsinks, and you should probably avoid renaming a _field_ to something like **123** or **3D** or **3M**, which could be mistaken for an actual (in these cases _int_, _double_, or _decimal_) constant.  
