# the ɹɹǝʞ language

A ɹɹǝʞ _program_ is a single _block_ (a sequence of comma separated _compounds_).  
A _compound_ is a sequence of _binary-op_ separated _terms_.  
A _term_ is... actually, let's have the grammar speak for itself:  

## ɹɹǝʞ syntax

_program_ = _block_  
_block_ = _compound_ \{ comma _compound_ ... \}  
_compound_ = _term_ \{ _binary-operator_ _term_ ... \}  
_term_ = \{ _unary-operator_ | _cast_ ... \} _value_ | lparen _block_ rparen \{ \{ dot \} _function_ ... \}  
_cast_ = lparen _type_ rparen  
_value_ = _constant_ | _default_ | _field_ | _function_ | _parameter_ | _variable_  

_constant_ = _bool_ | _char_ | _datetime_ | _decimal_ | _double_ | _float_ | _int_ | _long_ | _string_ | _timespan_ | _uint_ | _ulong_ <sup>_(1,4)_</sup>  
_default_ = lbrace _type_ rbrace  
_field_ = _one of_ **Album**, **Artist**, **Duration**, **Title**, ..., **Year** <sup>_(1,3,5)_</sup>  
_function_ = _function-name_ \{ _term_ | lparen \{ _block_ \} rparen \}  
_parameter_ = **Track** <sup>_(2)_</sup>  
_variable_ = _(any unreserved word)_ <sup>_(1)_</sup>  

_function-name_ = _one of_ **Compare** **Concat** ... **Upper** <sup>_(2,3)_</sup>  
_unary-operator_ = _one of_ +, ＋, -, －, !, **not** <sup>_(2)_</sup>  
_binary-operator_ = _assign-op_ | _logical-op_ | _relational-op_ | _arithmetic-op_ <sup>_(2)_</sup>  

_assign-op_ = _one of_ <-, :=, ←, &=, |=, \^=, +=, -=, \*=, /=, %=  
_logical-op_ = _one of_ &, &&, |, ||, ^, **and**, **or**, **xor**  
_relational-op_ = _one of_ =, ==, !=, <>, #, ≠, <, \<=, ≤, ≯, >=, ≥, ≮, >  
_arithmetic-op_ = _one of_ +, ＋, -, －, *, ×, ✕, /, ÷, ／, %  

comma = ','  
dot = '.'  
lbrace = '{'  
lparen = '('  
rbrace = '}'  
rparen = ')'  

_comments_ /* using C notation */ are treated as // whitespace.  

Notes:  
1. Case-insensitive.  
2. Case-insensitive and reserved.  
3. Not an exhaustive list; see source code for full details.  
4. _constants_ are parsed by Regex, using specific delimeters, internal format, and/or suffix characters; see source code for full details.  
5. _fields_ need not follow the usual naming conventions, but can instead start with a digit or symbol, and contain further symbols and/or embedded spaces; e.g. **\#&nbsp;Album&nbsp;Artists**, **1st&nbsp;Album&nbsp;Artist**, **Year/Album**. But with great power comes great heatsinks! You should probably avoid renaming a _field_ to something like **123** or **3D** or **3M**, which could be mistaken for an actual (e.g. _int_, _double_, _decimal_) _constant_.  

## further notes on the ɹɹǝʞ language  

- The concatenation of any two ɹɹǝʞ _programs_, separated by at least one whitespace character, is another ɹɹǝʞ _program_.  
- Since any ɹɹǝʞ _program_ is syntactically just just a _block_, it can be enclosed in parentheses and used as the argument list to a _function_.  
- All _functions_ are implemented as extensions, and may be invoked using either member or static syntax, with or without the dot "operator" (which is therefore optional).  
- A _function_'s parentheses are optional if the number of _terms_ to be enclosed is 0 or 1; otherwise, a comma separated list in parentheses is required.  

To summarize the above, observe that the following filter conditions are all equivalent:

    Title.Contains("Love") // Canonical C# member function syntax.
    title contains "Love" // Case insensitive keywords, optional dot operator & parentheses.
    contains(title, "Love") // Change function style from member to static.

